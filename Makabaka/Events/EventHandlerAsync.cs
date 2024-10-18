using System;
using System.Threading.Tasks;

namespace Makabaka.Events
{
	/// <summary>
	/// 异步事件处理程序
	/// </summary>
	/// <param name="sender">事件发送者</param>
	/// <param name="e">事件参数</param>
	/// <returns>异步任务</returns>
	public delegate Task EventHandlerAsync(object sender, EventArgs e);

	/// <summary>
	/// 异步事件处理程序
	/// </summary>
	/// <typeparam name="TEventArgs">事件参数类型</typeparam>
	/// <param name="sender">事件发送者</param>
	/// <param name="e">事件参数</param>
	/// <returns>异步任务</returns>
	public delegate Task EventHandlerAsync<TEventArgs>(object sender, TEventArgs e)
		where TEventArgs : EventArgs;
}
