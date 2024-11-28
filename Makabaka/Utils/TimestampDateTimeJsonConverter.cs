using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Makabaka.Utils
{
	/// <summary>
	/// 时间戳日期时间 JSON 转换器
	/// </summary>
	public class TimestampDateTimeJsonConverter : JsonConverter<DateTime>
	{
		/// <inheritdoc/>
		public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType != JsonTokenType.Number)
			{
				throw new JsonException($"[{nameof(TimestampDateTimeJsonConverter)}] Unexpected token type {reader.TokenType}.");
			}

			var timestamp = reader.GetInt64();
			var utcDateTime = DateTime.UnixEpoch.AddSeconds(timestamp);
			var localDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, TimeZoneInfo.Local);
			return localDateTime;
		}

		/// <inheritdoc/>
		public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
		{
			var localDateTime = value;
			var utcDateTime = TimeZoneInfo.ConvertTimeToUtc(localDateTime, TimeZoneInfo.Local);
			var timestamp = (ulong)(utcDateTime - DateTime.UnixEpoch).TotalSeconds;
			writer.WriteNumberValue(timestamp);
		}
	}
}
