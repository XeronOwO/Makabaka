using Makabaka.Network;
using Makabaka.Services;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Makabaka.Models.FastActions;
using System.Threading.Tasks;
using Makabaka.Models.EventArgs;

namespace Makabaka.Utils
{
	/// <summary>
	/// 被动数据处理器，用于处理接收的被动消息，并发送相应的事件
	/// </summary>
	internal class PassiveDataProcessor
	{
		#region 构造函数与基本数据

		private readonly IPassiveService _service;

		public PassiveDataProcessor(IPassiveService service)
		{
			_service = service;

			_postTypeMap = new()
			{
				{ "meta_event", ProcessMeta },
				{ "message", ProcessMessage },
				{ "request", ProcessRequest },
			};
			_metaEventTypeMap = new()
			{
				{ "lifecycle", ProcessMetaLifeCycle },
				{ "heartbeat", ProcessHeartbeat },
			};
			_messageTypeMap = new()
			{
				{ "group", ProcessMessageGroup },
			};
			_requestTypeMap = new()
			{
				{ "friend", ProcessRequestAddFriend },
			};
		}

		#endregion

		#region 数据处理

		private delegate Task<IFastAction> ProcessDelegate(string data, JObject json);

		public async Task<IFastAction> Process(string data)
		{
			var json = JObject.Parse(data);
			if (json.ContainsKey("post_type"))
			{
				return await ProcessPost(data, json);
			}

			return null;
		}

		#region Post

		private readonly Dictionary<string, ProcessDelegate> _postTypeMap;

		private async Task<IFastAction> ProcessPost(string data, JObject json)
		{
			var post_type = (string)json["post_type"] ?? throw new Exception("post_type为null");

			if (_postTypeMap.TryGetValue(post_type, out var method))
			{
				return await method.Invoke(data, json);
			}
			else
			{
				throw new Exception($"不支持的post_type：{post_type}");
			}
		}

		#region 元事件

		private readonly Dictionary<string, ProcessDelegate> _metaEventTypeMap;

		private async Task<IFastAction> ProcessMeta(string data, JObject json)
		{
			var meta_event_type = (string)json["meta_event_type"] ?? throw new Exception("meta_event_type为null");

			if (_metaEventTypeMap.TryGetValue(meta_event_type, out var method))
			{
				return await method.Invoke(data, json);
			}
			else
			{
				throw new Exception($"不支持的meta_event_type：{meta_event_type}");
			}
		}

		private async Task<IFastAction> ProcessMetaLifeCycle(string data, JObject _)
		{
			var e = JsonConvert.DeserializeObject<LifeCycleEventArgs>(data);
			e.Session = null;
			return await _service.SendLifeCycleEvent(e);
		}

		private async Task<IFastAction> ProcessHeartbeat(string data, JObject _)
		{
			var e = JsonConvert.DeserializeObject<HeartbeatEventArgs>(data);
			e.Session = null;
			return await _service.SendHeartbeatEvent(e);
		}

		#endregion

		#region 消息事件

		private readonly Dictionary<string, ProcessDelegate> _messageTypeMap;

		private async Task<IFastAction> ProcessMessage(string data, JObject json)
		{
			var message_type = (string)json["message_type"] ?? throw new Exception("message_type为null");

			if (_messageTypeMap.TryGetValue(message_type, out var method))
			{
				return await method.Invoke(data, json);
			}
			else
			{
				throw new Exception($"不支持的message_type：{message_type}");
			}
		}

		private async Task<IFastAction> ProcessMessageGroup(string data, JObject _)
		{
			var e = JsonConvert.DeserializeObject<GroupMessageEventArgs>(data);
			e.Session = null;
			e.Message.PostProcessMessage();
			return await _service.SendGroupMessageEvent(e);
		}

		#endregion

		#region 请求事件

		private readonly Dictionary<string, ProcessDelegate> _requestTypeMap;

		private async Task<IFastAction> ProcessRequest(string data, JObject json)
		{
			var request_type = (string)json["request_type"] ?? throw new Exception("request_type为null");

			if (_requestTypeMap.TryGetValue(request_type, out var method))
			{
				return await method.Invoke(data, json);
			}
			else
			{
				throw new Exception($"不支持的request_type：{request_type}");
			}
		}

		private async Task<IFastAction> ProcessRequestAddFriend(string data, JObject _)
		{
			var e = JsonConvert.DeserializeObject<AddFriendRequestEventArgs>(data);
			e.Session = null;
			return await _service.SendAddFriendRequestEvent(e);
		}

		#endregion

		#endregion

		#endregion
	}
}
