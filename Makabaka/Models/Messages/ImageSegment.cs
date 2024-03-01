using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Buffers.Text;
using System.Security.Cryptography;
using Makabaka.Utils;

namespace Makabaka.Models.Messages
{
	/// <summary>
	/// <a href="https://github.com/botuniverse/onebot-11/blob/master/message/segment.md#%E5%9B%BE%E7%89%87">图片段消息</a>
	/// </summary>
	public class ImageSegment : Segment
	{
		/// <summary>
		/// 图片文件名<br/><br/>
		/// 发送时，file 参数除了支持使用收到的图片文件名直接发送外，还支持：<br/>
		/// * 绝对路径，例如 file:///C:\\Users\Richard\Pictures\1.png，格式使用 file URI<br/>
		/// * 网络 URL，例如 http://i1.piimg.com/567571/fdd6e7b6d93f1ef0.jpg<br/>
		/// * Base64 编码，例如 base64://iVBORw0KGgoAAAANSUhEUgAAABQAAAAVCAIAAADJt1n/AAAAKElEQVQ4EWPk5+RmIBcwkasRpG9UM4mhNxpgowFGMARGEwnBIEJVAAAdBgBNAZf+QAAAAABJRU5ErkJggg==
		/// </summary>
		[JsonIgnore]
		public string File
		{
			get
			{
				return (string)RawData["file"];
			}
			set
			{
				RawData["file"] = value;
			}
		}

		/// <summary>
		/// 图片类型，flash 表示闪照，无此参数表示普通图片
		/// </summary>
		[JsonIgnore]
		public string ImageType
		{
			get
			{
				return (string)RawData["type"];
			}
			set
			{
				RawData["type"] = value;
			}
		}

		/// <summary>
		/// 是否是闪照
		/// </summary>
		[JsonIgnore]
		public bool IsFlash
		{
			get
			{
				return ImageType == "flash";
			}
			set
			{
				ImageType = value ? "flash" : string.Empty;
			}
		}

		/// <summary>
		/// 图片 URL
		/// </summary>
		[JsonIgnore]
		public string Url
		{
			get
			{
				return (string)RawData["url"];
			}
			set
			{
				RawData["url"] = value;
			}
		}

		/// <summary>
		/// 只在通过网络 URL 发送时有效，表示是否使用已缓存的文件，默认 1
		/// </summary>
		[JsonIgnore]
		public string Cache
		{
			get
			{
				return (string)RawData["cache"];
			}
			set
			{
				if (value != "0" && value != "1")
				{
					throw new Exception("Cache的值只能为0或1");
				}
				RawData["cache"] = value;
			}
		}

		/// <summary>
		/// 只在通过网络 URL 发送时有效，表示是否通过代理下载文件（需通过环境变量或配置文件配置代理），默认 1
		/// </summary>
		[JsonIgnore]
		public string Proxy
		{
			get
			{
				return (string)RawData["proxy"];
			}
			set
			{
				if (value != "0" && value != "1")
				{
					throw new Exception("Proxy的值只能为0或1");
				}
				RawData["proxy"] = value;
			}
		}

		/// <summary>
		/// 只在通过网络 URL 发送时有效，单位秒，表示下载网络文件的超时时间，默认不超时
		/// </summary>
		[JsonIgnore]
		public string Timeout
		{
			get
			{
				return (string)RawData["timeout"];
			}
			set
			{
				RawData["timeout"] = value;
			}
		}

		/// <summary>
		/// Json序列化时使用，请勿在代码中调用
		/// </summary>
		public ImageSegment()
		{
			Type = "image";
		}

		internal ImageSegment(string file, string type, string url) : this()
		{
			RawData = new JObject()
			{
				{ "file", file },
				{ "type", type },
				{ "url", url },
			};
		}

		/// <summary>
		/// 创建可发送的<a href="https://github.com/botuniverse/onebot-11/blob/master/message/segment.md#%E5%9B%BE%E7%89%87">图片段消息</a>
		/// </summary>
		/// <param name="file">图片文件名<br/><br/>发送时，file 参数除了支持使用收到的图片文件名直接发送外，还支持：<br/>* 绝对路径，例如 file:///C:\\Users\Richard\Pictures\1.png，格式使用 file URI<br/>* 网络 URL，例如 http://i1.piimg.com/567571/fdd6e7b6d93f1ef0.jpg<br/>* Base64 编码，例如 base64://iVBORw0KGgoAAAANSUhEUgAAABQAAAAVCAIAAADJt1n/AAAAKElEQVQ4EWPk5+RmIBcwkasRpG9UM4mhNxpgowFGMARGEwnBIEJVAAAdBgBNAZf+QAAAAABJRU5ErkJggg==</param>
		/// <param name="type">图片类型，flash 表示闪照，无此参数表示普通图片</param>
		/// <param name="cache">只在通过网络 URL 发送时有效，表示是否使用已缓存的文件，默认 1</param>
		/// <param name="proxy">只在通过网络 URL 发送时有效，表示是否通过代理下载文件（需通过环境变量或配置文件配置代理），默认 1</param>
		/// <param name="timeout">只在通过网络 URL 发送时有效，单位秒，表示下载网络文件的超时时间，默认不超时</param>
		public ImageSegment(string file, string type = null, int cache = 1, int proxy = 1, int timeout = 0) : this()
		{
			RawData = new JObject()
			{
				{ "file", file },
				{ "type", type },
				{ "cache", cache.ToString() },
				{ "proxy", proxy.ToString() },
				{ "timeout", timeout.ToString() },
			};
		}

		/// <summary>
		/// 从本地文件创建<a href="https://github.com/botuniverse/onebot-11/blob/master/message/segment.md#%E5%9B%BE%E7%89%87">图片段消息</a>
		/// </summary>
		/// <param name="path">本地路径</param>
		/// <returns>图片段消息</returns>
		public static ImageSegment FromLocalFile(string path)
		{
			var bytes = System.IO.File.ReadAllBytes(path);
			var base64 = Convert.ToBase64String(bytes);
			return new ImageSegment($"base64://{base64}");
		}

		/// <inheritdoc/>
		public override string ToString()
		{
			return $"[CQ:{Type},file={CqCode.Encode(File)}]";
		}
	}
}
