using Makabaka.Events;
using Microsoft.Extensions.Logging;

namespace Makabaka.Test
{
	internal partial class Program
	{
		private static bool _firstHeartbeat = true;

		private static Task OnHeartbeat(object sender, HeartbeatEventArgs e)
		{
			if (_firstHeartbeat)
			{
				_firstHeartbeat = false;
				_logger.LogInformation(nameof(OnHeartbeat));
			}
			return Task.CompletedTask;
		}

		private static Task OnLifecycle(object sender, LifecycleEventArgs e)
		{
			_logger.LogInformation(nameof(OnLifecycle));
			return Task.CompletedTask;
		}
	}
}
