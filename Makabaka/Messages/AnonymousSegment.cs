using Makabaka.Utils;

namespace Makabaka.Messages
{
	/// <summary>
	/// 匿名发消息段消息
	/// </summary>
	/// <param name="ignore">
	/// 可选，表示无法匿名时是否继续发送<br/>
	/// 0：不继续发送<br/>
	/// 1：继续发送<br/>
	/// ✘ 收<br/>
	/// ✔ 发<br/><br/>
	/// 当收到匿名消息时，需要通过 <see cref="Events.GroupMessageEventArgs.Anonymous"/> 字段判断。
	/// </param>
	[Segment(SegmentType.Anonymous)]
	public class AnonymousSegment(int? ignore = null)
		: Segment<AnonymousData>(
			SegmentType.Anonymous.ToSerializedString(),
			new()
			{
				Ignore = ignore,
			})
	{
		/// <summary>
		/// 反序列化保留，请使用其它构造函数
		/// </summary>
		public AnonymousSegment() : this(null)
		{
		}
	}
}
