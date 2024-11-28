using Makabaka.Events;
using Makabaka.Messages;

namespace Makabaka.API
{
	/// <summary>
	/// 发送消息请求参数
	/// </summary>
	/// <param name="MessageType">消息类型</param>
	/// <param name="Message">要发送的内容</param>
	/// <param name="UserId">对方 QQ 号（消息类型为 <see cref="MessageEventType.Private"/> 时需要）</param>
	/// <param name="GroupId">群号（消息类型为 <see cref="MessageEventType.Group"/> 时需要）</param>
	public record class SendMessageRequestParams(
		MessageEventType MessageType,
		Message Message,
		ulong UserId = 0,
		ulong GroupId = 0
		)
	{
	}
}
