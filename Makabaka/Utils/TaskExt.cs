using System.Threading;
using System.Threading.Tasks;

namespace Makabaka.Utils
{
	internal static class TaskExt
	{
		public static async Task WithCancellationToken(this Task task, CancellationToken cancellationToken)
		{
			var cancellationTask = Task.Delay(Timeout.Infinite, cancellationToken);
			var completedTask = await Task.WhenAny(task, cancellationTask);

			if (completedTask == cancellationTask)
			{
				cancellationToken.ThrowIfCancellationRequested();
			}

			await task; // 确保任务完成或抛出异常
		}

		public static async Task<T> WithCancellationToken<T>(this Task<T> task, CancellationToken cancellationToken)
		{
			var cancellationTask = Task.Delay(Timeout.Infinite, cancellationToken);
			var completedTask = await Task.WhenAny(task, cancellationTask);

			if (completedTask == cancellationTask)
			{
				cancellationToken.ThrowIfCancellationRequested();
			}

			return await task; // 确保任务完成或抛出异常
		}
	}
}
