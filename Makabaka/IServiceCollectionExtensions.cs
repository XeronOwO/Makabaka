using Makabaka.Messages;
using Makabaka.Models;
using Makabaka.Network;
using Makabaka.Utils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Text.Json.Serialization;

namespace Makabaka
{
	/// <summary>
	/// IServiceCollection 扩展
	/// </summary>
	public static class IServiceCollectionExtensions
	{
		/// <summary>
		/// 添加 Makabaka 服务
		/// </summary>
		public static IServiceCollection AddMakabaka(this IServiceCollection services)
		{
			services.AddHostedService<BotContext>();
			services.AddSingleton<IBotContext, BotContext>(
				provider => provider.GetServices<IHostedService>().OfType<BotContext>().First()
				);
			services.AddSingleton<JsonConverter<Message>, MessageJsonConverter>();
			services.AddSingleton<JsonConverter<SexType>, SexTypeJsonConverter>();
			services.AddSingleton<JsonConverter<DateTime>, TimestampDateTimeJsonConverter>();
			services.AddTransient<ForwardWebSocketContext>();
			services.AddTransient<ReverseWebSocketContext>();

			return services;
		}
	}
}
