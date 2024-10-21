namespace Makabaka.API
{
	/// <summary>
	/// 上传图片请求参数
	/// </summary>
	/// <param name="File">
	/// 图片文件<br/>
	/// file 参数除了支持使用收到的图片文件名直接发送外，还支持：<br/>
	/// - 绝对路径，例如 file:///C:\\Users\Richard\Pictures\1.png，格式使用 <a href="https://tools.ietf.org/html/rfc8089">file URI</a><br/>
	/// - 网络 URL，例如 http://i1.piimg.com/567571/fdd6e7b6d93f1ef0.jpg<br/>
	/// - Base64 编码，例如 base64://iVBORw0KGgoAAAANSUhEUgAAABQAAAAVCAIAAADJt1n/AAAAKElEQVQ4EWPk5+RmIBcwkasRpG9UM4mhNxpgowFGMARGEwnBIEJVAAAdBgBNAZf+QAAAAABJRU5ErkJggg==
	/// </param>
	public record class UploadImageRequestParams(
		string File
		)
	{
	}
}
