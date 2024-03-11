using Makabaka.Configurations;
using Makabaka.Models.API.Requests;
using Makabaka.Models.API.Responses;
using Makabaka.Models.Messages;
using Makabaka.Services;
using Makabaka.Utils;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WatsonWebsocket;

namespace Makabaka.Network
{
	internal class ReverseWebSocketContext : WebSocketContext, IDisposable
	{
		#region 构造函数与参数

		private readonly ReverseWebSocketServiceConfig _config;

		private readonly WatsonWsServer _ws;

		private readonly Guid _guid;

		public override Guid Guid => _guid;

		private readonly DataProcessor _dataProcessor;

		public ReverseWebSocketContext(ReverseWebSocketService service, WatsonWsServer ws, Guid guid, ReverseWebSocketServiceConfig config)
		{
			_ws = ws;
			_guid = guid;
			_dataProcessor = new(service, this);
			_config = config;
		}

		#endregion

		#region 主要功能

		public void ProcessData(Guid serviceGuid, string ipPort, string data)
		{
			try
			{
				_dataProcessor.Process(data);
			}
			catch (Exception e)
			{
				Log.Error(e, $"[{serviceGuid}][{ipPort}]处理数据时出现异常");
			}
		}

		#endregion

		#region API执行

		private class APIPromise
		{
			public CancellationTokenSource TokenSource { get; set; }

			public bool Success { get; set; } = false;

			public string Data { get; set; }

			public JObject Json { get; set; }
		}

		private readonly Dictionary<string, APIPromise> _apiPromises = new();

		public override async Task<APIResponse<TResult>> ExecuteAPIAsync<TResult>(string action, string echo)
		{
			try
			{
				// 发送请求
				var request = new APIRequest()
				{
					Action = action,
					Echo = echo,
				};
				var data = JsonConvert.SerializeObject(request);
				var bytes = Encoding.UTF8.GetBytes(data);

				Log.Debug($"[{_guid}]发送数据：{data}");
				var task = _ws.SendAsync(_guid, bytes, WebSocketMessageType.Text);

				// 等待响应
				var cts = new CancellationTokenSource();
				lock (_apiPromises)
				{
					_apiPromises[echo] = new() // 加入响应等待队列
					{
						TokenSource = cts,
					};
				}

				// 等待超时或者响应
				try
				{
					await Task.Delay(_config.APITimeout, cts.Token);
				}
				catch (OperationCanceledException)
				{
				}
				catch (Exception e)
				{
					Log.Error(e, $"[{_guid}]等待API响应时出现异常");
				}

				// 获取Promise
				APIPromise promise = null;
				lock (_apiPromises)
				{
					if (!_apiPromises.TryGetValue(echo, out promise))
					{
						Log.Warning($"[{_guid}]无法找到指定Echo的APIPromise：[{echo}]");
						return APIResponse.GetFailedResponse<TResult>();
					}
					_apiPromises.Remove(echo); // 从队列中移除
				}

				// 执行API失败了，也就是超时了
				if (!promise.Success)
				{
					Log.Warning($"[{_guid}]指定Echo的API请求超时：[{echo}]");
					return APIResponse.GetFailedResponse<TResult>(); ;
				}

				// 执行API成功
				var result = JsonConvert.DeserializeObject<APIResponse<TResult>>(promise.Data);
				result.RawJson = promise.Json;
				return result;
			}
			catch (OperationCanceledException)
			{
				Log.Information($"[{_guid}]发送数据操作被用户中断");
			}
			catch (Exception e)
			{
				Log.Error(e, $"[{_guid}]发送数据时出现异常");
			}
			return APIResponse.GetFailedResponse<TResult>();
		}

		public override async Task<APIResponse<TResult>> ExecuteAPIAsync<TResult, TParam>(string action, TParam @params, string echo)
		{
			try
			{
				// 发送请求
				var request = new APIRequest<TParam>()
				{
					Action = action,
					Params = @params,
					Echo = echo,
				};
				var data = JsonConvert.SerializeObject(request);
				var bytes = Encoding.UTF8.GetBytes(data);

				Log.Debug($"[{_guid}]发送数据：{data}");
				var task = _ws.SendAsync(_guid, bytes, WebSocketMessageType.Text);

				// 等待响应
				var cts = new CancellationTokenSource();
				lock (_apiPromises)
				{
					_apiPromises[echo] = new() // 加入响应等待队列
					{
						TokenSource = cts,
					};
				}

				// 等待超时或者响应
				try
				{
					await Task.Delay(_config.APITimeout, cts.Token);
				}
				catch (OperationCanceledException)
				{
				}
				catch (Exception e)
				{
					Log.Error(e, $"[{_guid}]等待API响应时出现异常");
				}

				// 获取Promise
				APIPromise promise = null;
				lock (_apiPromises)
				{
					if (!_apiPromises.TryGetValue(echo, out promise))
					{
						Log.Warning($"[{_guid}]无法找到指定Echo的APIPromise：[{echo}]");
						return APIResponse.GetFailedResponse<TResult>();
					}
					_apiPromises.Remove(echo); // 从队列中移除
				}

				// 执行API失败了
				if (!promise.Success)
				{
					Log.Warning($"[{_guid}]指定Echo的API请求失败：[{echo}]");
					return APIResponse.GetFailedResponse<TResult>(); ;
				}

				// 执行API成功
				var result = JsonConvert.DeserializeObject<APIResponse<TResult>>(promise.Data);
				result.RawJson = promise.Json;
				return result;
			}
			catch (OperationCanceledException)
			{
				Log.Information($"[{_guid}]发送数据操作被用户中断");
			}
			catch (Exception e)
			{
				Log.Error(e, $"[{_guid}]发送数据时出现异常");
			}
			return APIResponse.GetFailedResponse<TResult>();
		}

		public override void OnAPIResponse(string data, JObject json, int retcode, string echo)
		{
			APIPromise promise = null;
			lock (_apiPromises)
			{
				// 从响应等待队列中找到对应的APIPromise
				if (!_apiPromises.TryGetValue(echo, out promise))
				{
					return;
				}
			}

			// API完成
			promise.Success = retcode == 0;
			promise.Data = data;
			promise.Json = json;
			promise.TokenSource.Cancel(); // 打断等待
		}

		#endregion

		#region 释放

		private bool disposedValue;

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					_ws.Dispose();
				}

				disposedValue = true;
			}
		}

		~ReverseWebSocketContext()
		{
			Dispose(disposing: false);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		#endregion
	}
}
