using Makabaka.API;
using Makabaka.Messages;
using System.Threading;
using System.Threading.Tasks;

namespace Makabaka.Events
{
	/// <summary>
	/// 私聊消息事件参数
	/// </summary>
	public class PrivateMessageEventArgs : MessageEventArgs, IReply
	{
		/// <summary>
		/// 消息子类型
		/// </summary>
		public PrivateMessageEventType SubType { get; set; }

		/// <summary>
		/// 消息 ID
		/// </summary>
		public long MessageId { get; set; }

		/// <summary>
		/// 发送者 QQ 号
		/// </summary>
		public long UserId { get; set; }

		/// <summary>
		/// 消息内容
		/// </summary>
		public Message Message { get; set; } = [];

		/// <summary>
		/// 原始消息内容
		/// </summary>
		public string RawMessage { get; set; } = string.Empty;

		/// <summary>
		/// 字体
		/// </summary>
		public long Font { get; set; }

		/// <summary>
		/// 发送人信息
		/// </summary>
		public PrivateMessageSenderInfo Sender { get; set; } = new();

		/// <inheritdoc/>
		public Task<APIResponse<MessageIdResponseData>> ReplyAsync(
			Message message,
			bool autoEscape = false,
			CancellationToken cancellationToken = default
			)
		{
			return Context.SendPrivateMessageAsync(Sender.UserId, message, autoEscape, cancellationToken);
		}
	}
}
