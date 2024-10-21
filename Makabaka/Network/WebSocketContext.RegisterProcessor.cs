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

		public abstract class MatchAttribute : Attribute, IMatch
		{
			public abstract bool Matches(JsonNode node);

			protected bool MatchEnum<TEnum>(JsonNode node, string key, TEnum value)
				where TEnum : Enum
			{
				var postType = node[key];
				if (postType == null)
				{
					return false;
				}
				if (postType.GetValueKind() != JsonValueKind.String)
				{
					return false;
				}
				if (postType.GetValue<string>() != value.ToSerializedString())
				{
					return false;
				}

				return true;
			}
		}

		[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
		public class MetaAttribute(MetaEventType type) : MatchAttribute
		{
			public override bool Matches(JsonNode node)
			{
				if (!MatchEnum(node, "post_type", PostEventType.MetaEvent))
				{
					return false;
				}

				if (!MatchEnum(node, "meta_event_type", type))
				{
					return false;
				}

				return true;
			}

			public override string ToString()
			{
				return $"meta={type.ToSerializedString()}";
			}
		}

		[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
		public class MessageAttribute(MessageEventType type) : MatchAttribute
		{
			public override bool Matches(JsonNode node)
			{
				if (!MatchEnum(node, "post_type", PostEventType.Message))
				{
					return false;
				}

				if (!MatchEnum(node, "message_type", type))
				{
					return false;
				}

				return true;
			}

			public override string ToString()
			{
				return $"message={type.ToSerializedString()}";
			}
		}

		[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
		public class NoticeAttribute(NoticeEventType type) : MatchAttribute
		{
			public override bool Matches(JsonNode node)
			{
				if (!MatchEnum(node, "post_type", PostEventType.Notice))
				{
					return false;
				}

				if (!MatchEnum(node, "notice_type", type))
				{
					return false;
				}

				return true;
			}

			public override string ToString()
			{
				return $"notice={type.ToSerializedString()}";
			}
		}

		[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
		public class NotifyAttribute(NotifyEventType type) : MatchAttribute
		{
			public override bool Matches(JsonNode node)
			{
				if (!MatchEnum(node, "post_type", PostEventType.Notice))
				{
					return false;
				}

				if (!MatchEnum(node, "notice_type", NoticeEventType.Notify))
				{
					return false;
				}

				if (!MatchEnum(node, "sub_type", type))
				{
					return false;
				}

				return true;
			}

			public override string ToString()
			{
				return $"notify={type.ToSerializedString()}";
			}
		}

		[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
		public class RequestAttribute(RequestEventType type) : MatchAttribute
		{
			public override bool Matches(JsonNode node)
			{
				if (!MatchEnum(node, "post_type", PostEventType.Request))
				{
					return false;
				}

				if (!MatchEnum(node, "request_type", type))
				{
					return false;
				}

				return true;
			}

			public override string ToString()
			{
				return $"request={type.ToSerializedString()}";
			}
		}

		[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
		public class APIAttribute() : MatchAttribute
		{
			public override bool Matches(JsonNode node)
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
				return "API";
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
			where TAttribute : MatchAttribute
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
