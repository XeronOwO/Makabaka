using System;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Makabaka.Utils
{
	/// <summary>
	/// 枚举扩展方法
	/// </summary>
	public static class EnumSnakeCaseLowerExt
	{
		/// <summary>
		/// 转换为序列化的字符串
		/// </summary>
		/// <param name="enum">枚举</param>
		/// <returns>序列化的字符串</returns>
		public static string ToSerializedString(this Enum @enum)
		{
			var type = @enum.GetType();
			var jsonPropertyNameAttribute = type.GetCustomAttribute<JsonPropertyNameAttribute?>();
			if (jsonPropertyNameAttribute != null)
			{
				return jsonPropertyNameAttribute.Name;
			}

			return JsonNamingPolicy.SnakeCaseLower.ConvertName(@enum.ToString());
		}
	}
}
