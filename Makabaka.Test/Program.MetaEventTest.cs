using Makabaka.Events;
using Microsoft.Extensions.Logging;

namespace Makabaka.Test
{
	internal partial class Program
	{
		private static Task OnHeartbeat(object sender, HeartbeatEventArgs e)
		{
			_logger.LogInformation(nameof(OnHeartbeat));
			return Task.CompletedTask;
		}

		private static Task OnLifecycle(object sender, LifecycleEventArgs e)
		{
			_logger.LogInformation(nameof(OnLifecycle));
			return Task.CompletedTask;
		}
	}
}
