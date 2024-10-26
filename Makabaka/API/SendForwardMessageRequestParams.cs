using Makabaka.Messages;

namespace Makabaka.API
{
	/// <summary>
	/// 发送转发消息请求参数
	/// </summary>
	/// <param name="Messages">转发消息</param>
	public record class SendForwardMessageRequestParams(
		Message Messages
		)
	{
	}
}
