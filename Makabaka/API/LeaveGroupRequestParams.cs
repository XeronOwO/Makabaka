namespace Makabaka.API
{
	/// <summary>
	/// 退出群组
	/// </summary>
	/// <param name="GroupId">群号</param>
	/// <param name="IsDismiss">是否解散，如果登录号是群主，则仅在此项为 true 时能够解散</param>
	public record class LeaveGroupRequestParams(
		long GroupId,
		bool IsDismiss = false
		)
	{
	}
}
