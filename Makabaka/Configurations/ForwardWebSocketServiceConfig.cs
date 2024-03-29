using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Configurations
{
	/// <summary>
	/// 正向WebSocket服务配置
	/// </summary>
	public class ForwardWebSocketServiceConfig : ServiceConfig
	{
		/// <summary>
		/// 是否启用自动重连<br/>
		/// 默认值：true
		/// </summary>
		public bool AutoReconnect { get; set; } = true;

		/// <summary>
		/// 重连间隔（ms）<br/>
		/// 默认值：0
		/// </summary>
		public int ReconnectInterval { get; set; } = 0;

		/// <summary>
		/// 连接超时时间（s）<br/>
		/// 默认值：10
		/// </summary>
		public int ConnectTimeout { get; set; } = 10;

		/// <summary>
		/// API请求超时时间（ms）<br/>
		/// 默认值：10000
		/// </summary>
		public int APITimeout { get; set; } = 10000;
	}
}
