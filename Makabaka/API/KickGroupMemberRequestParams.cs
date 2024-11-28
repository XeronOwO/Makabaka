namespace Makabaka.API
{
	/// <summary>
	/// 踢出群成员请求参数
	/// </summary>
	/// <param name="GroupId">群号</param>
	/// <param name="UserId">要踢的 QQ 号</param>
	/// <param name="RejectAddRequest">拒绝此人的加群请求</param>
	public record class KickGroupMemberRequestParams(
		ulong GroupId,
		ulong UserId,
		bool RejectAddRequest = false
		)
	{
	}
}
