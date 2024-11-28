using Makabaka.Messages;

namespace Makabaka.API
{
	/// <summary>
	/// 发送私聊转发消息请求参数
	/// </summary>
	/// <param name="UserId">用户 ID</param>
	/// <param name="Messages">转发消息</param>
	public record class SendPrivateForwardMessageRequestParams(
		ulong UserId,
		Message Messages
		) : SendForwardMessageRequestParams(Messages)
	{
	}
}
