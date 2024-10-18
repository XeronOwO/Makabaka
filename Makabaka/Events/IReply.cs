using Makabaka.API;
using Makabaka.Messages;
using System.Threading;
using System.Threading.Tasks;

namespace Makabaka.Events
{
	/// <summary>
	/// 快速回复接口
	/// </summary>
	public interface IReply
	{
		/// <summary>
		/// 快速回复
		/// </summary>
		/// <param name="message">要回复的消息</param>
		/// <param name="autoEscape">消息内容是否作为纯文本发送（即不解析 CQ 码），只在 message 字段是字符串时有效</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>消息 ID 数据 API 响应</returns>
		Task<APIResponse<MessageIdResponseData>> ReplyAsync(
			Message message,
			bool autoEscape = false,
			CancellationToken cancellationToken = default
			);
	}
}
