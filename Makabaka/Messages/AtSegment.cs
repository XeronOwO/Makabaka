using Makabaka.Utils;

namespace Makabaka.Messages
{
	/// <summary>
	/// @某人
	/// </summary>
	/// <param name="qq">@的 QQ 号，all 表示全体成员</param>
	[Segment(SegmentType.At)]
	public class AtSegment(
		string qq
		) : Segment<AtData>(
			SegmentType.At.ToSerializedString(),
			new()
			{
				Qq = qq
			})
	{
		/// <summary>
		/// 反序列化保留，请使用其它构造函数
		/// </summary>
		public AtSegment() : this(string.Empty)
		{
		}

		/// <summary>
		/// @某人
		/// </summary>
		/// <param name="qq">@的 QQ 号</param>
		public AtSegment(long qq) : this(qq.ToString())
		{
		}

		/// <inheritdoc/>
		public override string ToString()
		{
			return $"[CQ:{Type},qq={CqCode.Escape(Data.Qq)}]";
		}
	}
}
