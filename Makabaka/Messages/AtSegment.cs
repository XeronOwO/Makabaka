using Makabaka.Utils;

namespace Makabaka.Messages
{
	/// <summary>
	/// @某人
	/// </summary>
	/// <param name="qq">@的 QQ 号，all 表示全体成员</param>
	/// <param name="name">[Lagrange拓展] @的名称</param>
	[Segment(SegmentType.At)]
	public class AtSegment(
		string qq,
		string? name = null
		) : Segment<AtData>(
			SegmentType.At.ToSerializedString(),
			new()
			{
				QQ = qq,
				Name = name,
			})
	{
		/// <summary>
		/// 反序列化保留，请使用其它构造函数
		/// </summary>
		public AtSegment() : this(string.Empty, null)
		{
		}

		/// <summary>
		/// @某人
		/// </summary>
		/// <param name="qq">@的 QQ 号</param>
		/// <param name="name">[Lagrange拓展] @的名称</param>
		public AtSegment(ulong qq, string? name = null) : this(qq.ToString(), name)
		{
		}
	}
}
