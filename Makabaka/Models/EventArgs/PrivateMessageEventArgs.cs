using Makabaka.Models.API.Responses;
using Makabaka.Models.Messages;
using Makabaka.Models.Senders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Makabaka.Models.EventArgs
{
	/// <summary>
	/// <a href="https://github.com/botuniverse/onebot-11/blob/master/event/message.md#%E7%A7%81%E8%81%8A%E6%B6%88%E6%81%AF">私聊消息</a>事件参数
	/// </summary>
	public class PrivateMessageEventArgs : MessageEventArgs, IReply
	{
		/// <summary>
		/// 消息 ID
		/// </summary>
		[JsonProperty("message_id")]
		public long MessageId { get; internal set; }

		/// <summary>
		/// 发送者 QQ 号
		/// </summary>
		[JsonProperty("user_id")]
		public long UserId { get; internal set; }

		/// <summary>
		/// 消息内容
		/// </summary>
		[JsonProperty("message")]
		public Message Message { get; internal set; }

		/// <summary>
		/// 原始消息内容
		/// </summary>
		[JsonProperty("raw_message")]
		public string RawMessage { get; internal set; }

		/// <summary>
		/// 字体
		/// </summary>
		[JsonProperty("font")]
		public int Font { get; internal set; }

		/// <summary>
		/// 发送人信息
		/// </summary>
		[JsonProperty("sender")]
		public Sender Sender { get; internal set; }

		/// <inheritdoc/>
		public Task<APIResponse<MessageIdInfo>> ReplyAsync(Message message)
		{
			return Session.SendPrivateMessageAsync(UserId, message);
		}
	}
}
