namespace Makabaka.Models
{
	/// <summary>
	/// 登录号信息
	/// </summary>
	public class LoginInfo
	{
		/// <summary>
		/// QQ 号
		/// </summary>
		public long UserId { get; set; }

		/// <summary>
		/// QQ 昵称
		/// </summary>
		public string Nickname { get; set; } = string.Empty;
	}
}
