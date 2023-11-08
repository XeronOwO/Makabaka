using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.EventArgs
{
	/// <summary>
	/// <a href="https://github.com/botuniverse/onebot-11/blob/master/event/request.md">请求事件</a>事件参数
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
