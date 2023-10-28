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
		/// 会话
		/// </summary>
		[JsonIgnore]
		public ISession Session { get; internal set; }
	}
}
