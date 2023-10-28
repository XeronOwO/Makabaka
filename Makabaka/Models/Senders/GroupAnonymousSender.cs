using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.Senders
{
	/// <summary>
	/// <a href="https://github.com/botuniverse/onebot-11/blob/master/event/message.md#%E7%BE%A4%E6%B6%88%E6%81%AF">群消息</a>匿名发送者
	/// </summary>
	public class GroupAnonymousSender
	{
		/// <summary>
		/// 匿名用户 ID
		/// </summary>
		[JsonProperty("id")]
		public long Id { get; set; }

		/// <summary>
		/// 匿名用户名称
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 匿名用户 flag，在调用禁言 API 时需要传入
		/// </summary>
		[JsonProperty("flag")]
		public string Flag { get; set; }
	}
}
