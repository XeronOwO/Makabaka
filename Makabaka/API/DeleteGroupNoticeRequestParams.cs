namespace Makabaka.API
{
	/// <summary>
	/// 删除群公告请求参数
	/// </summary>
	/// <param name="GroupId">群聊 ID</param>
	/// <param name="NoticeId">公告 ID</param>
	public record class DeleteGroupNoticeRequestParams(
		long GroupId,
		string NoticeId
		)
	{
	}
}
