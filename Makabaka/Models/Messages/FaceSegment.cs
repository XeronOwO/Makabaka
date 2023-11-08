using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.Messages
{
	/// <summary>
	/// <a href="https://github.com/botuniverse/onebot-11/blob/master/message/segment.md#qq-%E8%A1%A8%E6%83%85">QQ表情段消息</a>
	/// </summary>
	public class FaceSegment : Segment
	{
		/// <summary>
		/// QQ 表情 ID<br/>
		/// 参考：<a href="https://github.com/kyubotics/coolq-http-api/wiki/%E8%A1%A8%E6%83%85-CQ-%E7%A0%81-ID-%E8%A1%A8">QQ 表情 ID 表</a>
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

		private FaceSegment() { }

		/// <summary>
		/// 创建<a href="https://github.com/botuniverse/onebot-11/blob/master/message/segment.md#qq-%E8%A1%A8%E6%83%85">QQ表情段消息</a>
		/// </summary>
		/// <param name="id">QQ 表情 ID<br/>参考：<a href="https://github.com/kyubotics/coolq-http-api/wiki/%E8%A1%A8%E6%83%85-CQ-%E7%A0%81-ID-%E8%A1%A8">QQ 表情 ID 表</a></param>
		public FaceSegment(string id)
		{
			Type = "face";
			RawData = new JObject()
			{
				{ "id", id },
			};
		}

		/// <summary>
		/// 创建<a href="https://github.com/botuniverse/onebot-11/blob/master/message/segment.md#qq-%E8%A1%A8%E6%83%85">QQ表情段消息</a>
		/// </summary>
		/// <param name="id">QQ 表情 ID<br/>参考：<a href="https://github.com/kyubotics/coolq-http-api/wiki/%E8%A1%A8%E6%83%85-CQ-%E7%A0%81-ID-%E8%A1%A8">QQ 表情 ID 表</a></param>
		public FaceSegment(long id) : this(id.ToString())
		{

		}

		/// <inheritdoc/>
		public override string ToString()
		{
			return $"[CQ:face,id={Id}]";
		}
	}
}
