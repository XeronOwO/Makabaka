using Makabaka.Utils;

namespace Makabaka.Messages
{
	/// <summary>
	/// 推荐好友段消息
	/// </summary>
	/// <param name="type">
	/// 推荐好友/群<br/>
	/// ✔ 收<br/>
	/// ✔ 发
	/// </param>
	/// <param name="id">
	/// 被推荐人的 QQ 号<br/>
	/// ✔ 收<br/>
	/// ✔ 发
	/// </param>
	[Segment(SegmentType.Contact)]
	public class ContactSegment(
		ContactType type,
		string id
		)
		: Segment<ContactData>(
			SegmentType.Contact.ToSerializedString(),
			new()
			{
				Type = type,
				Id = id,
			})
	{
		/// <summary>
		/// 推荐好友段消息
		/// </summary>
		/// <param name="type">
		/// 推荐好友/群<br/>
		/// ✔ 收<br/>
		/// ✔ 发
		/// </param>
		/// <param name="id">
		/// 被推荐人的 QQ 号<br/>
		/// ✔ 收<br/>
		/// ✔ 发
		/// </param>
		public ContactSegment(
			ContactType type,
			long id
			) : this(type, id.ToString())
		{
		}

		/// <summary>
		/// 反序列化保留，请使用其它构造函数
		/// </summary>
		public ContactSegment() : this(default, string.Empty)
		{
		}
	}
}
