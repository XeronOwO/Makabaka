namespace Makabaka.Events
{
	/// <summary>
	/// 群消息撤回事件参数
	/// </summary>
	public class GroupMessageWithdrawEventArgs : NoticeEventArgs
	{
		/// <summary>
		/// 群号
		/// </summary>
		public long GroupId { get; set; }

		/// <summary>
		/// 消息发送者 QQ 号
		/// </summary>
		public long UserId { get; set; }

		/// <summary>
		/// 操作者 QQ 号
		/// </summary>
		public long OperatorId { get; set; }

		/// <summary>
		/// 被撤回的消息 ID
		/// </summary>
		public long MessageId { get; set; }
	}
}
