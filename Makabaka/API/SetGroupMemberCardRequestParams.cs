namespace Makabaka.API
{
	/// <summary>
	/// 设置群名片（群备注）
	/// </summary>
	/// <param name="GroupId">群号</param>
	/// <param name="UserId">要设置的 QQ 号</param>
	/// <param name="Card">群名片内容，不填或空字符串表示删除群名片</param>
	public record class SetGroupMemberCardRequestParams(
		ulong GroupId,
		ulong UserId,
		string? Card = null
		)
	{
	}
}
