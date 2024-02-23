using Makabaka.Configurations;
using Makabaka.Models.EventArgs;
using Makabaka.Network;
using Makabaka.Utils;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WatsonWebsocket;

namespace Makabaka.Services
{
	internal class ReverseWebSocketService : IService, IDisposable
	{
		#region 基本信息与构造函数

		private readonly ReverseWebSocketServiceConfig _config;

		private readonly Uri _uri;

		private readonly WatsonWsServer _ws;

		private readonly Guid _guid;

		public ReverseWebSocketService(ReverseWebSocketServiceConfig config)
		{
			_config = config;
			_uri = new($"http://{config.Host}:{config.Port}{config.UniversalPath}");
			_ws = new(_uri);
			_guid = Guid.NewGuid();

			Log.Information($"创建反向WebSocket服务：[{_guid}]");
		}

		#endregion

		#region 接口实现

		private bool _running = false;

		public async Task StartAsync()
		{
			if (_running)
			{
				throw new Exception("反向WebSocket服务已在运行，无法重复启动服务");
			}
			_running = true;

			_ws.ClientConnected += OnClientConnected;
			_ws.ClientDisconnected += OnClientDisconnected;
			_ws.MessageReceived += OnMessageReceived;

			Log.Information($"[{_guid}]启动反向WebSocket：{_uri}");
			await _ws.StartAsync();
		}

		private readonly Dictionary<Guid, ReverseWebSocket> _reverseWebSocketMap = new();

		public List<ISession> Sessions { get; private set; } = new();

		private void OnClientConnected(object sender, ConnectionEventArgs e)
		{
			var needAuth = _config.AccessToken != null && _config.AccessToken.Length > 0;
			var authSuccess = false;

			if (!needAuth)
			{
				authSuccess = true;
			}
			else
			{
				var request = e.HttpRequest;
				var auth = request.Headers["Authorization"];
				if (auth == $"Bearer {_config.AccessToken}")
				{
					authSuccess = true;
				}

				Log.Verbose($"[{_guid}][{e.Client.IpPort}]请求头：");
				foreach (var key in request.Headers.AllKeys)
				{
					Log.Verbose($"{key}: {request.Headers[key]}");
				}
			}

			if (authSuccess)
			{
				var session = new ReverseWebSocket(this, _ws, e.Client.Guid, _config);
				_reverseWebSocketMap.Add(e.Client.Guid, session);
				Sessions.Add(session);
				Log.Information($"[{_guid}][{e.Client.IpPort}]连接成功：[{e.Client.Guid}]");
			}
			else
			{
				Log.Error($"[{_guid}][{e.Client.IpPort}]连接失败：AccessToken不匹配");
				_ws.DisconnectClient(e.Client.Guid);
			}
		}

		private void OnClientDisconnected(object sender, DisconnectionEventArgs e)
		{
			if (_reverseWebSocketMap.TryGetValue(e.Client.Guid, out var reverseWebSocket))
			{
				Sessions.Remove(reverseWebSocket);
			}
			_reverseWebSocketMap.Remove(e.Client.Guid);
			Log.Information($"[{_guid}][{e.Client.IpPort}]断开连接");
		}

		private void OnMessageReceived(object sender, MessageReceivedEventArgs e)
		{
			if (e.MessageType != WebSocketMessageType.Text)
			{
				return;
			}

			var data = Encoding.UTF8.GetString(e.Data.ToArray());
			Log.Debug($"[{_guid}][{e.Client.IpPort}]接收数据：{data}");

			if (!_reverseWebSocketMap.TryGetValue(e.Client.Guid, out var reverseWebSocket))
			{
				Log.Error($"[{_guid}][{e.Client.IpPort}]无法找到对应Guid的客户端：{e.Client.Guid}");
				return;
			}

			reverseWebSocket.ProcessData(_guid, e.Client.IpPort, data);
		}

		public async Task WaitAsync()
		{
			await _ws;
		}

		public async Task StopAsync()
		{
			if (!_running)
			{
				throw new Exception("反向WebSocket服务未运行，无法停止服务");
			}

			Log.Information($"[{_guid}]正在停止反向WebSocket服务");
			_ws.Stop();
			await _ws;
			Log.Information($"[{_guid}]已停止反向WebSocket服务");

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

		#region 释放

		private bool disposedValue;

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: 释放托管状态(托管对象)
					_ws.Dispose();
				}

				// TODO: 释放未托管的资源(未托管的对象)并重写终结器
				// TODO: 将大型字段设置为 null
				disposedValue = true;
			}
		}

		// // TODO: 仅当“Dispose(bool disposing)”拥有用于释放未托管资源的代码时才替代终结器
		// ~ReverseWebSocketService()
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
