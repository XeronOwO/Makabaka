namespace Makabaka.API
{
	/// <summary>
	/// 移动群文件请求参数
	/// </summary>
	/// <param name="GroupId">群号</param>
	/// <param name="FileId">文件 ID</param>
	/// <param name="ParentDirectory">原文件夹</param>
	/// <param name="TargetDirectory">目标文件夹</param>
	public record class MoveGroupFileRequestParams(
		ulong GroupId,
		string FileId,
		string ParentDirectory,
		string TargetDirectory
		)
	{
	}
}
