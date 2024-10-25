namespace Makabaka.API
{
	/// <summary>
	/// 好友戳一戳请求参数
	/// </summary>
	/// <param name="UserId">用户 ID</param>
	public record class FriendPokeRequestParams(
		long UserId
		)
	{
	}
}
