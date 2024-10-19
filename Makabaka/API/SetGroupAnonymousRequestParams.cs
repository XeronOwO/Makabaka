namespace Makabaka.API
{
	/// <summary>
	/// 群组匿名请求参数
	/// </summary>
	/// <param name="GroupId">群号</param>
	/// <param name="Enable">是否允许匿名聊天</param>
	public record class SetGroupAnonymousRequestParams(
		long GroupId,
		bool Enable = true
		)
	{
	}
}
