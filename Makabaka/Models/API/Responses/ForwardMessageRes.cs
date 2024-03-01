using Makabaka.Models.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.API.Responses
{
	/// <summary>
	/// 合并转发消息信息
	/// </summary>
	public class ForwardMessageRes
	{
		/// <summary>
		/// 消息内容，使用 <a href="https://github.com/botuniverse/onebot-11/blob/master/message/array.md">消息的数组格式</a> 表示，数组中的消息段全部为 <a href="https://github.com/botuniverse/onebot-11/blob/master/message/segment.md#%E5%90%88%E5%B9%B6%E8%BD%AC%E5%8F%91%E8%87%AA%E5%AE%9A%E4%B9%89%E8%8A%82%E7%82%B9">node 消息段</a>
		/// </summary>
		[JsonProperty("message")]
		public Message Message { get; set; }
	}
}
