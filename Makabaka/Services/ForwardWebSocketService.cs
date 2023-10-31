using Makabaka.Configurations;
using Makabaka.Models.EventArgs.Messages;
using Makabaka.Models.EventArgs.Meta;
using Makabaka.Models.EventArgs.Requests;
using Makabaka.Network;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Makabaka.Services
{
	internal class ForwardWebSocketService : IService
	{
		#region 基本信息与构造函数

		private readonly ForwardWebSocketServiceConfig _config;

		private readonly CancellationTokenSource _cts;

		public ForwardWebSocketService(ForwardWebSocketServiceConfig config)
		{
			_config = config;
			_cts = new();
		}

		#endregion

		#region 接口实现

		private bool _running = false;

		private Task _loopTask;

		public async Task StartAsync()
		{
			if (_running)
			{
				throw new Exception("正向WebSocket服务已在运行，无法重复启动服务");
			}
			_running = true;

			Log.Information($"正在启动正向WebSocket服务");
			_loopTask = LoopAsync();

			await Task.CompletedTask;
		}

		private ForwardWebSocket _ws;

		public List<ISession> Sessions { get; private set; } = new();

		private async Task LoopAsync()
		{
			try
			{
				while (_config.AutoReconnect)
				{
					_ws = new ForwardWebSocket(this, _config);
					Sessions.Add(_ws);
					await _ws.StartAndWaitAsync(_cts.Token);

					Sessions.Remove(_ws);
					_ws.Dispose();
					_ws = null;

					if (_config.AutoReconnect)
					{
						await Task.Delay(_config.ReconnectInterval, _cts.Token);
					}
				}
			}
			catch (OperationCanceledException)
			{
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task WaitAsync()
		{
			await _loopTask;
		}

		public async Task StopAsync()
		{
			if (!_running)
			{
				throw new Exception("正向WebSocket服务未运行，无法停止服务");
			}

			Log.Information($"正在停止正向WebSocket[{_ws.Guid}]");
			_cts.Cancel();
			await _loopTask;
			Log.Information($"已停止正向WebSocket[{_ws.Guid}]");

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
	}
}
