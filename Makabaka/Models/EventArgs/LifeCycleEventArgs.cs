using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.EventArgs
{
	/// <summary>
	/// <a href="https://github.com/botuniverse/onebot-11/blob/master/event/meta.md#%E7%94%9F%E5%91%BD%E5%91%A8%E6%9C%9F">生命周期</a>事件参数
	/// </summary>
	public class LifeCycleEventArgs : MetaEventArgs
	{
		/// <summary>
		/// <a href="https://github.com/botuniverse/onebot-11/blob/master/event/meta.md#%E7%94%9F%E5%91%BD%E5%91%A8%E6%9C%9F">事件子类型</a>，分别表示 OneBot 启用、停用、WebSocket 连接成功
		/// </summary>
		[JsonProperty("sub_type")]
		public string SubType { get; internal set; }
	}
}
