using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Configurations
{
	/// <summary>
	/// 反向WebSocket服务配置
	/// </summary>
	public class ReverseWebSocketServiceConfig : ServiceConfig
	{
		/// <summary>
		/// API请求超时时间（ms）<br/>
		/// 默认值：5000
		/// </summary>
		public int APITimeout { get; set; } = 5000;

		/// <summary>
		/// Universal路径<br/>
		/// 默认值：/ws/
		/// </summary>
		public string UniversalPath { get; set; } = "/ws/";
	}
}
