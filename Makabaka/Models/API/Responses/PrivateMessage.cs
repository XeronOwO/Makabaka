﻿using Makabaka.Models.Messages;
using Makabaka.Models.Senders;
using Newtonsoft.Json;

namespace Makabaka.Models.API.Responses
{
	/// <summary>
	/// 私聊消息
	/// </summary>
	public class PrivateMessage
	{
		/// <summary>
		/// 消息类型
		/// </summary>
		[JsonProperty("message_type")]
		public string MessageType { get; set; }

		/// <summary>
		/// 子类型
		/// </summary>
		[JsonProperty("sub_type")]
		public string SubType { get; set; }

		/// <summary>
		/// 消息Id
		/// </summary>
		[JsonProperty("message_id")]
		public long MessageId { get; set; }

		/// <summary>
		/// 用户ID
		/// </summary>
		[JsonProperty("user_id")]
		public long UserId { get; set; }

		/// <summary>
		/// 消息
		/// </summary>
		[JsonProperty("message")]
		public Message Message { get; set; }

		/// <summary>
		/// 原始消息
		/// </summary>
		[JsonProperty("raw_message")]
		public string RawMessage { get; set; }

		/// <summary>
		/// 字体
		/// </summary>
		[JsonProperty("font")]
		public int Font { get; set; }

		/// <summary>
		/// 发送者
		/// </summary>
		[JsonProperty("sender")]
		public Sender Sender { get; set; }
	}
}
