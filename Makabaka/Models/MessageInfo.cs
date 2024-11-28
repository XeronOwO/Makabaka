using Makabaka.Events;
using Makabaka.Messages;
using System;

namespace Makabaka.Models
{
	/// <summary>
	/// 消息信息
	/// </summary>
	public class MessageInfo
	{
		/// <summary>
		/// 发送时间
		/// </summary>
		public DateTime Time { get; set; }

		/// <summary>
		/// 消息类型
		/// </summary>
		public MessageEventType MessageType { get; set; }

		/// <summary>
		/// 消息 ID
		/// </summary>
		public ulong MessageId { get; set; }

		/// <summary>
		/// 消息真实 ID
		/// </summary>
		public ulong RealId { get; set; }

		/// <summary>
		/// 发送人信息
		/// </summary>
		public MessageSenderInfo Sender { get; set; } = new();

		/// <summary>
		/// 消息内容
		/// </summary>
		public Message Message { get; set; } = [];
	}
}
