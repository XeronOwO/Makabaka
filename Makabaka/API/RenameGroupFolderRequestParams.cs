namespace Makabaka.API
{
	/// <summary>
	/// 重命名群组文件夹请求参数
	/// </summary>
	/// <param name="GroupId">群聊 ID</param>
	/// <param name="FolderId">文件夹 ID</param>
	/// <param name="NewFolderName">新文件夹名称</param>
	public record class RenameGroupFolderRequestParams(
		long GroupId,
		string FolderId,
		string NewFolderName
		)
	{
	}
}
