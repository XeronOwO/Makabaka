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
		/// 当使用HttpPost时，为<a href="https://github.com/botuniverse/onebot-11/blob/master/communication/http-post.md#%E7%AD%BE%E5%90%8D">签名密钥</a><br/>
		/// 否则为<a href="https://github.com/botuniverse/onebot-11/blob/master/communication/authorization.md">鉴权令牌</a>
		/// </summary>
		public string AccessToken { get; set; }
	}
}
