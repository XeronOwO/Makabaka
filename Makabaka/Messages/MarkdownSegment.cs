using Makabaka.Utils;

namespace Makabaka.Messages
{
	/// <summary>
	/// Markdown 段消息
	/// </summary>
	/// <param name="content">内容</param>
	[Segment(SegmentType.Markdown)]
	public class MarkdownSegment(string content)
		: Segment<MarkdownData>(
			SegmentType.Markdown.ToSerializedString(),
			new()
			{
				Content = content,
			})
	{
		/// <summary>
		/// 反序列化保留，请使用其它构造函数
		/// </summary>
		public MarkdownSegment() : this(string.Empty)
		{
		}
	}
}
