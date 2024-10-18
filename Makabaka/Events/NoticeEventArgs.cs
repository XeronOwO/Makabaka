namespace Makabaka.Events
{
	/// <summary>
	/// 通知事件参数
	/// </summary>
	public class NoticeEventArgs : PostEventArgs
	{
		/// <summary>
		/// 通知类型
		/// </summary>
		public NoticeEventType NoticeType { get; set; }
	}
}
