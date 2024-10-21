using System;
using System.Linq;
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
			var memberInfo = type.GetMember(@enum.ToString()).FirstOrDefault();

			if (memberInfo != null)
			{
				var attribute = memberInfo.GetCustomAttribute<JsonPropertyNameAttribute>();
				if (attribute != null)
				{
					return attribute.Name;

				}
			}

			return JsonNamingPolicy.SnakeCaseLower.ConvertName(@enum.ToString());
		}
	}
}
