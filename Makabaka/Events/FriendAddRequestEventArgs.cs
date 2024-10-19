using Makabaka.API;
using System.Threading;
using System.Threading.Tasks;

namespace Makabaka.Events
{
	/// <summary>
	/// 加好友请求事件参数
	/// </summary>
	public class FriendAddRequestEventArgs : RequestEventArgs, IRequestHandler
	{
		/// <summary>
		/// 发送请求的 QQ 号
		/// </summary>
		public long UserId { get; set; }

		/// <summary>
		/// 验证信息
		/// </summary>
		public string Comment { get; set; } = string.Empty;

		/// <summary>
		/// 请求 flag，在调用处理请求的 API 时需要传入
		/// </summary>
		public string Flag { get; set; } = string.Empty;

		/// <inheritdoc/>
		public Task<APIResponse> AcceptAsync(CancellationToken cancellationToken = default)
		{
			return Context.SetFriendAddRequestAsync(Flag, true, null, cancellationToken);
		}

		/// <summary>
		/// 同意请求
		/// </summary>
		/// <param name="remark">添加后的好友备注（仅在同意时有效）</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>API 响应异步任务</returns>
		public Task<APIResponse> AcceptAsync(string remark, CancellationToken cancellationToken = default)
		{
			return Context.SetFriendAddRequestAsync(Flag, true, remark, cancellationToken);
		}

		/// <inheritdoc/>
		public Task<APIResponse> RejectAsync(CancellationToken cancellationToken = default)
		{
			return Context.SetFriendAddRequestAsync(Flag, false, null, cancellationToken);
		}
	}
}
