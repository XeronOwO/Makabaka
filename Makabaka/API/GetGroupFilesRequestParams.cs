namespace Makabaka.API
{
	/// <summary>
	/// 获取群文件列表
	/// </summary>
	/// <param name="GroupId">群聊 ID</param>
	/// <param name="FolderId">文件夹 ID ，留空表示根文件夹</param>
	public record class GetGroupFilesRequestParams(
		long GroupId,
		string? FolderId = null
		)
	{
	}
}
