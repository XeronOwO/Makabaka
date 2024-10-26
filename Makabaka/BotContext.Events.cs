using Makabaka.Events;
using System.Threading.Tasks;

namespace Makabaka
{
	internal partial class BotContext
	{
		public long SelfId { get; private set; }

		public event EventHandlerAsync<LifecycleEventArgs>? OnLifecycle;

		async Task IBotContext.InvokeOnLifecycle(object sender, LifecycleEventArgs e)
		{
			if (OnLifecycle == null)
			{
				return;
			}

			SelfId = e.SelfId;

			await OnLifecycle.Invoke(sender, e);
		}

		public event EventHandlerAsync<HeartbeatEventArgs>? OnHeartbeat;

		async Task IBotContext.InvokeOnHeartbeat(object sender, HeartbeatEventArgs e)
		{
			if (OnHeartbeat == null)
			{
				return;
			}

			await OnHeartbeat.Invoke(sender, e);
		}

		public event EventHandlerAsync<PrivateMessageEventArgs>? OnPrivateMessage;

		async Task IBotContext.InvokeOnPrivateMessage(object sender, PrivateMessageEventArgs e)
		{
			if (OnPrivateMessage == null)
			{
				return;
			}

			await OnPrivateMessage.Invoke(sender, e);
		}

		public event EventHandlerAsync<GroupMessageEventArgs>? OnGroupMessage;

		async Task IBotContext.InvokeOnGroupMessage(object sender, GroupMessageEventArgs e)
		{
			if (OnGroupMessage == null)
			{
				return;
			}

			await OnGroupMessage.Invoke(sender, e);
		}

		public event EventHandlerAsync<GroupFileUploadEventArgs>? OnGroupFileUpload;

		async Task IBotContext.InvokeOnGroupFileUploadMessage(object sender, GroupFileUploadEventArgs e)
		{
			if (OnGroupFileUpload == null)
			{
				return;
			}

			await OnGroupFileUpload.Invoke(sender, e);
		}

		public event EventHandlerAsync<GroupAdminChangeEventArgs>? OnGroupAdminChange;

		async Task IBotContext.InvokeOnGroupAdminChange(object sender, GroupAdminChangeEventArgs e)
		{
			if (OnGroupAdminChange == null)
			{
				return;
			}

			await OnGroupAdminChange.Invoke(sender, e);
		}

		public event EventHandlerAsync<GroupMemberDecreaseEventArgs>? OnGroupMemberDecrease;

		async Task IBotContext.InvokeOnGroupMemberDecrease(object sender, GroupMemberDecreaseEventArgs e)
		{
			if (OnGroupMemberDecrease == null)
			{
				return;
			}

			await OnGroupMemberDecrease.Invoke(sender, e);
		}

		public event EventHandlerAsync<GroupMemberIncreaseEventArgs>? OnGroupMemberIncrease;

		async Task IBotContext.InvokeOnGroupMemberIncrease(object sender, GroupMemberIncreaseEventArgs e)
		{
			if (OnGroupMemberIncrease == null)
			{
				return;
			}

			await OnGroupMemberIncrease.Invoke(sender, e);
		}

		public event EventHandlerAsync<GroupMemberMuteEventArgs>? OnGroupMemberMute;

		async Task IBotContext.InvokeOnGroupMemberMute(object sender, GroupMemberMuteEventArgs e)
		{
			if (OnGroupMemberMute == null)
			{
				return;
			}

			await OnGroupMemberMute.Invoke(sender, e);
		}

		public event EventHandlerAsync<FriendAddEventArgs>? OnFriendAdd;

		async Task IBotContext.InvokeOnFriendAdd(object sender, FriendAddEventArgs e)
		{
			if (OnFriendAdd == null)
			{
				return;
			}

			await OnFriendAdd.Invoke(sender, e);
		}

		public event EventHandlerAsync<GroupMessageWithdrawEventArgs>? OnGroupMessageWithdraw;

		async Task IBotContext.InvokeOnGroupMessageWithdraw(object sender, GroupMessageWithdrawEventArgs e)
		{
			if (OnGroupMessageWithdraw == null)
			{
				return;
			}

			await OnGroupMessageWithdraw.Invoke(sender, e);
		}

		public event EventHandlerAsync<FriendMessageWithdrawEventArgs>? OnFriendMessageWithdraw;

		async Task IBotContext.InvokeOnFriendMessageWithdraw(object sender, FriendMessageWithdrawEventArgs e)
		{
			if (OnFriendMessageWithdraw == null)
			{
				return;
			}

			await OnFriendMessageWithdraw.Invoke(sender, e);
		}

		public event EventHandlerAsync<GroupPokeEventArgs>? OnGroupPoke;

		async Task IBotContext.InvokeOnGroupPoke(object sender, GroupPokeEventArgs e)
		{
			if (OnGroupPoke == null)
			{
				return;
			}

			await OnGroupPoke.Invoke(sender, e);
		}

		public event EventHandlerAsync<ReactionEventArgs>? OnGroupReaction;

		async Task IBotContext.InvokeOnGroupReaction(object sender, ReactionEventArgs e)
		{
			if (OnGroupReaction == null)
			{
				return;
			}

			await OnGroupReaction.Invoke(sender, e);
		}

		public event EventHandlerAsync<GroupLuckyKingEventArgs>? OnGroupLuckyKing;

		async Task IBotContext.InvokeOnGroupLuckyKing(object sender, GroupLuckyKingEventArgs e)
		{
			if (OnGroupLuckyKing == null)
			{
				return;
			}

			await OnGroupLuckyKing.Invoke(sender, e);
		}

		public event EventHandlerAsync<GroupMemberHonorChangeEventArgs>? OnGroupMemberHonorChange;

		async Task IBotContext.InvokeOnGroupMemberHonorChange(object sender, GroupMemberHonorChangeEventArgs e)
		{
			if (OnGroupMemberHonorChange == null)
			{
				return;
			}

			await OnGroupMemberHonorChange.Invoke(sender, e);
		}

		public event EventHandlerAsync<InputStatusEventArgs>? OnInputStatus;

		async Task IBotContext.InvokeOnInputStatus(object sender, InputStatusEventArgs e)
		{
			if (OnInputStatus == null)
			{
				return;
			}

			await OnInputStatus.Invoke(sender, e);
		}

		public event EventHandlerAsync<FriendAddRequestEventArgs>? OnFriendAddRequest;

		async Task IBotContext.InvokeOnFriendAddRequest(object sender, FriendAddRequestEventArgs e)
		{
			if (OnFriendAddRequest == null)
			{
				return;
			}

			await OnFriendAddRequest.Invoke(sender, e);
		}

		public event EventHandlerAsync<GroupAddRequestEventArgs>? OnGroupAddRequest;

		async Task IBotContext.InvokeOnGroupAddRequest(object sender, GroupAddRequestEventArgs e)
		{
			if (OnGroupAddRequest == null)
			{
				return;
			}

			await OnGroupAddRequest.Invoke(sender, e);
		}
	}
}
