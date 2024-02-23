using Makabaka.Models.Messages;
using Makabaka.Models.Senders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.API.Responses
{
	/// <summary>
	/// 消息信息
	/// </summary>
	public class MessageInfo
	{
		/// <summary>
		/// 发送时间
		/// </summary>
		[JsonProperty("time")]
		public int Time { get; set; }

		/// <summary>
		/// 消息类型
		/// </summary>
		[JsonProperty("message_type")]
		public string MessageType { get; set; }

		/// <summary>
		/// 消息 ID
		/// </summary>
		[JsonProperty("message_id")]
		public long MessageId { get; set; }

		/// <summary>
		/// 消息真实 ID
		/// </summary>
		[JsonProperty("real_id")]
		public int RealId { get; set; }

		/// <summary>
		/// 发送人信息
		/// </summary>
		[JsonProperty("sender")]
		public Sender Sender { get; set; }

		/// <summary>
		/// 消息内容
		/// </summary>
		[JsonProperty("message")]
		public Message Message { get; set; }
	}
}
