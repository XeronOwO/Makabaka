namespace Makabaka.API
{
	/// <summary>
	/// 删除群公告请求参数
	/// </summary>
	/// <param name="GroupId">群号</param>
	/// <param name="NoticeId">公告 ID</param>
	public record class DeleteGroupNoticeRequestParams(
		ulong GroupId,
		string NoticeId
		)
	{
	}
}
