using Makabaka.Utils;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Makabaka.Models.Messages
{
	/// <summary>
	/// <a href="https://github.com/botuniverse/onebot-11/blob/master/message/segment.md#%E8%AF%AD%E9%9F%B3">语音段消息</a>
	/// </summary>
	public class RecordSegment : Segment
	{
		/// <summary>
		/// 语音文件名
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
		/// 发送时可选，默认 0，设置为 1 表示变声
		/// </summary>
		[JsonIgnore]
		public int Magic
		{
			get
			{
				if (!RawData.TryGetValue("magic", out var value))
				{
					return 0;
				}
				return int.Parse((string)value);
			}
			set
			{
				RawData["magic"] = value.ToString();
			}
		}

		/// <summary>
		/// 语音 URL
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
		public int Cache
		{
			get
			{
				if (!RawData.TryGetValue("cache", out var value))
				{
					return 1;
				}
				return int.Parse((string)value);
			}
			set
			{
				RawData["cache"] = value.ToString();
			}
		}

		/// <summary>
		/// 只在通过网络 URL 发送时有效，表示是否通过代理下载文件（需通过环境变量或配置文件配置代理），默认 1
		/// </summary>
		[JsonIgnore]
		public int Proxy
		{
			get
			{
				if (!RawData.TryGetValue("proxy", out var value))
				{
					return 1;
				}
				return int.Parse((string)value);
			}
			set
			{
				RawData["proxy"] = value.ToString();
			}
		}

		/// <summary>
		/// 只在通过网络 URL 发送时有效，单位秒，表示下载网络文件的超时时间 ，默认不超时
		/// </summary>
		[JsonIgnore]
		public int? Timeout
		{
			get
			{
				if (!RawData.TryGetValue("timeout", out var value))
				{
					return null;
				}
				if (value == null)
				{
					return null;
				}
				return int.Parse((string)value);
			}
			set
			{
				RawData["timeout"] = value.ToString();
			}
		}

		/// <summary>
		/// Json序列化时使用，请勿在代码中调用
		/// </summary>
		public RecordSegment()
		{
			Type = "record";
		}

		internal RecordSegment(string file, string magic, string url) : this()
		{
			RawData = new JObject()
			{
				{ "file", file },
				{ "magic", magic },
				{ "url", url },
			};
		}

		/// <summary>
		/// 创建可发送的<a href="https://github.com/botuniverse/onebot-11/blob/master/message/segment.md#%E8%AF%AD%E9%9F%B3">语音段消息</a>
		/// </summary>
		/// <param name="file">语音文件名<br/><br/>发送时，file 参数除了支持使用收到的语音文件名直接发送外，还支持其它形式，参考 <see cref="ImageSegment(string, string, int, int, int)"/>。</param>
		/// <param name="magic">发送时可选，默认 0，设置为 1 表示变声</param>
		/// <param name="cache">只在通过网络 URL 发送时有效，表示是否使用已缓存的文件，默认 1</param>
		/// <param name="proxy">只在通过网络 URL 发送时有效，表示是否通过代理下载文件（需通过环境变量或配置文件配置代理），默认 1</param>
		/// <param name="timeout">只在通过网络 URL 发送时有效，单位秒，表示下载网络文件的超时时间 ，默认不超时</param>
		public RecordSegment(string file, int magic = 0, int cache = 1, int proxy = 1, int? timeout = null) : this()
		{
			RawData = new JObject()
			{
				{ "file", file },
				{ "magic", magic.ToString() },
				{ "cache", cache.ToString() },
				{ "proxy", proxy.ToString() },
				{ "timeout", timeout.ToString() },
			};
		}

		/// <inheritdoc/>
		public override string ToString()
		{
			return $"[CQ:{Type},file={CqCode.Encode(File)}]";
		}
	}
}
