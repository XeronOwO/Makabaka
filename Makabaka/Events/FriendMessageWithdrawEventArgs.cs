namespace Makabaka.Events
{
	/// <summary>
	/// 好友消息撤回事件参数
	/// </summary>
	public class FriendMessageWithdrawEventArgs : NoticeEventArgs
	{
		/// <summary>
		/// 好友 QQ 号
		/// </summary>
		public long UserId { get; set; }

		/// <summary>
		/// 被撤回的消息 ID
		/// </summary>
		public long MessageId { get; set; }
	}
}
