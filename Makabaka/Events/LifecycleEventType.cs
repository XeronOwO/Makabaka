namespace Makabaka.Events
{
	/// <summary>
	/// 生命周期事件类型
	/// </summary>
	public enum LifecycleEventType
	{
		/// <summary>
		/// OneBot 启用
		/// </summary>
		Enable,

		/// <summary>
		/// OneBot 禁用
		/// </summary>
		Disable,

		/// <summary>
		/// WebSocket 连接成功
		/// </summary>
		Connect,
	}
}
