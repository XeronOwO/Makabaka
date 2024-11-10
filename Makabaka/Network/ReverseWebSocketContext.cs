using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using WatsonWebsocket;

namespace Makabaka.Network
{
	internal class ReverseWebSocketContext(
		ILogger<ReverseWebSocketContext> logger,
		IConfiguration configuration,
		IBotContext botContext,
		IServiceProvider services
#pragma warning disable CS9107 // 参数捕获到封闭类型状态，其值也传递给基构造函数。该值也可能由基类捕获。
		) : WebSocketContext(botContext, services)
#pragma warning restore CS9107 // 参数捕获到封闭类型状态，其值也传递给基构造函数。该值也可能由基类捕获。
	{
		private string Url => configuration.GetValue("Bot:ReverseWebSocket:Url", "ws://127.0.0.1:8081/onebot/v11/ws")!;

		private string AccessToken => configuration.GetValue("Bot:ReverseWebSocket:AccessToken", string.Empty)!;

		private int RestartInterval => configuration.GetValue("Bot:ReverseWebSocket:RestartInterval", 1000);

		public override Task RunAsync(CancellationToken cancellationToken)
		{
			RegisterProcessors();

			return RunWebSocketServerAsync(cancellationToken);
		}

		private WatsonWsServer _server = null!;

		private async Task RunWebSocketServerAsync(CancellationToken cancellationToken)
		{
			var first = true;

			while (!cancellationToken.IsCancellationRequested)
			{
				try
				{
					if (!first)
					{
						await Task.Delay(RestartInterval, cancellationToken);
					}
					first = false;

					logger.LogInformation(SR.ReverseWebSocketServerStarting, Url);

					var uri = new Uri(Url);
					_server = new WatsonWsServer(uri);
					_server.ClientConnected += ClientConnected;
					_server.ClientDisconnected += ClientDisconnected;
					_server.MessageReceived += MessageReceived;

					await _server.StartAsync(cancellationToken);
					logger.LogInformation(SR.ReverseWebSocketServerStartSuccess);

					await RunAPISendAsync(cancellationToken);
				}
				catch (OperationCanceledException)
				{
					logger.LogInformation(SR.ReverseWebSocketTaskCanceled);
					break;
				}
				catch (Exception e)
				{
					logger.LogError(e, SR.UnexpectedException);
				}
				finally
				{
					_server.DisconnectClients();
					_server.Dispose();
					_server = null!;
					logger.LogInformation(SR.ReverseWebSocketServerStopped);
				}
			}
		}

		private async void MessageReceived(object sender, MessageReceivedEventArgs e)
		{
			var bytes = e.Data;
			var data = Encoding.UTF8.GetString(bytes);
			var node = JsonSerializer.Deserialize<JsonNode>(data);
			if (node == null)
			{
				logger.LogError(SR.MessageDeserializeFailed);
				return;
			}

			logger.LogTrace(SR.ReverseWebSocketReceived, e.Client.IpPort, data);

			if (!await TryProcessAsync(node))
			{
				logger.LogError(SR.MessageProcessedFailed);
			}
		}

		private string Authorization => $"Bearer {AccessToken}";

		private void ClientConnected(object sender, ConnectionEventArgs e)
		{
			var authorization = e.HttpRequest.Headers["Authorization"];

			if (authorization == Authorization)
			{
				logger.LogInformation(SR.ReverseWebSocketClientConnected, e.Client.IpPort);
			}
			else
			{
				logger.LogError(SR.ReverseWebSocketWrongAuthorization, e.Client.IpPort, Authorization, authorization);
				_server.DisconnectClient(e.Client.Guid);
			}
		}

		private void ClientDisconnected(object sender, DisconnectionEventArgs e)
		{
			logger.LogInformation(SR.ReverseWebSocketClientDisconnected, e.Client.IpPort);
		}

		private async Task RunAPISendAsync(CancellationToken cancellationToken)
		{
			while (!cancellationToken.IsCancellationRequested)
			{
				try
				{
					var apiContext = botContext.APISendQueue.Take(cancellationToken);
					var request = apiContext.Request;
					var requestString = JsonSerializer.Serialize(request, request.GetType(), _jsonSerializerOptions);
					if (!await _server.BroadcastAsync(requestString, WebSocketMessageType.Text, cancellationToken))
					{
						logger.LogError(SR.ForwardWebSocketSendFailed);
						continue;
					}

					logger.LogTrace(SR.ReverseWebSocketSent, requestString);
					APIReceiveDict.TryAdd(request.Echo, apiContext);
				}
				catch (OperationCanceledException)
				{
					logger.LogInformation(SR.ReverseWebSocketAPISendTaskCanceled);
					break;
				}
				catch (Exception e)
				{
					logger.LogError(e, SR.UnexpectedException);
				}
			}
		}
	}

	internal static class WatsonWsServerExt
	{
		public static async Task<bool> BroadcastAsync(this WatsonWsServer server, string message, WebSocketMessageType type, CancellationToken cancellationToken)
		{
			var result = false;
			foreach (var client in server.ListClients())
			{
				var success = await server.SendAsync(client.Guid, message, type, cancellationToken);
				if (success)
				{
					result = success;
				}
			}
			return result;
		}

		public static void DisconnectClients(this WatsonWsServer server)
		{
			foreach (var client in server.ListClients())
			{
				server.DisconnectClient(client.Guid);
			}
		}
	}
}
