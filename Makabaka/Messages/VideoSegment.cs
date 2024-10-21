using Makabaka.Utils;

namespace Makabaka.Messages
{
	/// <summary>
	/// 短视频段消息
	/// </summary>
	/// <param name="file">
	/// 视频文件名<br/>
	/// ✔ 收<br/>
	/// ✔ 发[1]<br/><br/>
	/// [1] 发送时，file 参数除了支持使用收到的视频文件名直接发送外，还支持其它形式，参考 <see cref="ImageData.File"/>。
	/// </param>
	[Segment(SegmentType.Video)]
	public class VideoSegment(
		string file
		) : Segment<VideoData>(
			SegmentType.Video.ToSerializedString(),
			new()
			{
				File = file,
			})
	{
		/// <summary>
		/// 反序列化保留，请使用其它构造函数
		/// </summary>
		public VideoSegment() : this(string.Empty)
		{
		}

		/// <inheritdoc/>
		public override string ToString()
		{
			return $"[CQ:{Type},file={CqCode.Escape(Data.File)}]";
		}
	}
}
