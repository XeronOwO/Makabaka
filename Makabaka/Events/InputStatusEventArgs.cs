namespace Makabaka.Events
{
	/// <summary>
	/// 输入状态事件参数
	/// </summary>
	public class InputStatusEventArgs : NotifyEventArgs
	{
		/// <summary>
		/// 状态文本<br/>例如：对方正在输入...
		/// </summary>
		public string StatusText { get; set; } = string.Empty;

		/// <summary>
		/// 事件类型
		/// </summary>
		public int EventType { get; set; }

		/// <summary>
		/// 用户 QQ 号
		/// </summary>
		public ulong UserId { get; set; }

		/// <summary>
		/// 群号
		/// </summary>
		public ulong GroupId { get; set; }
	}
}
