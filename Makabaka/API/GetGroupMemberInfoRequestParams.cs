namespace Makabaka.API
{
	/// <summary>
	/// 获取群成员信息请求参数
	/// </summary>
	/// <param name="GroupId">群号</param>
	/// <param name="UserId">QQ 号</param>
	/// <param name="NoCache">是否不使用缓存（使用缓存可能更新不及时，但响应更快）</param>
	public record class GetGroupMemberInfoRequestParams(
		long GroupId,
		long UserId,
		bool NoCache = false
		)
	{
	}
}
