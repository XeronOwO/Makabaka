namespace Makabaka.Events
{
	/// <summary>
	/// 通知事件参数
	/// </summary>
	public class NotifyEventArgs : NoticeEventArgs
	{
		/// <summary>
		/// 提示类型
		/// </summary>
		public NotifyEventType SubType { get; set; }
	}
}
