namespace Makabaka.API
{
	/// <summary>
	/// 删除群文件夹请求参数
	/// </summary>
	/// <param name="GroupId">群聊 ID</param>
	/// <param name="FolderId">文件夹 ID</param>
	public record class DeleteGroupFolderRequestParams(
		long GroupId,
		string FolderId
		)
	{
	}
}
