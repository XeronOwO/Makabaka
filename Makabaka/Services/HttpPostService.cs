using Makabaka.Configurations;
using Makabaka.Models.EventArgs.Messages;
using Makabaka.Models.EventArgs.Meta;
using Makabaka.Models.EventArgs.Requests;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WatsonWebserver;

namespace Makabaka.Services
{
	internal class HttpPostService : IService, IDisposable
	{
		#region 基本信息与构造函数

		private readonly HttpPostServiceConfig _config;

		private readonly Uri _uri;

		private readonly Server _server;

		private readonly Guid _guid;

		private readonly CancellationTokenSource _cts;

		public HttpPostService(HttpPostServiceConfig config)
		{
			_config = config;
			_uri = new($"http://{config.Host}:{config.Port}{config.UniversalPath}");
			_server = new(config.Host, config.Port);
			_guid = Guid.NewGuid();
			_cts = new();

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

			Log.Information($"[{_guid}]启动反向WebSocket：{_uri}");
			_server.Routes.Static.Add(HttpMethod.POST, _config.UniversalPath, OnPost);
			_serverTask = _server.StartAsync(_cts.Token);

			await Task.CompletedTask;
		}

		public async Task OnPost(HttpContext ctx)
		{
			var content = ctx.Request.DataAsString;
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

		public event EventHandler<LifeCycleEventArgs> OnLifeCycle;

		void IService.SendLifeCycleEvent(LifeCycleEventArgs e)
		{
			OnLifeCycle?.Invoke(this, e);
		}

		public event EventHandler<HeartbeatEventArgs> OnHeartbeat;

		void IService.SendHeartbeatEvent(HeartbeatEventArgs e)
		{
			OnHeartbeat?.Invoke(this, e);
		}

		public event EventHandler<GroupMessageEventArgs> OnGroupMessage;

		void IService.SendGroupMessageEvent(GroupMessageEventArgs e)
		{
			OnGroupMessage?.Invoke(this, e);
		}

		public event EventHandler<AddFriendRequestEventArgs> OnAddFriendRequest;

		void IService.SendAddFriendRequestEvent(AddFriendRequestEventArgs e)
		{
			OnAddFriendRequest?.Invoke(this, e);
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
