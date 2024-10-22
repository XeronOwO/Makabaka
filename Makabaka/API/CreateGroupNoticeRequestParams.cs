namespace Makabaka.API
{
	/// <summary>
	/// 创建群公告请求参数
	/// </summary>
	/// <param name="GroupId">群聊 ID</param>
	/// <param name="Content">内容</param>
	/// <param name="Image">图片</param>
	public record class CreateGroupNoticeRequestParams(
		long GroupId,
		string Content,
		string? Image = null
		)
	{
	}
}
