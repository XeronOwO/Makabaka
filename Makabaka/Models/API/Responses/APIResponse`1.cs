using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.API.Responses
{
	public class APIResponse<T> : APIResponse
	{
		/// <summary>
		/// 响应<a href="https://github.com/botuniverse/onebot-11/blob/master/communication/README.md">数据</a>
		/// </summary>
		[JsonProperty("data")]
		public T Data { get; internal set; }

		public static implicit operator T(APIResponse<T> response)
		{
			return response.Data;
		}
	}
}
