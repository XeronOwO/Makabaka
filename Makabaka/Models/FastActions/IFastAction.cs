using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Makabaka.Models.FastActions
{
	/// <summary>
	/// 快速操作接口
	/// </summary>
	public interface IFastAction
	{

	}

	/// <summary>
	/// 快速操作事件处理器
	/// </summary>
	/// <typeparam name="TEventArgs">事件参数类型</typeparam>
	/// <param name="sender">发送者</param>
	/// <param name="e">事件参数</param>
	/// <returns>快速操作</returns>
	public delegate Task<IFastAction> FastActionEventHandler<TEventArgs>(object sender, TEventArgs e);
}
