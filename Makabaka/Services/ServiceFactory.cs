using Makabaka.Configurations;
using System;

namespace Makabaka.Services
{
	/// <summary>
	/// 服务工厂，用于创建服务。<br/>
	/// 例如：正向WebSocket服务
	/// </summary>
	public static class ServiceFactory
	{
		/// <summary>
		/// 创建正向WebSocket服务
		/// </summary>
		/// <param name="config">配置信息</param>
		/// <returns>服务接口</returns>
		public static IService CreateForwardWebSocketService(ForwardWebSocketServiceConfig config)
		{
			return new ForwardWebSocketService(config);
		}

		/// <summary>
		/// 创建反向WebSocket服务
		/// </summary>
		/// <param name="config">配置信息</param>
		/// <returns>服务接口</returns>
		public static IService CreateReverseWebSocketService(ReverseWebSocketServiceConfig config)
		{
			return new ReverseWebSocketService(config);
		}
	}
}
