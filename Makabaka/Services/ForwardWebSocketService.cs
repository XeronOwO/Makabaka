using Makabaka.Configurations;
using Makabaka.Network;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Makabaka.Services
{
	internal class ForwardWebSocketService : WebSocketService
	{
		#region 基本信息与构造函数

		private readonly ForwardWebSocketServiceConfig _config;

		private readonly CancellationTokenSource _cts;

		public ForwardWebSocketService(ForwardWebSocketServiceConfig config)
		{
			_config = config;
			_cts = new();
		}

		#endregion

		#region 接口实现

		private bool _running = false;

		private Task _loopTask;

		public override async Task StartAsync()
		{
			if (_running)
			{
				throw new Exception("正向WebSocket服务已在运行，无法重复启动服务");
			}
			_running = true;

			Log.Information($"正在启动正向WebSocket服务");
			_loopTask = LoopAsync();

			await Task.CompletedTask;
		}

		private ForwardWebSocketContext _ws;

		public override List<IWebSocketContext> Sessions { get; } = new();

		private async Task LoopAsync()
		{
			try
			{
				while (_config.AutoReconnect)
				{
					_ws = new ForwardWebSocketContext(this, _config);
					Sessions.Add(_ws);
					await _ws.StartAndWaitAsync(_cts.Token);

					Sessions.Remove(_ws);
					_ws.Dispose();
					_ws = null;

					if (_config.AutoReconnect)
					{
						await Task.Delay(_config.ReconnectInterval, _cts.Token);
					}
				}
			}
			catch (OperationCanceledException)
			{
			}
			catch (Exception)
			{
				throw;
			}
		}

		public override async Task WaitAsync()
		{
			await _loopTask;
		}

		public override async Task StopAsync()
		{
			if (!_running)
			{
				throw new Exception("正向WebSocket服务未运行，无法停止服务");
			}

			var guid = _ws.Guid;
			Log.Information($"正在停止正向WebSocket[{guid}]");
			_cts.Cancel();
			await _loopTask;
			Log.Information($"已停止正向WebSocket[{guid}]");

			_running = false;
		}

		#endregion
	}
}
