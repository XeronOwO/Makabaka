using Makabaka.API;
using System.Threading;
using System.Threading.Tasks;

namespace Makabaka.Events
{
	/// <summary>
	/// 加群请求／邀请事件参数
	/// </summary>
	public class GroupAddRequestEventArgs : RequestEventArgs, IRequestHandler
	{
		/// <summary>
		/// 请求子类型，分别表示加群请求、邀请登录号入群
		/// </summary>
		public GroupAddRequestEventType SubType { get; set; }

		/// <summary>
		/// 群号
		/// </summary>
		public long GroupId { get; set; }

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
			return Context.SetGroupAddRequestAsync(Flag, SubType, true, null, cancellationToken);
		}

		/// <inheritdoc/>
		public Task<APIResponse> RejectAsync(CancellationToken cancellationToken = default)
		{
			return Context.SetGroupAddRequestAsync(Flag, SubType, false, null, cancellationToken);
		}

		/// <summary>
		/// 拒绝请求
		/// </summary>
		/// <param name="reason">拒绝理由</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>API 响应异步任务</returns>
		public Task<APIResponse> RejectAsync(string reason, CancellationToken cancellationToken = default)
		{
			return Context.SetGroupAddRequestAsync(Flag, SubType, false, reason, cancellationToken);
		}
	}
}
