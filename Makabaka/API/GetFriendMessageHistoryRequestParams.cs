namespace Makabaka.API
{
	/// <summary>
	/// 获取好友消息历史记录请求参数
	/// </summary>
	/// <param name="UserId">用户 ID</param>
	/// <param name="MessageId">基准消息 ID</param>
	/// <param name="Count">消息数量</param>
	public record class GetFriendMessageHistoryRequestParams(
		long UserId,
		long MessageId,
		uint Count
		)
	{
	}
}
