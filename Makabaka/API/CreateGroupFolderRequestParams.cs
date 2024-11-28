namespace Makabaka.API
{
	/// <summary>
	/// 创建群文件夹请求参数
	/// </summary>
	/// <param name="GroupId">群号</param>
	/// <param name="Name">文件夹名称</param>
	/// <param name="ParentId">父级文件夹 ID</param>
	public record class CreateGroupFolderRequestParams(
		ulong GroupId,
		string Name,
		string ParentId = ""
		)
	{
	}
}
