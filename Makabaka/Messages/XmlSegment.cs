using Makabaka.Utils;

namespace Makabaka.Messages
{
	/// <summary>
	/// XML 消息段消息
	/// </summary>
	/// <param name="data">XML 内容</param>
	[Segment(SegmentType.Xml)]
	public class XmlSegment(string data) : Segment<XmlData>(
		SegmentType.Xml.ToSerializedString(),
		new()
		{
			Data = data,
		})
	{
		/// <summary>
		/// 反序列化保留，请使用其它构造函数
		/// </summary>
		public XmlSegment() : this(string.Empty)
		{
		}

		/// <inheritdoc/>
		public override string ToString()
		{
			return $"[CQ:{Type},data={CqCode.Escape(Data.Data)}]";
		}
	}
}
