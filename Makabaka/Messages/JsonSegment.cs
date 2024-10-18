using Makabaka.Utils;

namespace Makabaka.Messages
{
	/// <summary>
	/// JSON 消息段消息
	/// </summary>
	/// <param name="data">JSON 内容</param>
	[Segment(SegmentType.Json)]
	public class JsonSegment(string data) : Segment<JsonData>(
		SegmentType.Json.ToSerializedString(),
		new()
		{
			Data = data
		})
	{
		/// <summary>
		/// 反序列化保留，请使用其它构造函数
		/// </summary>
		public JsonSegment() : this(string.Empty)
		{
		}

		/// <inheritdoc/>
		public override string ToString()
		{
			return $"[CQ:{Type},data={CqCode.Escape(Data.Data)}]";
		}
	}
}
