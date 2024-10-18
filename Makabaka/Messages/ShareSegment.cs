using Makabaka.Utils;

namespace Makabaka.Messages
{
	/// <summary>
	/// 链接分享段消息
	/// </summary>
	/// <param name="url">
	/// URL<br/>
	/// ✔ 收<br/>
	/// ✔ 发
	/// </param>
	/// <param name="title">
	/// 标题<br/>
	/// ✔ 收<br/>
	/// ✔ 发
	/// </param>
	/// <param name="content">
	/// 发送时可选，内容描述<br/>
	/// ✔ 收<br/>
	/// ✔ 发
	/// </param>
	/// <param name="image">
	/// 发送时可选，图片 URL<br/>
	/// ✔ 收<br/>
	/// ✔ 发
	/// </param>
	[Segment(SegmentType.Share)]
	public class ShareSegment(
		string url,
		string title,
		string? content = null,
		string? image = null
		) : Segment<ShareData>(
			SegmentType.Share.ToSerializedString(),
			new()
			{
				Url = url,
				Title = title,
				Content = content,
				Image = image
			})
	{
		/// <summary>
		/// 反序列化保留，请使用其它构造函数
		/// </summary>
		public ShareSegment() : this(string.Empty, string.Empty)
		{
		}

		/// <inheritdoc/>
		public override string ToString()
		{
			return $"[CQ:{Type},url={CqCode.Escape(Data.Url)},title={CqCode.Escape(Data.Title)}]";
		}
	}
}
