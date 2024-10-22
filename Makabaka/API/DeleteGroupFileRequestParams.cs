namespace Makabaka.API
{
	/// <summary>
	/// 删除群文件请求参数
	/// </summary>
	/// <param name="GroupId">群聊 ID</param>
	/// <param name="FileId">文件 ID</param>
	public record class DeleteGroupFileRequestParams(
		long GroupId,
		string FileId
		)
	{
	}
}
