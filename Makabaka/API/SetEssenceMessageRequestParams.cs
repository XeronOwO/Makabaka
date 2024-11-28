namespace Makabaka.API
{
	/// <summary>
	/// 设置精华消息请求参数
	/// </summary>
	/// <param name="MessageId">消息 ID</param>
	public record class SetEssenceMessageRequestParams(
		ulong MessageId
		)
	{
	}
}
