using Makabaka.Configurations;
using Makabaka.Models.EventArgs;
using Makabaka.Models.FastActions;
using Makabaka.Network;
using Makabaka.Utils;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WatsonWebserver;

namespace Makabaka.Services
{
	internal class HttpPostService : IPassiveService, IDisposable
	{
		#region 基本信息与构造函数

		private readonly HttpPostServiceConfig _config;

		private readonly Uri _uri;

		private readonly Server _server;

		private readonly Guid _guid;

		private readonly CancellationTokenSource _cts;

		private readonly PassiveDataProcessor _dataProcessor;

		public HttpPostService(HttpPostServiceConfig config)
		{
			_config = config;
			_uri = new($"http://{config.Host}:{config.Port}{config.UniversalPath}");
			_server = new(config.Host, config.Port);
			_guid = Guid.NewGuid();
			_cts = new();
			_dataProcessor = new(this);

			Log.Information($"创建HttpPost服务：[{_guid}]");
		}

		#endregion

		#region 接口实现

		private bool _running = false;

		private Task _serverTask;

		public async Task StartAsync()
		{
			if (_running)
			{
				throw new Exception("HttpPost服务已在运行，无法重复启动服务");
			}
			_running = true;

			Log.Information($"[{_guid}]启动HttpPost：{_uri}");
			_server.Routes.Static.Add(HttpMethod.POST, _config.UniversalPath, OnPost);
			_serverTask = _server.StartAsync(_cts.Token);

			await Task.CompletedTask;
		}

		public async Task OnPost(HttpContext ctx)
		{
			var needAuth = _config.AccessToken != null && _config.AccessToken.Length > 0;
			var authSuccess = false;
			var content = ctx.Request.DataAsString;

			Log.Debug($"[{_guid}][{ctx.Request.Source.IpAddress}:{ctx.Request.Source.Port}]接收数据：{content}");

			if (!needAuth)
			{
				authSuccess = true;
			}
			else
			{
				var signature = ctx.Request.Headers["X-Signature"];
				var signature2 = ComputeSignature(content, _config.AccessToken);
				if (signature == $"sha1={signature2}")
				{
					authSuccess = true;
				}

				Log.Verbose($"[{_guid}][{ctx.Request.Source.IpAddress}:{ctx.Request.Source.Port}]请求头的签名：{signature}，期望的签名：sha1={signature2}");
			}

			if (authSuccess)
			{
				var fastAction = await _dataProcessor.Process(content);
				if (fastAction == null)
				{
					ctx.Response.StatusCode = (int)HttpStatusCode.NoContent;
					await ctx.Response.Send();
					Log.Debug($"[{_guid}][{ctx.Request.Source.IpAddress}:{ctx.Request.Source.Port}]发送数据：NoContent");
				}
				else
				{
					ctx.Response.ContentType = "application/json";
					var data = JsonConvert.SerializeObject(fastAction);
					await ctx.Response.Send(data);
					Log.Debug($"[{_guid}][{ctx.Request.Source.IpAddress}:{ctx.Request.Source.Port}]发送数据：{data}");
				}
			}
			else
			{
				Log.Error($"[{_guid}][{ctx.Request.Url}]签名异常");
				ctx.Response.StatusCode = (int)HttpStatusCode.Forbidden;
				await ctx.Response.Send();
			}
		}

		private static string ComputeSignature(string body, string secret)
		{
			using var sha1 = SHA1.Create();
			var key1 = sha1.ComputeHash(Encoding.UTF8.GetBytes(body));
			var key2 = key1.Concat(Encoding.UTF8.GetBytes(secret)).ToArray();
			var key3 = sha1.ComputeHash(key2);
			return BitConverter.ToString(key3).Replace("-", string.Empty);
		}

		public async Task WaitAsync()
		{
			await _serverTask;
		}

		public async Task StopAsync()
		{
			if (!_running)
			{
				throw new Exception("HttpPost服务未运行，无法停止服务");
			}

			Log.Information($"[{_guid}]正在停止HttpPost服务");
			_cts.Cancel();
			await _serverTask;
			Log.Information($"[{_guid}]已停止HttpPost服务");

			_running = false;
		}

		#endregion

		#region 事件

		public event FastActionEventHandler<LifeCycleEventArgs> OnLifeCycle;

		public async Task<IFastAction> SendLifeCycleEvent(LifeCycleEventArgs e)
		{
			return await OnLifeCycle?.Invoke(this, e);
		}

		public event FastActionEventHandler<HeartbeatEventArgs> OnHeartbeat;

		public async Task<IFastAction> SendHeartbeatEvent(HeartbeatEventArgs e)
		{
			return await OnHeartbeat?.Invoke(this, e);
		}

		public event FastActionEventHandler<GroupMessageEventArgs> OnGroupMessage;

		public async Task<IFastAction> SendGroupMessageEvent(GroupMessageEventArgs e)
		{
			return await OnGroupMessage?.Invoke(this, e);
		}

		public event FastActionEventHandler<AddFriendRequestEventArgs> OnAddFriendRequest;

		public async Task<IFastAction> SendAddFriendRequestEvent(AddFriendRequestEventArgs e)
		{
			return await OnAddFriendRequest?.Invoke(this, e);
		}

		#endregion

		#region 释放

		private bool disposedValue;

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: 释放托管状态(托管对象)
					_server.Dispose();
				}

				// TODO: 释放未托管的资源(未托管的对象)并重写终结器
				// TODO: 将大型字段设置为 null
				disposedValue = true;
			}
		}

		// // TODO: 仅当“Dispose(bool disposing)”拥有用于释放未托管资源的代码时才替代终结器
		// ~HttpPostService()
		// {
		//     // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
		//     Dispose(disposing: false);
		// }

		public void Dispose()
		{
			// 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		#endregion
	}
}
