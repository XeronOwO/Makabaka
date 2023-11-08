using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.Messages
{
	/// <summary>
	/// <a href="https://github.com/botuniverse/onebot-11/blob/master/message/segment.md">段消息</a>
	/// </summary>
	public class Segment
	{
		/// <summary>
		/// 消息类型
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; internal set; }

		/// <summary>
		/// 原始data信息
		/// </summary>
		[JsonProperty("data")]
		public JObject RawData { get; internal set; }

		internal Segment PostProcessSegment()
		{
			switch (Type)
			{
				case "text":
					return new TextSegment((string)RawData["text"]);
				case "face":
					return new FaceSegment(int.Parse((string)RawData["id"]));
				case "image":
					return new ImageSegment((string)RawData["file"], (string)RawData["type"], (string)RawData["url"]);
				case "at":
					return new AtSegment((string)RawData["qq"]);
				case "forward":
					return new ForwardSegment((string)RawData["id"]);
				default:
					Log.Warning($"不支持的段消息类型：{Type}");
					return null;
			}
		}

		/// <summary>
		/// 转换为字符串<br/>
		/// 注：如果非文本信息，会转化为CQ Code
		/// </summary>
		/// <returns>字符串</returns>
		public override string ToString()
		{
			return string.Empty;
		}

		/// <summary>
		/// 隐式转换为消息
		/// </summary>
		/// <param name="segment">消息</param>
		public static implicit operator Message(Segment segment)
		{
			return new Message()
			{
				{ segment },
			};
		}

		/// <summary>
		/// 隐式转换为字符串<br/>
		/// 注：如果非文本信息，会转化为CQ Code
		/// </summary>
		/// <param name="segment">字符串</param>
		public static implicit operator string(Segment segment)
		{
			return segment.ToString();
		}
	}
}
