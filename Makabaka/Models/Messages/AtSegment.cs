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
			set
			{
				RawData["qq"] = _qq = value;
			}
		}

		/// <summary>
		/// 创建<a href="https://github.com/botuniverse/onebot-11/blob/master/message/segment.md#%E6%9F%90%E4%BA%BA">@某人段消息</a>
		/// </summary>
		/// <param name="qq">@的 QQ 号，all 表示全体成员</param>
		public AtSegment(string qq)
		{
			Type = "text";
			RawData = new JObject()
			{
				{ "qq", qq },
			};
			_qq = qq;
		}

		/// <summary>
		/// 创建<a href="https://github.com/botuniverse/onebot-11/blob/master/message/segment.md#%E6%9F%90%E4%BA%BA">@某人段消息</a>
		/// </summary>
		/// <param name="qq">@的 QQ 号，all 表示全体成员</param>
		public AtSegment(long qq) : this(qq.ToString())
		{
			
		}

		/// <inheritdoc/>
		public override string ToString()
		{
			return $"[CQ:at,qq={_qq}]";
		}
	}
}
