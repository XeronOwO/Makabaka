using System.Threading;
using System.Threading.Tasks;

namespace Makabaka.Network
{
	/// <summary>
	/// 网络上下文接口。正向WebSocket、反向WebSocket、正向HTTP、反向HTTP等网络上下文均实现此接口。
	/// </summary>
	public interface INetworkContext
	{
		/// <summary>
		/// 异步运行
		/// </summary>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>异步任务</returns>
		Task RunAsync(CancellationToken cancellationToken);
	}
}
