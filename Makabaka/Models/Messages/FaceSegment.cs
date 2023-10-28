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
		[JsonIgnore]
		private int _id;

		/// <summary>
		/// QQ 表情 ID<br/>
		/// 参考：<a href="https://github.com/kyubotics/coolq-http-api/wiki/%E8%A1%A8%E6%83%85-CQ-%E7%A0%81-ID-%E8%A1%A8">QQ 表情 ID 表</a>
		/// </summary>
		[JsonIgnore]
		public int Id
		{
			get
			{
				return _id;
			}
			internal set
			{
				_id = value;
				RawData["id"] = _id.ToString();
			}
		}

		/// <summary>
		/// 创建<a href="https://github.com/botuniverse/onebot-11/blob/master/message/segment.md#qq-%E8%A1%A8%E6%83%85">QQ表情段消息</a>
		/// </summary>
		/// <param name="id">QQ 表情 ID<br/>参考：<a href="https://github.com/kyubotics/coolq-http-api/wiki/%E8%A1%A8%E6%83%85-CQ-%E7%A0%81-ID-%E8%A1%A8">QQ 表情 ID 表</a></param>
		public FaceSegment(int id)
		{
			Type = "text";
			RawData = new JObject()
			{
				{ "id", id.ToString() },
			};
			_id = id;
		}

		public override string ToString()
		{
			return $"[CQ:face,id={_id}]";
		}
	}
}
