using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Configurations
{
	/// <summary>
	/// 基础服务配置
	/// </summary>
	public abstract class ServiceConfig
	{
		/// <summary>
		/// 服务器地址<br/>
		/// 例如：127.0.0.1
		/// </summary>
		public string Host { get; set; }

		/// <summary>
		/// 服务器端口
		/// </summary>
		public int Port { get; set; }

		/// <summary>
		/// 鉴权令牌<br/>
		/// 详见：<a href="https://github.com/botuniverse/onebot-11/blob/master/communication/authorization.md">https://github.com/botuniverse/onebot-11/blob/master/communication/authorization.md</a>
		/// </summary>
		public string AccessToken { get; set; }
	}
}
