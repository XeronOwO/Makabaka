using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Makabaka
{
	/// <summary>
	/// Makabaka应用
	/// </summary>
	/// <param name="host">通用主机接口</param>
	public class MakabakaApp(IHost host) : IHost
	{
		/// <inheritdoc/>
		public IServiceProvider Services => host.Services;

		/// <summary>
		/// 机器人上下文
		/// </summary>
		public IBotContext BotContext => Services.GetRequiredService<IBotContext>();

		/// <inheritdoc/>
		public void Dispose()
		{
			host.Dispose();
		}

		/// <inheritdoc/>
		public Task StartAsync(CancellationToken cancellationToken = default)
		{
			return host.StartAsync(cancellationToken);
		}

		/// <inheritdoc/>
		public Task StopAsync(CancellationToken cancellationToken = default)
		{
			return host.StopAsync(cancellationToken);
		}
	}
}
