using Makabaka.Utils;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Makabaka.Messages
{
	/// <summary>
	/// 消息 JSON 转换器
	/// </summary>
	/// <param name="logger">日志</param>
	public class MessageJsonConverter(ILogger<MessageJsonConverter> logger) : JsonConverter<Message>
	{
		private static readonly Dictionary<string, TypeInfo> _segmentTypeMap;

		static MessageJsonConverter()
		{
			_segmentTypeMap = [];

			var types = typeof(TextData).Assembly.GetTypes();
			foreach (var type in types)
			{
				var attribute = type.GetCustomAttribute<SegmentAttribute?>();
				if (attribute == null)
				{
					continue;
				}
				var typeName = attribute.Type.ToSerializedString();
				_segmentTypeMap[typeName] = type.GetTypeInfo();
			}
		}

		/// <inheritdoc/>
		public override Message? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			using var jsonDocument = JsonDocument.ParseValue(ref reader);
			var jsonMessage = jsonDocument.RootElement;

			return jsonMessage.ValueKind switch
			{
				JsonValueKind.Array => ReadMessageFromJsonArray(jsonMessage, options),
				JsonValueKind.String => ReadMessageFromCqCodeString(jsonMessage, options),
				_ => throw new JsonException($"[{nameof(MessageJsonConverter)}] Unsupported json \"<root>\" value kind {jsonMessage.ValueKind}."),
			};
		}

		private Message ReadMessageFromJsonArray(JsonElement jsonMessage, JsonSerializerOptions options)
		{
			var message = new Message();
			var segmentIndex = 0;

			foreach (var jsonSegment in jsonMessage.EnumerateArray())
			{
				var segment = ReadSegmentFromJsonObject(jsonSegment, segmentIndex, options)
					?? throw new JsonException($"[{nameof(MessageJsonConverter)}] Failed to deserialize json \"<root>[{segmentIndex}]\" into segment.");
				message.Add(segment);
				++segmentIndex;
			}

			return message;
		}

		private Segment? ReadSegmentFromJsonObject(JsonElement jsonSegment, int segmentIndex, JsonSerializerOptions options)
		{
			var type = jsonSegment.GetProperty("type").GetString() ?? throw new JsonException($"[{nameof(MessageJsonConverter)}] Expected json \"<root>[{segmentIndex}].type\" value kind {JsonValueKind.String}, but got {JsonValueKind.Null}.");
			if (!_segmentTypeMap.TryGetValue(type, out var typeInfo))
			{
				logger.LogWarning(SR.UnsupportedSegmentType, type);
				return jsonSegment.Deserialize<UnsupportedSegment>(options);
			}

			return (Segment?)jsonSegment.Deserialize(typeInfo, options);
		}

		private Message ReadMessageFromCqCodeString(JsonElement jsonMessage, JsonSerializerOptions options)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc/>
		public override void Write(Utf8JsonWriter writer, Message value, JsonSerializerOptions options)
		{
			writer.WriteStartArray();
			foreach (var segment in value)
			{
				JsonSerializer.Serialize(writer, segment, segment.GetType(), options);
			}
			writer.WriteEndArray();
		}
	}
}
