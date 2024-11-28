using System;

namespace Makabaka.Events
{
	/// <summary>
	/// 推送事件信息
	/// </summary>
	public class PostEventArgs : ContextEventArgs
	{
		/// <summary>
		/// 事件发生的时间戳
		/// </summary>
		public DateTime Time { get; set; }

		/// <summary>
		/// 收到事件的机器人 QQ 号
		/// </summary>
		public ulong SelfId { get; set; }

		/// <summary>
		/// 事件类型
		/// </summary>
		public PostEventType PostType { get; set; }
	}
}
