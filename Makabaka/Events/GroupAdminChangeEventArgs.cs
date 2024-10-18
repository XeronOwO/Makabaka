namespace Makabaka.Events
{
	/// <summary>
	/// 群管理员变动事件参数
	/// </summary>
	public class GroupAdminChangeEventArgs : NoticeEventArgs
	{
		/// <summary>
		/// 事件子类型，分别表示设置和取消管理员
		/// </summary>
		public GroupAdminChangeEventType SubType { get; set; }

		/// <summary>
		/// 群号
		/// </summary>
		public long GroupId { get; set; }

		/// <summary>
		/// 管理员 QQ 号
		/// </summary>
		public long UserId { get; set; }
	}
}
