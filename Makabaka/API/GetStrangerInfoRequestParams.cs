namespace Makabaka.API
{
	/// <summary>
	/// 获取陌生人信息请求参数
	/// </summary>
	/// <param name="UserId">QQ 号</param>
	/// <param name="NoCache">是否不使用缓存（使用缓存可能更新不及时，但响应更快）</param>
	public record class GetStrangerInfoRequestParams(
		long UserId,
		bool NoCache = false
		)
	{
	}
}
