using Makabaka.Utils;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Makabaka.Models.Messages
{
	/// <summary>
	/// <a href="https://github.com/botuniverse/onebot-11/blob/master/message/segment.md#%E5%9B%9E%E5%A4%8D">回复段消息</a>
	/// </summary>
	public class ReplySegment : Segment
	{
		/// <summary>
		/// 回复时引用的消息 ID
		/// </summary>
		[JsonIgnore]
		public string Id
		{
			get
			{
				return (string)RawData["id"];
			}
			set
			{
				RawData["id"] = value;
			}
		}

		private ReplySegment()
		{
			Type = "reply";
		}

		internal ReplySegment(string id)
		{
			RawData = new JObject()
			{
				{ "id", id },
			};
		}

		/// <summary>
		/// 创建<a href="https://github.com/botuniverse/onebot-11/blob/master/message/segment.md#%E5%9B%9E%E5%A4%8D">回复段消息</a>
		/// </summary>
		/// <param name="id"></param>
		public ReplySegment(int id) : this(id.ToString())
		{
		}

		/// <inheritdoc/>
		public override string ToString()
		{
			return $"[CQ:{Type},id={Id}]";
		}
	}
}
