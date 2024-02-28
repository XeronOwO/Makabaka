using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.API.Responses
{
	/// <summary>
	/// Onebot<a href="https://github.com/botuniverse/onebot-11/blob/master/api/public.md#get_version_info-%E8%8E%B7%E5%8F%96%E7%89%88%E6%9C%AC%E4%BF%A1%E6%81%AF">版本信息</a>
	/// </summary>
	public class VersionRes
	{
		/// <summary>
		/// 应用标识，如 mirai-native
		/// </summary>
		[JsonProperty("app_name")]
		public string AppName { get; set; }

		/// <summary>
		/// 应用版本，如 1.2.3
		/// </summary>
		[JsonProperty("app_version")]
		public string AppVersion { get; set; }

		/// <summary>
		/// OneBot 标准版本，如 v11
		/// </summary>
		[JsonProperty("protocol_version")]
		public string ProtocolVersion { get; set; }
	}
}
