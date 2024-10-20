namespace Makabaka.API
{
	/// <summary>
	/// 获取图片请求参数
	/// </summary>
	/// <param name="File">收到的图片文件名（消息段的 file 参数），如 6B4DE3DFD1BD271E3297859D41C530F5.jpg</param>
	public record class GetImageRequestParams(
		string File
		)
	{
	}
}
