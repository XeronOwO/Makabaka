using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.Metrics;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Makabaka
{
	/// <summary>
	/// Makabaka应用构建器
	/// </summary>
	public sealed class MakabakaAppBuilder : IHostApplicationBuilder
	{
		private readonly HostApplicationBuilder _hostApplicationBuilder;

		/// <summary>
		/// 创建Makabaka应用构建器
		/// </summary>
		public MakabakaAppBuilder()
			: this(null)
		{
		}

		/// <summary>
		/// 通过命令行参数创建Makabaka应用构建器
		/// </summary>
		public MakabakaAppBuilder(string[]? args)
		{
			_hostApplicationBuilder = new(args);
			Services.AddMakabaka();
		}

		IDictionary<object, object> IHostApplicationBuilder.Properties => ((IHostApplicationBuilder)_hostApplicationBuilder).Properties;

		/// <inheritdoc/>
		public ConfigurationManager Configuration => _hostApplicationBuilder.Configuration;

		IConfigurationManager IHostApplicationBuilder.Configuration => Configuration;

		/// <inheritdoc/>
		public IHostEnvironment Environment => _hostApplicationBuilder.Environment;

		/// <inheritdoc/>
		public ILoggingBuilder Logging => _hostApplicationBuilder.Logging;

		/// <inheritdoc/>
		public IMetricsBuilder Metrics => _hostApplicationBuilder.Metrics;

		/// <inheritdoc/>
		public IServiceCollection Services => _hostApplicationBuilder.Services;

		/// <inheritdoc/>
		public void ConfigureContainer<TContainerBuilder>(IServiceProviderFactory<TContainerBuilder> factory, Action<TContainerBuilder>? configure = null)
			where TContainerBuilder : notnull
			=> _hostApplicationBuilder.ConfigureContainer(factory, configure);

		/// <summary>
		/// 构建Makabaka应用
		/// </summary>
		/// <returns>Makabaka应用</returns>
		public MakabakaApp Build()
			=> new(_hostApplicationBuilder.Build());
	}
}
