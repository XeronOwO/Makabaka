namespace Makabaka.API
{
	/// <summary>
	/// 发送好友赞请求参数
	/// </summary>
	/// <param name="UserId">对方 QQ 号</param>
	/// <param name="Times">赞的次数，每个好友每天最多 10 次</param>
	public record class SendLikeRequestParams(long UserId, int Times = 1)
	{
	}
}
