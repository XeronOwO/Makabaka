using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.Messages
{
	/// <summary>
	/// <a href="https://github.com/botuniverse/onebot-11/blob/master/message/segment.md#%E6%8E%B7%E9%AA%B0%E5%AD%90%E9%AD%94%E6%B3%95%E8%A1%A8%E6%83%85">掷骰子魔法表情段消息</a>
	/// </summary>
	public class DiceSegment : Segment
	{
		/// <summary>
		/// 创建<a href="https://github.com/botuniverse/onebot-11/blob/master/message/segment.md#%E6%8E%B7%E9%AA%B0%E5%AD%90%E9%AD%94%E6%B3%95%E8%A1%A8%E6%83%85">掷骰子魔法表情段消息</a>
		/// </summary>
		public DiceSegment()
		{
			Type = "dice";
		}

		/// <inheritdoc/>
		public override string ToString()
		{
			return $"[CQ:{Type}]";
		}
	}
}
