using Makabaka.Network;
using Makabaka.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.EventArgs
{
	/// <summary>
	/// 服务事件参数
	/// </summary>
	public class SessionEventArgs : System.EventArgs
	{
		/// <summary>
		/// 会话，提供一些功能操作<br/>
		/// <strong>注意：使用HttpPost时，此项永远为null；其它情况下永远不为null</strong>
		/// </summary>
		[JsonIgnore]
		public ISession Session { get; internal set; }
	}
}
