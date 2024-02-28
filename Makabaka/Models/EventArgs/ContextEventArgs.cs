using Makabaka.Network;
using Newtonsoft.Json;

namespace Makabaka.Models.EventArgs
{
	/// <summary>
	/// 上下文事件参数
	/// </summary>
	public class ContextEventArgs : System.EventArgs
	{
		/// <summary>
		/// 上下文，提供一些功能操作<br/>
		/// <strong>注意：使用HttpPost时，此项永远为null；其它情况下永远不为null</strong>
		/// </summary>
		[JsonIgnore]
		public IWebSocketContext Context { get; internal set; }
	}
}
