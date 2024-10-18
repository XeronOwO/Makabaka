using Makabaka.Utils;

namespace Makabaka.Messages
{
	/// <summary>
	/// QQ 表情段消息
	/// </summary>
	/// <param name="id">
	/// QQ 表情 ID。见 <a href="https://github.com/richardchien/coolq-http-api/wiki/%E8%A1%A8%E6%83%85-CQ-%E7%A0%81-ID-%E8%A1%A8">QQ 表情 ID 表</a><br/>
	/// ✔ 收<br/>
	/// ✔ 发
	/// </param>
	[Segment(SegmentType.Face)]
	public class FaceSegment(
		string id
		) : Segment<FaceData>(
			SegmentType.Face.ToSerializedString(),
			new()
			{
				Id = id,
			})
	{
		/// <summary>
		/// 反序列化保留，请使用其它构造函数
		/// </summary>
		public FaceSegment() : this(string.Empty)
		{
		}

		/// <inheritdoc/>
		public override string ToString()
		{
			return $"[CQ:{Type},id={CqCode.Escape(Data.Id)}]";
		}
	}
}
