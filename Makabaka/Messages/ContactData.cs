namespace Makabaka.Messages
{
	/// <summary>
	/// 推荐好友/群数据
	/// </summary>
	public class ContactData
	{
		/// <summary>
		/// 推荐好友/群<br/>
		/// ✔ 收<br/>
		/// ✔ 发
		/// </summary>
		public ContactType Type { get; set; }

		/// <summary>
		/// 被推荐人的 QQ 号<br/>
		/// ✔ 收<br/>
		/// ✔ 发
		/// </summary>
		public string Id { get; set; } = string.Empty;
	}
}
