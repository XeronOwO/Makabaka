using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Configurations
{
	/// <summary>
	/// HttpPost服务配置
	/// </summary>
	public class HttpPostServiceConfig : ServiceConfig
	{
		/// <summary>
		/// Universal路径<br/>
		/// 默认值：/
		/// </summary>
		public string UniversalPath { get; set; } = "/";
	}
}
