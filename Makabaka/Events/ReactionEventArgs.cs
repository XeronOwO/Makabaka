namespace Makabaka.Events
{
	/// <summary>
	/// 群表情回应事件参数
	/// </summary>
	public class ReactionEventArgs : NoticeEventArgs
	{
		/// <summary>
		/// 群号
		/// </summary>
		public ulong GroupId { get; set; }

		/// <summary>
		/// 消息 ID
		/// </summary>
		public long MessageId { get; set; }

		/// <summary>
		/// 操作者 QQ 号
		/// </summary>
		public ulong OperatorId { get; set; }

		/// <summary>
		/// 子类型
		/// </summary>
		public ReactionEventType SubType { get; set; }

		/// <summary>
		/// 代码
		/// </summary>
		public string Code { get; set; } = string.Empty;

		/// <summary>
		/// 数量
		/// </summary>
		public int Count { get; set; }
	}
}
