using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.API.Responses
{
	/// <summary>
	/// 消息ID信息
	/// </summary>
	public class MessageIdInfo
	{
		/// <summary>
		/// 消息 ID
		/// </summary>
		[JsonProperty("message_id")]
		public long MessageId { get; internal set; }
	}
}
