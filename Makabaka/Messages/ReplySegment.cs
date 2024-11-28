using Makabaka.Utils;

namespace Makabaka.Messages
{
	/// <summary>
	/// 回复段消息
	/// </summary>
	/// <param name="id">
	/// 回复时引用的消息 ID<br/>
	/// ✔ 收<br/>
	/// ✔ 发
	/// </param>
	[Segment(SegmentType.Reply)]
	public class ReplySegment(string id) : Segment<ReplyData>(
		SegmentType.Reply.ToSerializedString(),
		new()
		{
			Id = id,
		})
	{
		/// <summary>
		/// 回复段消息
		/// </summary>
		/// <param name="id"></param>
		public ReplySegment(ulong id) : this(id.ToString())
		{
		}

		/// <summary>
		/// 反序列化保留，请使用其它构造函数
		/// </summary>
		public ReplySegment() : this(string.Empty)
		{
		}
	}
}
