namespace Makabaka.Messages
{
	/// <summary>
	/// 图片数据
	/// </summary>
	public class ImageData
	{
		/// <summary>
		/// 图片文件<br/>
		/// ✔ 收<br/>
		/// ✔ 发[1]<br/><br/>
		/// [1] 发送时，file 参数除了支持使用收到的图片文件名直接发送外，还支持：<br/>
		/// - 绝对路径，例如 file:///C:\\Users\Richard\Pictures\1.png，格式使用 <a href="https://tools.ietf.org/html/rfc8089">file URI</a><br/>
		/// - 网络 URL，例如 http://i1.piimg.com/567571/fdd6e7b6d93f1ef0.jpg<br/>
		/// - Base64 编码，例如 base64://iVBORw0KGgoAAAANSUhEUgAAABQAAAAVCAIAAADJt1n/AAAAKElEQVQ4EWPk5+RmIBcwkasRpG9UM4mhNxpgowFGMARGEwnBIEJVAAAdBgBNAZf+QAAAAABJRU5ErkJggg==
		/// </summary>
		public string File { get; set; } = string.Empty;

		/// <summary>
		/// [Lagrange拓展] 图片文件名<br/>
		/// ✔ 收<br/>
		/// ✘ 发
		/// 例如：123.jpg
		/// </summary>
		public string? Filename { get; set; }

		/// <summary>
		/// 图片 URL<br/>
		/// ✔ 收<br/>
		/// ✘ 发
		/// </summary>
		public string? Url { get; set; }

		/// <summary>
		/// [Lagrange拓展] 显示的图片摘要<br/>
		/// ✔ 收<br/>
		/// ✔ 发
		/// 例如：[图片]
		/// </summary>
		public string Summary { get; set; } = string.Empty;

		/// <summary>
		/// [Lagrange拓展] 图片子类型
		/// ✔ 收<br/>
		/// ✔ 发
		/// </summary>
		public int SubType { get; set; }
	}
}
