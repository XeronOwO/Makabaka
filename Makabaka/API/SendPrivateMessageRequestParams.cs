using Makabaka.Messages;

namespace Makabaka.API
{
	/// <summary>
	/// 发送私聊消息请求参数
	/// </summary>
	/// <param name="UserId">对方 QQ 号</param>
	/// <param name="Message">要发送的内容</param>
	/// <param name="AutoEscape">消息内容是否作为纯文本发送（即不解析 CQ 码），只在 message 字段是字符串时有效</param>
	public record class SendPrivateMessageRequestParams(
		long UserId,
		Message Message,
		bool AutoEscape = false
		);
}
