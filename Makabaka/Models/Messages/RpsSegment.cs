using Makabaka.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.Messages
{
	/// <summary>
	/// <a href="https://github.com/botuniverse/onebot-11/blob/master/message/segment.md#%E7%8C%9C%E6%8B%B3%E9%AD%94%E6%B3%95%E8%A1%A8%E6%83%85">猜拳魔法表情段消息</a>
	/// </summary>
	public class RpsSegment : Segment
	{
		/// <summary>
		/// 创建<a href="https://github.com/botuniverse/onebot-11/blob/master/message/segment.md#%E7%8C%9C%E6%8B%B3%E9%AD%94%E6%B3%95%E8%A1%A8%E6%83%85">猜拳魔法表情段消息</a>
		/// </summary>
		public RpsSegment()
		{
			Type = "rps";
		}

		/// <inheritdoc/>
		public override string ToString()
		{
			return $"[CQ:{Type}]";
		}
	}
}
