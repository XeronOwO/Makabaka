using Makabaka.Events;
using System.Threading.Tasks;

namespace Makabaka
{
	/// <summary>
	/// 机器人上下文接口
	/// </summary>
	public partial interface IBotContext
	{
		/// <summary>
		/// 当生命周期事件发生时触发
		/// </summary>
		event EventHandlerAsync<LifecycleEventArgs> OnLifecycle;

		internal Task InvokeOnLifecycle(object sender, LifecycleEventArgs e);

		/// <summary>
		/// 当心跳事件发生时触发
		/// </summary>
		event EventHandlerAsync<HeartbeatEventArgs> OnHeartbeat;

		internal Task InvokeOnHeartbeat(object sender, HeartbeatEventArgs e);

		/// <summary>
		/// 当私信消息事件发生时触发
		/// </summary>
		event EventHandlerAsync<PrivateMessageEventArgs> OnPrivateMessage;

		internal Task InvokeOnPrivateMessage(object sender, PrivateMessageEventArgs e);

		/// <summary>
		/// 当群消息事件发生时触发
		/// </summary>
		event EventHandlerAsync<GroupMessageEventArgs> OnGroupMessage;

		internal Task InvokeOnGroupMessage(object sender, GroupMessageEventArgs e);

		/// <summary>
		/// 当群文件上传事件发生时触发
		/// </summary>
		event EventHandlerAsync<GroupFileUploadEventArgs> OnGroupFileUpload;

		internal Task InvokeOnGroupFileUploadMessage(object sender, GroupFileUploadEventArgs e);

		/// <summary>
		/// 当群管理员变动事件发生时触发
		/// </summary>
		event EventHandlerAsync<GroupAdminChangeEventArgs> OnGroupAdminChange;

		internal Task InvokeOnGroupAdminChange(object sender, GroupAdminChangeEventArgs e);

		/// <summary>
		/// 当群成员减少事件发生时触发
		/// </summary>
		event EventHandlerAsync<GroupMemberDecreaseEventArgs>? OnGroupMemberDecrease;

		internal Task InvokeOnGroupMemberDecrease(object sender, GroupMemberDecreaseEventArgs e);

		/// <summary>
		/// 当群成员增加事件发生时触发
		/// </summary>
		event EventHandlerAsync<GroupMemberIncreaseEventArgs>? OnGroupMemberIncrease;

		internal Task InvokeOnGroupMemberIncrease(object sender, GroupMemberIncreaseEventArgs e);

		/// <summary>
		/// 当群成员禁言事件发生时触发
		/// </summary>
		event EventHandlerAsync<GroupMemberMuteEventArgs>? OnGroupMemberMute;

		internal Task InvokeOnGroupMemberMute(object sender, GroupMemberMuteEventArgs e);

		/// <summary>
		/// 当群成员解除禁言事件发生时触发
		/// </summary>
		event EventHandlerAsync<FriendAddEventArgs>? OnFriendAdd;

		internal Task InvokeOnFriendAdd(object sender, FriendAddEventArgs e);

		/// <summary>
		/// 当群消息撤回事件发生时触发
		/// </summary>
		event EventHandlerAsync<GroupMessageWithdrawEventArgs>? OnGroupMessageWithdraw;

		internal Task InvokeOnGroupMessageWithdraw(object sender, GroupMessageWithdrawEventArgs e);

		/// <summary>
		/// 当好友消息撤回事件发生时触发
		/// </summary>
		event EventHandlerAsync<FriendMessageWithdrawEventArgs>? OnFriendMessageWithdraw;

		internal Task InvokeOnFriendMessageWithdraw(object sender, FriendMessageWithdrawEventArgs e);

		/// <summary>
		/// 当群内戳一戳事件发生时触发
		/// </summary>
		event EventHandlerAsync<GroupPokeEventArgs>? OnGroupPoke;

		internal Task InvokeOnGroupPoke(object sender, GroupPokeEventArgs e);

		/// <summary>
		/// 当表情回应事件发生时触发
		/// </summary>
		event EventHandlerAsync<ReactionEventArgs>? OnGroupReaction;

		internal Task InvokeOnGroupReaction(object sender, ReactionEventArgs e);

		/// <summary>
		/// 当群红包运气王事件发生时触发
		/// </summary>
		event EventHandlerAsync<GroupLuckyKingEventArgs>? OnGroupLuckyKing;

		internal Task InvokeOnGroupLuckyKing(object sender, GroupLuckyKingEventArgs e);

		/// <summary>
		/// 当群成员荣誉变动事件发生时触发
		/// </summary>
		event EventHandlerAsync<GroupMemberHonorChangeEventArgs>? OnGroupMemberHonorChange;

		internal Task InvokeOnGroupMemberHonorChange(object sender, GroupMemberHonorChangeEventArgs e);

		/// <summary>
		/// [NapCatQQ] 当好友输入状态事件发生时触发
		/// </summary>
		event EventHandlerAsync<InputStatusEventArgs>? OnInputStatus;

		internal Task InvokeOnInputStatus(object sender, InputStatusEventArgs e);

		/// <summary>
		/// 当加好友请求事件发生时触发
		/// </summary>
		event EventHandlerAsync<FriendAddRequestEventArgs>? OnFriendAddRequest;

		internal Task InvokeOnFriendAddRequest(object sender, FriendAddRequestEventArgs e);

		/// <summary>
		/// 当加群请求／邀请事件发生时触发
		/// </summary>
		event EventHandlerAsync<GroupAddRequestEventArgs>? OnGroupAddRequest;

		internal Task InvokeOnGroupAddRequest(object sender, GroupAddRequestEventArgs e);
	}
}
