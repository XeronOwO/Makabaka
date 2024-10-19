using Makabaka.API;
using System.Threading;
using System.Threading.Tasks;

namespace Makabaka.Events
{
	/// <summary>
	/// 请求处理器接口
	/// </summary>
	public interface IRequestHandler
	{
		/// <summary>
		/// 同意请求
		/// </summary>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>API 响应异步任务</returns>
		Task<APIResponse> AcceptAsync(CancellationToken cancellationToken = default);

		/// <summary>
		/// 拒绝请求
		/// </summary>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>API 响应异步任务</returns>
		Task<APIResponse> RejectAsync(CancellationToken cancellationToken = default);
	}
}
