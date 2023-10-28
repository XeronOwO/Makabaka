using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Makabaka.Exceptions;
using Newtonsoft.Json.Linq;

namespace Makabaka.Models.API.Responses
{
	/// <summary>
	/// <a href="https://github.com/botuniverse/onebot-11/blob/master/communication/README.md">API响应</a>
	/// </summary>
	public class APIResponse
	{
		/// <summary>
		/// 响应<a href="https://github.com/botuniverse/onebot-11/blob/master/communication/README.md">状态</a>
		/// </summary>
		[JsonProperty("status")]
		public string Status { get; internal set; }

		/// <summary>
		/// 响应<a href="https://github.com/botuniverse/onebot-11/blob/master/communication/README.md">返回值</a>
		/// </summary>
		[JsonProperty("retcode")]
		public int RetCode { get; internal set; }

		/// <summary>
		/// 响应是否成功
		/// </summary>
		[JsonIgnore]
		public bool Success => RetCode == 0;

		/// <summary>
		/// 响应<a href="https://github.com/botuniverse/onebot-11/blob/master/communication/README.md">唯一标识符</a>
		/// </summary>
		[JsonProperty("echo")]
		public string Echo { get; internal set; }

		/// <summary>
		/// 原Json信息<br/>
		/// 由于部分反序列化的内容可能存在信息缺失，故作保留
		/// </summary>
		[JsonIgnore]
		public JObject RawJson { get; internal set; }

		/// <summary>
		/// 确保响应成功
		/// </summary>
		/// <exception cref="APIResponseException"></exception>
		public void EnsureSuccess()
		{
			if (!Success)
			{
				throw new APIResponseException(Status, RetCode, Echo);
			}
		}

		public static APIResponse<T> GetFailedResponse<T>()
		{
			return new APIResponse<T>()
			{
				Status = "程序内部错误",
				RetCode = -1,
			};
		}
	}
}
