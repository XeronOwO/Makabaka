namespace Makabaka.Events
{
	/// <summary>
	/// 群成员减少事件参数
	/// </summary>
	public class GroupMemberDecreaseEventArgs : NoticeEventArgs
	{
		/// <summary>
		/// 事件子类型，分别表示主动退群、成员被踢、登录号被踢
		/// </summary>
		public GroupAdminChangeEventType SubType { get; set; }

		/// <summary>
		/// 群号
		/// </summary>
		public long GroupId { get; set; }

		/// <summary>
		/// 操作者 QQ 号（如果是主动退群，则和 user_id 相同）
		/// </summary>
		public long OperatorId { get; set; }

		/// <summary>
		/// 离开者 QQ 号
		/// </summary>
		public long UserId { get; set; }
	}
}
