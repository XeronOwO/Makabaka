using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Makabaka.Models.Messages
{
	/// <summary>
	/// <a href="https://github.com/botuniverse/onebot-11/blob/master/message/segment.md#%E6%9F%90%E4%BA%BA">@某人段消息</a>
	/// </summary>
	public class AtSegment : Segment
	{
		[JsonIgnore]
		private string _qq;

		/// <summary>
		/// @的 QQ 号，all 表示全体成员
		/// </summary>
		[JsonIgnore]
		public string QQ
		{
			get
			{
				return _qq;
			}
			internal set
			{
				RawData["qq"] = _qq = value;
			}
		}

		/// <summary>
		/// 创建<a href="https://github.com/botuniverse/onebot-11/blob/master/message/segment.md#%E6%9F%90%E4%BA%BA">@某人段消息</a>
		/// </summary>
		/// <param name="qq">QQ 表情 ID<br/>参考：<a href="https://github.com/kyubotics/coolq-http-api/wiki/%E8%A1%A8%E6%83%85-CQ-%E7%A0%81-ID-%E8%A1%A8">QQ 表情 ID 表</a></param>
		public AtSegment(string qq)
		{
			Type = "text";
			RawData = new JObject()
			{
				{ "qq", qq },
			};
			_qq = qq;
		}

		/// <inheritdoc/>
		public override string ToString()
		{
			return $"[CQ:at,qq={_qq}]";
		}
	}
}
