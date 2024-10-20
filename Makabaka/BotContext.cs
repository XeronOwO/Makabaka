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
			var networkContextFactory = GetNetworkContextFactory();
			if (networkContextFactory == null)
			{
				logger.LogError(SR.ConfigureNetworkServiceFailed);
				return;
			}

			var networkContext = networkContextFactory.Invoke();
			await networkContext.RunAsync(cancellationToken);
		}

		private Func<INetworkContext>? GetNetworkContextFactory()
		{
			if (TryGetForwardWebSocketContextFactory(out var factory))
			{
				return factory;
			}

			return null;
		}

		private bool TryGetForwardWebSocketContextFactory(out Func<INetworkContext>? factory)
		{
			factory = null;

			var enabled = configuration.GetValue("Bot:ForwardWebSocket:Enabled", false);
			if (!enabled)
			{
				return false;
			}

			factory = () => services.GetRequiredService<ForwardWebSocketContext>();
			return true;
		}
	}
}
