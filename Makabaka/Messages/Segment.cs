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
	}
}
