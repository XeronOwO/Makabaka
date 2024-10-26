using Makabaka.Messages;

namespace Makabaka.API
{
	/// <summary>
	/// 发送群消息请求参数
	/// </summary>
	/// <param name="GroupId">群号</param>
	/// <param name="Message">要发送的内容</param>
	public record class SendGroupMessageRequestParams(
		long GroupId,
		Message Message
		);
}
