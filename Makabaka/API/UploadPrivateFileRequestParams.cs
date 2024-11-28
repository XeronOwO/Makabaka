namespace Makabaka.API
{
	/// <summary>
	/// 上传私聊文件请求参数
	/// </summary>
	/// <param name="UserId">QQ</param>
	/// <param name="File">文件路径</param>
	/// <param name="Name">名称</param>
	public record class UploadPrivateFileRequestParams(
		ulong UserId,
		string File,
		string? Name = null
		)
	{
	}
}
