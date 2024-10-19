namespace Makabaka.API
{
	/// <summary>
	/// 获取登录号信息响应数据
	/// </summary>
	public class GetLoginInfoResponseData
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
