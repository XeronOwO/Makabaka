using Makabaka.Events;
using Makabaka.Utils;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Makabaka.Network
{
	internal partial class WebSocketContext
	{
		public interface IMatch
		{
			bool Matches(JsonNode node);
		}

		[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
		public class MetaAttribute(MetaEventType type) : Attribute, IMatch
		{
			public bool Matches(JsonNode node)
			{
				var postType = node["post_type"];
				if (postType == null)
				{
					return false;
				}
				if (postType.GetValueKind() != JsonValueKind.String)
				{
					return false;
				}
				if (postType.GetValue<string>() != PostEventType.MetaEvent.ToSerializedString())
				{
					return false;
				}

				var metaEventType = node["meta_event_type"];
				if (metaEventType == null)
				{
					return false;
				}
				if (metaEventType.GetValueKind() != JsonValueKind.String)
				{
					return false;
				}
				if (metaEventType.GetValue<string>() != type.ToSerializedString())
				{
					return false;
				}

				return true;
			}

			public override string ToString()
			{
				return $"meta={type}";
			}
		}

		[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
		public class MessageAttribute(MessageEventType type) : Attribute, IMatch
		{
			public bool Matches(JsonNode node)
			{
				var postType = node["post_type"];
				if (postType == null)
				{
					return false;
				}
				if (postType.GetValueKind() != JsonValueKind.String)
				{
					return false;
				}
				if (postType.GetValue<string>() != PostEventType.Message.ToSerializedString())
				{
					return false;
				}

				var messageType = node["message_type"];
				if (messageType == null)
				{
					return false;
				}
				if (messageType.GetValueKind() != JsonValueKind.String)
				{
					return false;
				}
				if (messageType.GetValue<string>() != type.ToSerializedString())
				{
					return false;
				}

				return true;
			}

			public override string ToString()
			{
				return $"message={type}";
			}
		}

		[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
		public class NoticeAttribute(NoticeEventType type) : Attribute, IMatch
		{
			public bool Matches(JsonNode node)
			{
				var postType = node["post_type"];
				if (postType == null)
				{
					return false;
				}
				if (postType.GetValueKind() != JsonValueKind.String)
				{
					return false;
				}
				if (postType.GetValue<string>() != PostEventType.Notice.ToSerializedString())
				{
					return false;
				}

				var noticeType = node["notice_type"];
				if (noticeType == null)
				{
					return false;
				}
				if (noticeType.GetValueKind() != JsonValueKind.String)
				{
					return false;
				}
				if (noticeType.GetValue<string>() != type.ToSerializedString())
				{
					return false;
				}

				return true;
			}

			public override string ToString()
			{
				return $"notice={type}";
			}
		}

        [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
        public class NotifyAttribute(NotifyEventType type) : Attribute, IMatch
		{
			public bool Matches(JsonNode node)
			{
				var postType = node["post_type"];
				if (postType == null)
				{
					return false;
				}
				if (postType.GetValueKind() != JsonValueKind.String)
				{
					return false;
				}
				if (postType.GetValue<string>() != PostEventType.Notice.ToSerializedString())
				{
					return false;
				}

				var noticeType = node["notice_type"];
				if (noticeType == null)
				{
					return false;
				}
				if (noticeType.GetValueKind() != JsonValueKind.String)
				{
					return false;
				}
				if (noticeType.GetValue<string>() != NoticeEventType.Notify.ToSerializedString())
				{
					return false;
				}

				var subType = node["sub_type"];
				if (subType == null)
				{
					return false;
				}
				if (subType.GetValueKind() != JsonValueKind.String)
				{
					return false;
				}
				if (subType.GetValue<string>() != type.ToSerializedString())
				{
					return false;
				}

				return true;
			}

			public override string ToString()
			{
				return $"notify={type}";
			}
		}

		[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
		public class RequestAttribute(RequestEventType type) : Attribute, IMatch
		{
			public bool Matches(JsonNode node)
			{
				var postType = node["post_type"];
				if (postType == null)
				{
					return false;
				}
				if (postType.GetValueKind() != JsonValueKind.String)
				{
					return false;
				}
				if (postType.GetValue<string>() != PostEventType.Request.ToSerializedString())
				{
					return false;
				}

				var metaEventType = node["meta_event_type"];
				if (metaEventType == null)
				{
					return false;
				}
				if (metaEventType.GetValueKind() != JsonValueKind.String)
				{
					return false;
				}
				if (metaEventType.GetValue<string>() != type.ToSerializedString())
				{
					return false;
				}

				return true;
			}

			public override string ToString()
			{
				return $"request={type}";
			}
		}

		[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
		public class APIAttribute() : Attribute, IMatch
		{
			public bool Matches(JsonNode node)
			{
				var status = node["status"];
				if (status == null)
				{
					return false;
				}
				if (status.GetValueKind() != JsonValueKind.String)
				{
					return false;
				}

				var retcode = node["retcode"];
				if (retcode == null)
				{
					return false;
				}
				if (retcode.GetValueKind() != JsonValueKind.Number)
				{
					return false;
				}

				var echo = node["echo"];
				if (echo == null)
				{
					return false;
				}
				if (echo.GetValueKind() != JsonValueKind.String)
				{
					return false;
				}

				return true;
			}

			public override string ToString()
			{
				return "request=API";
			}
		}

        public delegate Task<bool> ProcessorDelegate(JsonNode node);

		private record class ProcessorInfo(IMatch Match, ProcessorDelegate Delegate);

		private readonly List<ProcessorInfo> _processors = [];

		public void RegisterProcessors()
		{
			_processors.Clear();

			var type = typeof(WebSocketContext);
			var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (var method in methods)
			{
				RegisterProcessor<MetaAttribute>(method);
				RegisterProcessor<MessageAttribute>(method);
				RegisterProcessor<NoticeAttribute>(method);
				RegisterProcessor<NotifyAttribute>(method);
				RegisterProcessor<RequestAttribute>(method);
				RegisterProcessor<APIAttribute>(method);
			}
		}

		private void RegisterProcessor<TAttribute>(MethodInfo method)
			where TAttribute : Attribute, IMatch
		{
			var attribute = method.GetCustomAttribute<TAttribute?>();
			if (attribute != null)
			{
				try
				{
					var @delegate = method.CreateDelegate(typeof(ProcessorDelegate), this);
					_processors.Add(new(attribute, (ProcessorDelegate)@delegate));
					_logger.LogDebug(SR.WebSocketProcessorRegister, attribute, method.Name);
				}
				catch (Exception e)
				{
					_logger.LogError(e, SR.WebSocketProcessorRegisterError, method);
				}
			}
		}

		public async Task<bool> TryProcessAsync(JsonNode node)
		{
			foreach (var processor in _processors)
			{
				if (processor.Match.Matches(node))
				{
					if (await processor.Delegate(node))
					{
						return true;
					}
				}
			}

			return false;
		}
	}
}
