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
		/// <a href="https://github.com/botuniverse/onebot-11/blob/master/message/segment.md">消息类型</a>
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
					return new FaceSegment((string)RawData["id"]);
				case "image":
					return new ImageSegment((string)RawData["file"], (string)RawData["type"], (string)RawData["url"]);
				case "record":
					return new RecordSegment((string)RawData["file"], (string)RawData["magic"], (string)RawData["url"]);
				case "video":
					return new VideoSegment((string)RawData["file"], (string)RawData["url"]);
				case "at":
					return new AtSegment((string)RawData["qq"]);
				case "rps":
					return new RpsSegment();
				case "dice":
					return new DiceSegment();
				case "poke":
					return new PokeSegment((string)RawData["type"], (string)RawData["id"], (string)RawData["name"]);
				case "location":
					return new LocationSegment((string)RawData["lat"], (string)RawData["lon"], (string)RawData["title"], (string)RawData["content"]);
				case "reply":
					return new ReplySegment((string)RawData["id"]);
				case "forward":
					return new ForwardSegment((string)RawData["id"]);
				case "node":
					return new NodeSegment((string)RawData["user_id"], (string)RawData["nickname"], (JArray)RawData["content"]);
				case "markdown":
					return new MarkDownSegment((string)RawData["content"]);
				case "keyboard":
					return new KeyboardSegment(RawData);
				case "longmsg":
					return new LongMsgSegment((string)RawData["id"]);
				case "json":
					return new JsonSegment((string)RawData["data"]);
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
