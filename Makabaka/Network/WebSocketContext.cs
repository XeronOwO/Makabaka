using Makabaka.Messages;
using Makabaka.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Makabaka.Network
{
	internal abstract partial class WebSocketContext(
		IBotContext botContext,
		IServiceProvider services
		) : INetworkContext
	{
		private readonly ILogger<WebSocketContext> _logger = services.GetRequiredService<ILogger<WebSocketContext>>();

		protected readonly JsonSerializerOptions _jsonSerializerOptions = new()
		{
			PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
			Converters =
			{
				services.GetRequiredService<JsonConverter<Message>>(),
				services.GetRequiredService<JsonConverter<SexType>>(),
				new JsonStringEnumConverter(JsonNamingPolicy.SnakeCaseLower),
			},
		};

		public abstract Task RunAsync(CancellationToken cancellationToken);
	}
}
