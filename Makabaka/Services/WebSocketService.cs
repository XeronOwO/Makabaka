using Makabaka.Models.EventArgs;
using Makabaka.Network;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Makabaka.Services
{
	internal abstract class WebSocketService : IWebSocketService
	{
		public abstract Task StartAsync();

		public abstract Task WaitAsync();

		public abstract Task StopAsync();

		public abstract List<IWebSocketContext> Contexts { get; }

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

		public event EventHandler<GroupFileUploadEventArgs> OnGroupFileUpload;

		public void SendGroupFileUploadEvent(GroupFileUploadEventArgs e)
		{
			OnGroupFileUpload?.Invoke(this, e);
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
