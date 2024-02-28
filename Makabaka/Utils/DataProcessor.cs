using Makabaka.Services;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Makabaka.Network;
using Makabaka.Models.EventArgs;

namespace Makabaka.Utils
{
	/// <summary>
	/// 数据处理器，用于处理接收的消息，并发送相应的事件
	/// </summary>
	internal class DataProcessor
	{
		#region 构造函数与基本数据

		private readonly IService _service;

		private readonly ISession _session;

		public DataProcessor(IService service, ISession session)
		{
			_service = service;
			_session = session;

			_postTypeMap = new()
			{
				{ "meta_event", ProcessMeta },
				{ "message", ProcessMessage },
				{ "request", ProcessRequest },
				{ "notice", ProcessNotice },
			};
			_metaEventTypeMap = new()
			{
				{ "lifecycle", ProcessMetaLifeCycle },
				{ "heartbeat", ProcessHeartbeat },
			};
			_messageTypeMap = new()
			{
				{ "group", ProcessMessageGroup },
				{ "private", ProcessMessagePrivate },
			};
			_requestTypeMap = new()
			{
				{ "friend", ProcessRequestAddFriend },
				{ "group", ProcessRequestGroupRequest },
			};
			_noticeTypeMap = new()
			{
				{ "group_admin", ProcessNoticeGroupAdminChange },
				{ "group_decrease", ProcessNoticeGroupMemberDecrease },
				{ "group_increase", ProcessNoticeGroupMemberIncrease },
				{ "group_ban", ProcessNoticeGroupMute },
				{ "friend_add", ProcessNoticeFriendAdd },
				{ "group_recall", ProcessNoticeGroupRecallMessage },
				{ "friend_recall", ProcessNoticeFriendRecallMessage },
			};
		}

		#endregion

		#region 数据处理

		private delegate void ProcessDelegate(string data, JObject json);

		public void Process(string data)
		{
			var json = JObject.Parse(data);
			if (json.ContainsKey("post_type"))
			{
				ProcessPost(data, json);
			}
			else if (json.ContainsKey("status"))
			{
				ProcessAPIResponse(data, json);
			}
		}

		#region Post

		private readonly Dictionary<string, ProcessDelegate> _postTypeMap;

		private void ProcessPost(string data, JObject json)
		{
			var post_type = (string)json["post_type"] ?? throw new Exception("post_type为null");

			if (_postTypeMap.TryGetValue(post_type, out var method))
			{
				method.Invoke(data, json);
			}
			else
			{
				throw new Exception($"不支持的post_type：{post_type}");
			}
		}

		#region 元事件

		private readonly Dictionary<string, ProcessDelegate> _metaEventTypeMap;

		private void ProcessMeta(string data, JObject json)
		{
			var meta_event_type = (string)json["meta_event_type"] ?? throw new Exception("meta_event_type为null");

			if (_metaEventTypeMap.TryGetValue(meta_event_type, out var method))
			{
				method.Invoke(data, json);
			}
			else
			{
				throw new Exception($"不支持的meta_event_type：{meta_event_type}");
			}
		}

		private void ProcessMetaLifeCycle(string data, JObject _)
		{
			var e = JsonConvert.DeserializeObject<LifeCycleEventArgs>(data);
			e.Session = _session;
			_service.SendLifeCycleEvent(e);
		}

		private void ProcessHeartbeat(string data, JObject _)
		{
			var e = JsonConvert.DeserializeObject<HeartbeatEventArgs>(data);
			e.Session = _session;
			_service.SendHeartbeatEvent(e);
		}

		#endregion

		#region 消息事件

		private readonly Dictionary<string, ProcessDelegate> _messageTypeMap;

		private void ProcessMessage(string data, JObject json)
		{
			var message_type = (string)json["message_type"] ?? throw new Exception("message_type为null");

			if (_messageTypeMap.TryGetValue(message_type, out var method))
			{
				method.Invoke(data, json);
			}
			else
			{
				throw new Exception($"不支持的message_type：{message_type}");
			}
		}

		private void ProcessMessageGroup(string data, JObject _)
		{
			var e = JsonConvert.DeserializeObject<GroupMessageEventArgs>(data);
			e.Session = _session;
			e.Message.PostProcessMessage();
			_service.SendGroupMessageEvent(e);
		}

