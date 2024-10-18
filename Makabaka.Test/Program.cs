using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Makabaka.Test
{
	internal partial class Program
	{
		private static ILogger<Program> _logger = null!;

		static void Main(string[] args)
		{
			var builder = new MakabakaAppBuilder(args);
			var app = builder.Build();

			_logger = app.Services.GetRequiredService<ILogger<Program>>();
			app.BotContext.OnLifecycle += OnLifecycle;
			app.BotContext.OnHeartbeat += OnHeartbeat;
			app.BotContext.OnPrivateMessage += OnPrivateMessage;
			app.BotContext.OnGroupMessage += OnGroupMessage;

			app.Run();
		}
	}
}
