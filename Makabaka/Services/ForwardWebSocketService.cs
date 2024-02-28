using Makabaka.Configurations;
using Makabaka.Models.EventArgs;
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

			var guid = _ws.Guid;
			Log.Information($"正在停止正向WebSocket[{guid}]");
			_cts.Cancel();
			await _loopTask;
			Log.Information($"已停止正向WebSocket[{guid}]");

			_running = false;
		}

		#endregion

		#region 事件

		public event EventHandler<PrivateMessageEventArgs> OnPrivateMessage;

		public void SendPrivateMessageEvent(PrivateMessageEventArgs e)
		{
			OnPrivateMessage?.Invoke(this, e);
		}

		public event EventHandler<GroupMessageEventArgs> OnGroupMessage;

		public void SendGroupMessageEvent(GroupMessageEventArgs e)
		{
			OnGroupMessage?.Invoke(this, e);
		}

		public event EventHandler<GroupAdminChangedEventArgs> OnGroupAdminChanged;

		public void SendGroupAdminChangedEvent(GroupAdminChangedEventArgs e)
		{
			OnGroupAdminChanged?.Invoke(this, e);
		}

		public event EventHandler<GroupMemberDecreaseEventArgs> OnGroupMemberDecrease;

		public void SendGroupMemberDecreaseEvent(GroupMemberDecreaseEventArgs e)
		{
			OnGroupMemberDecrease?.Invoke(this, e);
		}

		public event EventHandler<GroupMemberIncreaseEventArgs> OnGroupMemberIncrease;

		public void SendGroupMemberIncreaseEvent(GroupMemberIncreaseEventArgs e)
		{
			OnGroupMemberIncrease?.Invoke(this, e);
		}

		public event EventHandler<GroupMuteEventArgs> OnGroupMute;

		public void SendGroupMuteEvent(GroupMuteEventArgs e)
		{
			OnGroupMute?.Invoke(this, e);
		}

		public event EventHandler<FriendAddEventArgs> OnFriendAdd;

		public void SendFriendAddEvent(FriendAddEventArgs e)
		{
			OnFriendAdd?.Invoke(this, e);
		}

		public event EventHandler<GroupRecallMessageEventArgs> OnGroupRecallMessage;

		public void SendGroupRecallMessageEvent(GroupRecallMessageEventArgs e)
		{
			OnGroupRecallMessage?.Invoke(this, e);
		}

		public event EventHandler<FriendRecallMessageEventArgs> OnFriendRecallMessage;

		public void SendFriendRecallMessageEvent(FriendRecallMessageEventArgs e)
		{
			OnFriendRecallMessage?.Invoke(this, e);
		}

		public event EventHandler<AddFriendRequestEventArgs> OnAddFriendRequest;

		public void SendAddFriendRequestEvent(AddFriendRequestEventArgs e)
		{
			OnAddFriendRequest?.Invoke(this, e);
		}

		public event EventHandler<GroupRequestEventArgs> OnGroupRequest;

		public void SendGroupRequestEvent(GroupRequestEventArgs e)
		{
			OnGroupRequest?.Invoke(this, e);
		}

		public event EventHandler<LifeCycleEventArgs> OnLifeCycle;

		public void SendLifeCycleEvent(LifeCycleEventArgs e)
		{
			OnLifeCycle?.Invoke(this, e);
		}

		public event EventHandler<HeartbeatEventArgs> OnHeartbeat;

		public void SendHeartbeatEvent(HeartbeatEventArgs e)
		{
			OnHeartbeat?.Invoke(this, e);
		}

		#endregion
	}
}
