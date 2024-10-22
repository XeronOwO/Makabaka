namespace Makabaka.API
{
	/// <summary>
	/// 移动群文件请求参数
	/// </summary>
	/// <param name="GroupId">群聊 ID</param>
	/// <param name="FileId">文件 ID</param>
	/// <param name="ParentDirectory">原文件夹</param>
	/// <param name="TargetDirectory">目标文件夹</param>
	public record class MoveGroupFileRequestParams(
		long GroupId,
		string FileId,
		string ParentDirectory,
		string TargetDirectory
		)
	{
	}
}
