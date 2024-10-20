namespace Makabaka.Models
{
	/// <summary>
	/// 好友信息
	/// </summary>
	public class FriendInfo
	{
		/// <summary>
		/// QQ 号
		/// </summary>
		public long UserId { get; set; }

		/// <summary>
		/// 昵称
		/// </summary>
		public string Nickname { get; set; } = string.Empty;

		/// <summary>
		/// 备注名
		/// </summary>
		public string Remark { get; set; } = string.Empty;
	}
}
