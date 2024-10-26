using Makabaka.Messages;

namespace Makabaka.API
{
	/// <summary>
	/// 发送私聊消息请求参数
	/// </summary>
	/// <param name="UserId">对方 QQ 号</param>
	/// <param name="Message">要发送的内容</param>
	public record class SendPrivateMessageRequestParams(
		long UserId,
		Message Message
		);
}
