using Makabaka.Utils;

namespace Makabaka.Messages
{
	/// <summary>
	/// 文本段消息
	/// </summary>
	/// <param name="text">纯文本内容<br/>✔ 收<br/>✔ 发</param>
	[Segment(SegmentType.Text)]
	public class TextSegment(string text) : Segment<TextData>(
		SegmentType.Text.ToSerializedString(),
		new()
		{
			Text = text,
		})
	{
		/// <summary>
		/// 反序列化保留，请使用其它构造函数
		/// </summary>
		public TextSegment() : this(string.Empty)
		{
		}

		/// <inheritdoc/>
		public override string ToString()
		{
			return CqCode.Escape(Data.Text);
		}
	}
}
