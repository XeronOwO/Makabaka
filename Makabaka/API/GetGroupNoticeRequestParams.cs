namespace Makabaka.API
{
	/// <summary>
	/// 获取群公告请求参数
	/// </summary>
	/// <param name="GroupId">群聊 ID</param>
	public record class GetGroupNoticeRequestParams(
		long GroupId
		)
	{
	}
}
