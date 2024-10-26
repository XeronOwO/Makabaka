using Makabaka.Network;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Makabaka
{
	internal partial class BotContext(
		ILogger<BotContext> logger,
		IConfiguration configuration,
		IServiceProvider services
		) : IHostedService, IBotContext
	{
		private readonly CancellationTokenSource _cancellationTokenSource = new();

		private Task _runningTask = Task.CompletedTask;

		private int ApiTimeout => configuration.GetValue("Bot:ForwardWebSocket:ApiTimeout", 10000);

		public Task StartAsync(CancellationToken cancellationToken)
		{
			logger.LogInformation(SR.StartingBot);

			_runningTask = Task.Run(() => RunAsync(_cancellationTokenSource.Token), cancellationToken);

			return Task.CompletedTask;
		}

		public Task StopAsync(CancellationToken cancellationToken)
		{
			logger.LogInformation(SR.StoppingBot);

			_cancellationTokenSource.Cancel();

			return Task.WhenAny(_runningTask, Task.Delay(Timeout.Infinite, cancellationToken));
		}

		private async Task RunAsync(CancellationToken cancellationToken)
		{
			var networkContext = GetNetworkContext();
			if (networkContext == null)
			{
				logger.LogError(SR.ConfigureNetworkServiceFailed);
				return;
			}

			await networkContext.RunAsync(cancellationToken);
		}

		private INetworkContext? GetNetworkContext()
		{
			return TryCreateForwardWebSocketContext();
		}

		private INetworkContext? TryCreateForwardWebSocketContext()
		{
			var enabled = configuration.GetValue("Bot:ForwardWebSocket:Enabled", false);
			if (!enabled)
			{
				return null;
			}

			return services.GetRequiredService<ForwardWebSocketContext>();
		}
	}
}