		private void ProcessMessagePrivate(string data, JObject _)
		{
			var e = JsonConvert.DeserializeObject<PrivateMessageEventArgs>(data);
			e.Session = _session;
			e.Message.PostProcessMessage();
			_service.SendPrivateMessageEvent(e);
		}

		#endregion

		#region 请求事件

		private readonly Dictionary<string, ProcessDelegate> _requestTypeMap;

		private void ProcessRequest(string data, JObject json)
		{
			var request_type = (string)json["request_type"] ?? throw new Exception("request_type为null");

			if (_requestTypeMap.TryGetValue(request_type, out var method))
			{
				method.Invoke(data, json);
			}
			else
			{
				throw new Exception($"不支持的request_type：{request_type}");
			}
		}

		private void ProcessRequestAddFriend(string data, JObject _)
		{
			var e = JsonConvert.DeserializeObject<AddFriendRequestEventArgs>(data);
			e.Session = _session;
			_service.SendAddFriendRequestEvent(e);
		}

		private void ProcessRequestGroupRequest(string data, JObject _)
		{
			var e = JsonConvert.DeserializeObject<GroupRequestEventArgs>(data);
			e.Session = _session;
			_service.SendGroupRequestEvent(e);
		}

		#endregion

		#region 通知事件

		private readonly Dictionary<string, ProcessDelegate> _noticeTypeMap;

		private void ProcessNotice(string data, JObject json)
		{
			var notice_type = (string)json["notice_type"] ?? throw new Exception("notice_type为null");

			if (_noticeTypeMap.TryGetValue(notice_type, out var method))
			{
				method.Invoke(data, json);
			}
			else
			{
				throw new Exception($"不支持的notice_type：{notice_type}");
			}
		}

		private void ProcessNoticeGroupAdminChange(string data, JObject _)
		{
			var e = JsonConvert.DeserializeObject<GroupAdminChangedEventArgs>(data);
			e.Session = _session;
			_service.SendGroupAdminChangedEvent(e);
		}

		private void ProcessNoticeGroupMemberDecrease(string data, JObject _)
		{
			var e = JsonConvert.DeserializeObject<GroupMemberDecreaseEventArgs>(data);
			e.Session = _session;
			_service.SendGroupMemberDecreaseEvent(e);
		}

		private void ProcessNoticeGroupMemberIncrease(string data, JObject _)
		{
			var e = JsonConvert.DeserializeObject<GroupMemberIncreaseEventArgs>(data);
			e.Session = _session;
			_service.SendGroupMemberIncreaseEvent(e);
		}

		private void ProcessNoticeGroupMute(string data, JObject _)
		{
			var e = JsonConvert.DeserializeObject<GroupMuteEventArgs>(data);
			e.Session = _session;
			_service.SendGroupMuteEvent(e);
		}

		private void ProcessNoticeFriendAdd(string data, JObject _)
		{
			var e = JsonConvert.DeserializeObject<FriendAddEventArgs>(data);
			e.Session = _session;
			_service.SendFriendAddEvent(e);
		}

		private void ProcessNoticeGroupRecallMessage(string data, JObject _)
		{
			var e = JsonConvert.DeserializeObject<GroupRecallMessageEventArgs>(data);
			e.Session = _session;
			_service.SendGroupRecallMessageEvent(e);
		}

		private void ProcessNoticeFriendRecallMessage(string data, JObject _)
		{
			var e = JsonConvert.DeserializeObject<FriendRecallMessageEventArgs>(data);
			e.Session = _session;
			_service.SendFriendRecallMessageEvent(e);
		}

		#endregion

		#endregion

		#region API响应

		private void ProcessAPIResponse(string data, JObject json)
		{
			if (!json.TryGetValue("retcode", out JToken jretcode))
			{
				throw new Exception("retcode为null");
			}
			var retcode = (int)jretcode;
			var echo = (string)json["echo"] ?? throw new Exception("echo为null");

			_session.OnAPIResponse(data, json, retcode, echo);
		}

		#endregion

		#endregion
	}
}
