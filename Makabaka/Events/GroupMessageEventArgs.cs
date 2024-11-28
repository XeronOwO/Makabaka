using Makabaka.API;
using Makabaka.Messages;
using Makabaka.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Makabaka.Events
{
	/// <summary>
	/// 群消息事件参数
	/// </summary>
	public class GroupMessageEventArgs : MessageEventArgs, IMessageHandler
	{
		/// <summary>
		/// 消息子类型
		/// </summary>
		public GroupMessageEventType SubType { get; set; }

		/// <summary>
		/// 消息 ID
		/// </summary>
		public ulong MessageId { get; set; }

		/// <summary>
		/// 群号
		/// </summary>
		public ulong GroupId { get; set; }

		/// <summary>
		/// 发送者 QQ 号
		/// </summary>
		public ulong UserId { get; set; }

		/// <summary>
		/// 匿名信息，如果不是匿名消息则为 null
		/// </summary>
		public GroupMessageAnonymousSenderInfo? Anonymous { get; set; }

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
		public ulong Font { get; set; }

		/// <summary>
		/// 发送人信息
		/// </summary>
		public GroupMessageSenderInfo? Sender { get; set; }

		/// <inheritdoc/>
		public Task<APIResponse<MessageIdInfo>> ReplyAsync(
			Message message,
			CancellationToken cancellationToken = default
			)
		{
			return Context.SendGroupMessageAsync(GroupId, message, cancellationToken);
		}
	}
}
