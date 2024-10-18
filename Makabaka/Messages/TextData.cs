namespace Makabaka.Messages
{
	/// <summary>
	/// 文本数据
	/// </summary>
	[Segment(SegmentType.Text)]
	public class TextData
	{
		/// <summary>
		/// 纯文本内容<br/>
		/// ✔ 收<br/>
		/// ✔ 发
		/// </summary>
		public string Text { get; set; } = string.Empty;
	}
}
