using Makabaka.Utils;
using System;
using System.IO;

namespace Makabaka.Messages
{
	/// <summary>
	/// 图片段消息
	/// </summary>
	/// <param name="file">
	/// 图片文件<br/>
	/// ✔ 收<br/>
	/// ✔ 发[1]<br/><br/>
	/// [1] 发送时，file 参数除了支持使用收到的图片文件名直接发送外，还支持：<br/>
	/// - 绝对路径，例如 file:///C:\\Users\Richard\Pictures\1.png，格式使用 <a href="https://tools.ietf.org/html/rfc8089">file URI</a><br/>
	/// - 网络 URL，例如 http://i1.piimg.com/567571/fdd6e7b6d93f1ef0.jpg<br/>
	/// - Base64 编码，例如 base64://iVBORw0KGgoAAAANSUhEUgAAABQAAAAVCAIAAADJt1n/AAAAKElEQVQ4EWPk5+RmIBcwkasRpG9UM4mhNxpgowFGMARGEwnBIEJVAAAdBgBNAZf+QAAAAABJRU5ErkJggg==
	/// </param>
	/// <param name="type">
	/// 图片类型<br/>
	/// flash：闪照<br/>
	/// &lt;空&gt;：普通图片<br/>
	/// ✔ 收<br/>
	/// ✔ 发
	/// </param>
	/// <param name="summary">
	/// [Lagrange拓展] 显示的图片摘要<br/>
	/// ✔ 收<br/>
	/// ✔ 发
	/// 例如：[图片]
	/// </param>
	/// <param name="subType">
	/// [Lagrange拓展] 图片子类型
	/// ✔ 收<br/>
	/// ✔ 发
	/// </param>
	/// <param name="cache">
	/// 只在通过网络 URL 发送时有效，表示是否使用已缓存的文件，默认 1<br/>
	/// 0：不使用已缓存的文件<br/>
	/// 1：使用已缓存的文件<br/>
	/// ✘ 收<br/>
	/// ✔ 发
	/// </param>
	/// <param name="proxy">
	/// 只在通过网络 URL 发送时有效，表示是否通过代理下载文件（需通过环境变量或配置文件配置代理），默认 1<br/>
	/// 0：不通过代理下载文件<br/>
	/// 1：通过代理下载文件<br/>
	/// ✘ 收<br/>
	/// ✔ 发
	/// </param>
	/// <param name="timeout">
	/// 只在通过网络 URL 发送时有效，单位秒，表示下载网络文件的超时时间，默认不超时<br/>
	/// ✘ 收<br/>
	/// ✔ 发
	/// </param>
	[Segment(SegmentType.Image)]
	public class ImageSegment(
		string file,
		string type = "",
		string summary = "[图片]",
		int subType = 0,
		int? cache = null,
		int? proxy = null,
		int? timeout = null
		) : Segment<ImageData>(
			SegmentType.Image.ToSerializedString(),
			new()
			{
				File = file,
				Type = type,
				Summary = summary,
				SubType = subType,
				Cache = cache,
				Proxy = proxy,
				Timeout = timeout,
			})
	{
		/// <summary>
		/// 反序列化保留，请使用其它构造函数
		/// </summary>
		public ImageSegment() : this(string.Empty)
		{
		}

		/// <summary>
		/// 从字节数组创建图片段消息
		/// </summary>
		/// <param name="bytes">字节数组</param>
		/// <returns>图片段消息</returns>
		public static ImageSegment FromBytes(byte[] bytes)
		{
			var base64 = Convert.ToBase64String(bytes);
			return new ImageSegment($"base64://{base64}");
		}

		/// <summary>
		/// 从流创建图片段消息
		/// </summary>
		/// <param name="stream">流</param>
		/// <returns>图片段消息</returns>
		public static ImageSegment FromStream(Stream stream)
		{
			using var memoryStream = new MemoryStream();
			stream.CopyTo(memoryStream);
			return FromBytes(memoryStream.ToArray());
		}

		/// <summary>
		/// 从文件创建图片段消息
		/// </summary>
		/// <param name="path">文件</param>
		/// <returns>图片段消息</returns>
		public static ImageSegment FromFile(string path)
		{
			return FromBytes(File.ReadAllBytes(path));
		}

		/// <inheritdoc/>
		public override string ToString()
		{
			return $"[CQ:{Type},file={CqCode.Escape(Data.File)}]";
		}
	}
}
