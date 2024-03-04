using Makabaka.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Makabaka.Models.Messages
{
	/// <summary>
	/// MarkDown段消息
	/// </summary>
	public class MarkDownSegment : Segment
	{
		/// <summary>
		/// MarkDown内容
		/// </summary>
		[JsonIgnore]
		public string Content
		{
			get
			{
				return (string)RawData["content"];
			}
			set
			{
				RawData["content"] = value;
			}
		}

		/// <summary>
		/// Json序列化时使用，请勿在代码中调用
		/// </summary>
		public MarkDownSegment()
		{
			Type = "markdown";
		}

		/// <summary>
		/// 创建MarkDown段消息
		/// </summary>
		/// <param name="content">内容</param>
		public MarkDownSegment(string content) : this()
		{
			RawData = new JObject()
			{
				{ "content", content },
			};
		}

		/// <inheritdoc/>
		public override string ToString()
		{
			return CqCode.Encode(Content);
		}
	}
}
