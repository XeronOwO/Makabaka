namespace Makabaka.Models
{
	/// <summary>
	/// QQ 相关接口凭证信息
	/// </summary>
	public class CredentialsInfo
	{
		/// <summary>
		/// Cookies
		/// </summary>
		public string Cookies { get; set; } = string.Empty;

		/// <summary>
		/// CSRF Token
		/// </summary>
		public int CsrfToken { get; set; }
	}
}
