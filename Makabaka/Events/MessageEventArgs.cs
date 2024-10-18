namespace Makabaka.Events
{
	/// <summary>
	/// 消息事件参数
	/// </summary>
	public class MessageEventArgs : PostEventArgs
	{
		/// <summary>
		/// 消息类型
		/// </summary>
		public MessageEventType MessageType { get; set; }
	}
}
