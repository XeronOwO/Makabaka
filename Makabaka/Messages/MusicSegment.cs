using Makabaka.Utils;

namespace Makabaka.Messages
{
	/// <summary>
	/// 音乐分享段消息
	/// </summary>
	[Segment(SegmentType.Music)]
	public class MusicSegment(
		MusicType type,
		string id
		) : Segment<MusicData>(
			SegmentType.Music.ToSerializedString(),
			new()
			{
				Type = type,
				Id = id,
			})
	{
		/// <summary>
		/// 反序列化保留，请使用其它构造函数
		/// </summary>
		public MusicSegment() : this(default, string.Empty)
		{
		}
	}
}
