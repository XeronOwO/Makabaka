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
	internal class ForwardWebSocketContext(
		ILogger<ForwardWebSocketContext> logger,
		IConfiguration configuration,
		IBotContext botContext,
		IServiceProvider services
#pragma warning disable CS9107 // 参数捕获到封闭类型状态，其值也传递给基构造函数。该值也可能由基类捕获。
		) : WebSocketContext(botContext, services)
#pragma warning restore CS9107 // 参数捕获到封闭类型状态，其值也传递给基构造函数。该值也可能由基类捕获。
	{
		private string Url => configuration.GetValue("Bot:ForwardWebSocket:Url", "ws://127.0.0.1:8081")!;

		private string AccessToken => configuration.GetValue("Bot:ForwardWebSocket:AccessToken", string.Empty)!;

		private int ReconnectInterval => configuration.GetValue("Bot:ForwardWebSocket:ReconnectInterval", 1000);

		private int ConnectionTimeout => configuration.GetValue("Bot:ForwardWebSocket:ConnectionTimeout", 5000);

		public override Task RunAsync(CancellationToken cancellationToken)
		{
			RegisterProcessors();

			return RunWebSocketAsync(cancellationToken);
		}

		private CancellationTokenSource _connectionCancellationTokenSource = new();

		private void ServerDisconnected(object sender, EventArgs e)
		{
			logger.LogInformation(SR.ForwardWebSocketDisconnected);
			_connectionCancellationTokenSource.Cancel();
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

			logger.LogTrace(SR.ForwardWebSocketReceived, data);

			if (!await TryProcessAsync(node))
			{
				logger.LogError(SR.MessageProcessedFailed);
			}
		}

		private async Task RunWebSocketAsync(CancellationToken cancellationToken)
		{
			while (!cancellationToken.IsCancellationRequested)
			{
				logger.LogInformation(SR.ForwardWebSocketConnecting, Url);

				var uri = new Uri(Url);
				using var client = new WatsonWsClient(uri);
				client.ServerDisconnected += ServerDisconnected;
				client.MessageReceived += MessageReceived;
				client.ConfigureOptions(options =>
				{
					options.UseDefaultCredentials = true;
					options.SetRequestHeader("Authorization", $"Bearer {AccessToken}");
				});

				try
				{
					var timeoutCancellationTokenSource = new CancellationTokenSource(ConnectionTimeout);
					var linkedCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(timeoutCancellationTokenSource.Token, cancellationToken);
					var success = await client.StartWithTimeoutAsync(token: linkedCancellationTokenSource.Token);

					if (!success) // 连接失败，等待重连
					{
						logger.LogError(SR.ForwardWebSocketConnectFailed);
						await Task.Delay(ReconnectInterval, cancellationToken);
						continue;
					}

					logger.LogInformation(SR.ForwardWebSocketConnectSuccess);

					_connectionCancellationTokenSource = new();
					await RunAPISendAsync(client, cancellationToken);
				}
				catch (OperationCanceledException)
				{
					logger.LogInformation(SR.ForwardWebSocketTaskCanceled);
					break;
				}
				catch (Exception e)
				{
					logger.LogError(e, SR.UnexpectedException);
				}
			}
		}

		private async Task RunAPISendAsync(WatsonWsClient client, CancellationToken cancellationToken)
		{
			var linkedCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, _connectionCancellationTokenSource.Token);
			var linkedCancellationToken = linkedCancellationTokenSource.Token;

			while (!linkedCancellationToken.IsCancellationRequested)
			{
				try
				{
					var apiContext = botContext.APISendQueue.Take(linkedCancellationToken);
					var request = apiContext.Request;
					var requestString = JsonSerializer.Serialize(request, request.GetType(), _jsonSerializerOptions);
					if (!await client.SendAsync(requestString, WebSocketMessageType.Text, linkedCancellationToken))
					{
						logger.LogError(SR.ForwardWebSocketSendFailed);
						continue;
					}

					logger.LogTrace(SR.ForwardWebSocketSent, requestString);
					APIReceiveDict.TryAdd(request.Echo, apiContext);
				}
				catch (OperationCanceledException)
				{
					logger.LogInformation(SR.ForwardWebSocketAPISendTaskCanceled);
					break;
				}
				catch (Exception e)
				{
					logger.LogError(e, SR.UnexpectedException);
				}
			}
		}
	}
}
