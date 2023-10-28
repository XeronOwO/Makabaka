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
		/// WebSocket缓存长度<br/>
		/// 默认值：4096
		/// </summary>
		public int BufferLength { get; set; } = 4096;

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
		/// API请求超时时间（ms）<br/>
		/// 默认值：5000
		/// </summary>
		public int APITimeout { get; set; } = 5000;
	}
}
