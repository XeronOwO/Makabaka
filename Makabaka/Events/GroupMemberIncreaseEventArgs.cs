namespace Makabaka.Events
{
	/// <summary>
	/// 群成员增加
	/// </summary>
	public class GroupMemberIncreaseEventArgs : NoticeEventArgs
	{
		/// <summary>
		/// 事件子类型，分别表示管理员已同意入群、管理员邀请入群
		/// </summary>
		public GroupMemberIncreaseEventType SubType { get; set; }

		/// <summary>
		/// 群号
		/// </summary>
		public long GroupId { get; set; }

		/// <summary>
		/// 操作者 QQ 号
		/// </summary>
		public long OperatorId { get; set; }

		/// <summary>
		/// 加入者 QQ 号
		/// </summary>
		public long UserId { get; set; }
	}
}
