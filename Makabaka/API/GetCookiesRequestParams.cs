namespace Makabaka.API
{
	/// <summary>
	/// 获取 Cookies 请求参数
	/// </summary>
	/// <param name="Domain">需要获取 cookies 的域名</param>
	public record class GetCookiesRequestParams(
		string Domain
		)
	{
	}
}
