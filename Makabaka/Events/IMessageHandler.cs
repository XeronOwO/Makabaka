using Makabaka.API;
using Makabaka.Messages;
using Makabaka.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Makabaka.Events
{
	/// <summary>
	/// 消息处理器接口
	/// </summary>
	public interface IMessageHandler
	{
		/// <summary>
		/// 快速回复
		/// </summary>
		/// <param name="message">要回复的消息</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>消息 ID 数据 API 响应</returns>
		Task<APIResponse<MessageIdInfo>> ReplyAsync(
			Message message,
			CancellationToken cancellationToken = default
			);
	}
}
