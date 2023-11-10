using Makabaka.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.Messages
{
	/// <summary>
	/// <a href="https://github.com/botuniverse/onebot-11/blob/master/message/segment.md#%E7%BA%AF%E6%96%87%E6%9C%AC">纯文本段消息</a>
	/// </summary>
	public class TextSegment : Segment
	{
		/// <summary>
		/// 纯文本内容
		/// </summary>
		[JsonIgnore]
		public string Text
		{
			get
			{
				return (string)RawData["text"];
			}
			set
			{
				RawData["text"] = value;
			}
		}

		private TextSegment() { }

		/// <summary>
		/// 创建<a href="https://github.com/botuniverse/onebot-11/blob/master/message/segment.md#%E7%BA%AF%E6%96%87%E6%9C%AC">纯文本段消息</a>
		/// </summary>
		/// <param name="text">文本</param>
		public TextSegment(string text)
		{
			Type = "text";
			RawData = new JObject()
			{
				{ "text", text },
			};
		}

		/// <inheritdoc/>
		public override string ToString()
		{
			return CqCode.Encode(Text);
		}
	}
}
