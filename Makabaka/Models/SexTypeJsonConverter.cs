using Makabaka.Utils;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Makabaka.Models
{
	/// <summary>
	/// 性别类型 JSON 转换器
	/// </summary>
	public class SexTypeJsonConverter : JsonConverter<SexType>
	{
		/// <inheritdoc/>
		public override SexType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType != JsonTokenType.String)
			{
				throw new JsonException($"[{nameof(SexTypeJsonConverter)}] Unexpected token type {reader.TokenType}.");
			}

			var value = reader.GetString()!;
			return Enum.TryParse<SexType>(value, out var result) ? result : SexType.Unknown;
		}

		/// <inheritdoc/>
		public override void Write(Utf8JsonWriter writer, SexType value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToSerializedString());
		}
	}
}
