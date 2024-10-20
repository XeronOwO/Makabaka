namespace Makabaka.Events
{
	/// <summary>
	/// 生命周期事件信息
	/// </summary>
	public class LifecycleEventArgs : MetaEventArgs
	{
		/// <summary>
		/// 事件子类型
		/// </summary>
		public LifecycleEventType SubType { get; set; }
	}
}
