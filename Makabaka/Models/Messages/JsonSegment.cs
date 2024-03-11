using Makabaka.Utils;
using System.Text.Json.Serialization;

namespace Makabaka.Models.Messages
{
	/// <summary>
	/// <a href="https://github.com/botuniverse/onebot-11/blob/master/message/segment.md#json-%E6%B6%88%E6%81%AF">JSON 消息</a>
	/// </summary>
	public class JsonSegment : Segment
	{
		/// <summary>
		/// JSON 内容
		/// </summary>
		[JsonIgnore]
		public string Data
		{
			get
			{
				return (string)RawData["data"];
			}
			set
			{
				RawData["data"] = value;
			}
		}

		/// <summary>
		/// Json序列化时使用，请勿在代码中调用
		/// </summary>
		public JsonSegment()
		{
			Type = "json";
		}

		/// <summary>
		/// 创建<a href="https://github.com/botuniverse/onebot-11/blob/master/message/segment.md#json-%E6%B6%88%E6%81%AF">JSON 消息</a>
		/// </summary>
		/// <param name="data">JSON 内容</param>
		public JsonSegment(string data) : this()
		{
			RawData = new()
			{
				{ "data", data },
			};
		}

		/// <inheritdoc/>
		public override string ToString()
		{
			return $"[CQ:{Type},data={CqCode.Encode(Data)}]";
		}
	}
}
