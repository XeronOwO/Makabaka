namespace Makabaka.API
{
	/// <summary>
	/// 群组单人禁言
	/// </summary>
	/// <param name="GroupId">群号</param>
	/// <param name="UserId">要禁言的 QQ 号</param>
	/// <param name="Duration">禁言时长，单位秒，0 表示取消禁言</param>
	public record class MuteGroupMemberRequestParams(
		long GroupId,
		long UserId,
		int Duration = 30 * 60
		)
	{
	}
}
