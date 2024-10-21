using Makabaka.Utils;
using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Makabaka.Messages
{
	/// <summary>
	/// 段消息基类
	/// </summary>
	/// <param name="type">类型</param>
	public class Segment(string type)
	{
		/// <summary>
		/// 反序列化保留，请使用其它构造函数
		/// </summary>
		public Segment() : this(string.Empty)
		{
		}

		/// <summary>
		/// 类型
		/// </summary>
		public string Type { get; set; } = type;

		/// <inheritdoc/>
		public override string ToString()
		{
			return $"[CQ:{Type}]";
		}
	}

	/// <summary>
	/// 段消息泛型基类
	/// </summary>
	/// <typeparam name="T">数据类型</typeparam>
	/// <param name="type">类型</param>
	/// <param name="data">数据</param>
	public class Segment<T>(string type, T data) : Segment(type)
	{
		/// <summary>
		/// 反序列化保留，请使用其它构造函数
		/// </summary>
		public Segment() : this(string.Empty, default!)
		{
		}

		/// <summary>
		/// 数据
		/// </summary>
		public T Data { get; set; } = data;

		private static readonly PropertyInfo[] _properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
			.Where(p => p.CanRead && p.CanWrite)
			.ToArray();

		private static readonly JsonNamingPolicy _namingPolicy = JsonNamingPolicy.SnakeCaseLower;

		/// <inheritdoc/>
		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.Append("[CQ:")
				.Append(Type);

			foreach (var property in _properties)
			{
				ConvertToCqCodeKeyValue(sb, property);
			}

			sb.Append(']');
			return sb.ToString();
		}

		private void ConvertToCqCodeKeyValue(StringBuilder sb, PropertyInfo property)
		{
			var propertyName = _namingPolicy.ConvertName(property.Name);
			var attribute = property.GetCustomAttribute<JsonPropertyNameAttribute>();
			if (attribute is not null)
			{
				propertyName = attribute.Name;
			}

			var value = property.GetValue(Data);
			if (value == null)
			{
				return;
			}

			sb.Append(',')
				.Append(CqCode.Escape(propertyName))
				.Append('=')
				.Append(CqCode.Escape(ToCqCodeValue(value)));
		}

		private string ToCqCodeValue(object obj)
		{
			if (obj is int ||
				obj is uint ||
				obj is long ||
				obj is ulong)
			{
				return obj.ToString();
			}

			if (obj is string str)
			{
				return str;
			}

			if (obj is Enum @enum)
			{
				return @enum.ToSerializedString();
			}

			throw new Exception(obj.GetType().ToString());
		}
	}
}
