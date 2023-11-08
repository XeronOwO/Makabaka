using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.EventArgs
{
	/// <summary>
	/// 请求事件参数
	/// </summary>
	public class RequestEventArgs : PostEventArgs
	{
		/// <summary>
		/// 请求类型
		/// </summary>
		[JsonProperty("request_type")]
		public string RequestType { get; internal set; }
	}
}
