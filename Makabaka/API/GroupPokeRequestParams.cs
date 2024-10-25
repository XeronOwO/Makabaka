namespace Makabaka.API
{
	/// <summary>
	/// 群聊戳一戳请求参数
	/// </summary>
	/// <param name="UserId">用户 ID</param>
	/// <param name="GroupId">群号</param>
	public record class GroupPokeRequestParams(
		long UserId,
		long GroupId
		)
	{
	}
}
