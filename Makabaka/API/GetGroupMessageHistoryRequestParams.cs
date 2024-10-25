namespace Makabaka.API
{
	/// <summary>
	/// 获取群消息历史记录请求参数
	/// </summary>
	/// <param name="GroupId">群号</param>
	/// <param name="MessageId">基准消息 ID</param>
	/// <param name="Count">消息数量</param>
	public record class GetGroupMessageHistoryRequestParams(
		long GroupId,
		long MessageId,
		uint Count
		)
	{
	}
}
