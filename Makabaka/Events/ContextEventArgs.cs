using System;

namespace Makabaka.Events
{
	/// <summary>
	/// 上下文事件参数
	/// </summary>
	public class ContextEventArgs : EventArgs
	{
		/// <summary>
		/// 机器人上下文
		/// </summary>
		public IBotContext Context { get; internal set; } = null!;
	}
}
