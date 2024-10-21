using Makabaka.Utils;

namespace Makabaka.Messages
{
	/// <summary>
	/// 长消息段消息
	/// </summary>
	/// <param name="id">转发消息 ID</param>
	[Segment(SegmentType.LongMessage)]
	public class LongMessageSegment(string id)
		: Segment<LongMessageData>(
			SegmentType.LongMessage.ToSerializedString(),
			new()
			{
				Id = id,
			})
	{
		/// <summary>
		/// 反序列化保留，请使用其它构造函数
		/// </summary>
		public LongMessageSegment() : this(string.Empty)
		{
		}

		/// <inheritdoc/>
		public override string ToString()
		{
			return $"[CQ:{Type},id={CqCode.Escape(Data.Id.ToString())}]";
		}
	}
}
