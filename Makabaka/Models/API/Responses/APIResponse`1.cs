using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.API.Responses
{
	/// <summary>
	/// API响应
	/// </summary>
	/// <typeparam name="T">"Data"属性的类型</typeparam>
	public class APIResponse<T> : APIResponse
	{
		/// <summary>
		/// 响应<a href="https://github.com/botuniverse/onebot-11/blob/master/communication/README.md">数据</a>
		/// </summary>
		[JsonProperty("data")]
		public T Data { get; internal set; }

		/// <summary>
		/// 隐式自动转换"Data"属性
		/// </summary>
		/// <param name="response">API响应</param>
		public static implicit operator T(APIResponse<T> response)
		{
			return response.Data;
		}
	}
}
