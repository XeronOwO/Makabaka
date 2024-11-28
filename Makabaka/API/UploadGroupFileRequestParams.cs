namespace Makabaka.API
{
	/// <summary>
	/// 上传群文件请求参数
	/// </summary>
	/// <param name="GroupId">群号</param>
	/// <param name="File">文件路径</param>
	/// <param name="Name">名称</param>
	/// <param name="Folder">文件夹</param>
	public record class UploadGroupFileRequestParams(
		ulong GroupId,
		string File,
		string? Name = null,
		string? Folder = null
		)
	{
	}
}
