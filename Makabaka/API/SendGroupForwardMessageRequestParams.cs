using Makabaka.Messages;

namespace Makabaka.API
{
	/// <summary>
	/// 发送群聊转发消息请求参数
	/// </summary>
	/// <param name="GroupId">群号</param>
	/// <param name="Messages">转发消息</param>
	public record class SendGroupForwardMessageRequestParams(
		ulong GroupId,
		Message Messages
		) : SendForwardMessageRequestParams(Messages)
	{
	}
}
