namespace Makabaka.Events
{
	/// <summary>
	/// 群成员禁言事件参数
	/// </summary>
	public class GroupMemberMuteEventArgs : NoticeEventArgs
	{
		/// <summary>
		/// 事件子类型，分别表示禁言、解除禁言
		/// </summary>
		public GroupMemberMuteEventType SubType { get; set; }

		/// <summary>
		/// 群号
		/// </summary>
		public long GroupId { get; set; }

		/// <summary>
		/// 操作者 QQ 号
		/// </summary>
		public long OperatorId { get; set; }

		/// <summary>
		/// 被禁言 QQ 号
		/// </summary>
		public long UserId { get; set; }

		/// <summary>
		/// 禁言时长，单位秒
		/// </summary>
		public long Duration { get; set; }
	}
}
