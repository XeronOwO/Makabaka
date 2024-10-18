namespace Makabaka.Events
{
	/// <summary>
	/// 好友添加事件参数
	/// </summary>
	public class FriendAddEventArgs : NoticeEventArgs
	{
		/// <summary>
		/// 新添加好友 QQ 号
		/// </summary>
		public long UserId { get; set; }
	}
}
