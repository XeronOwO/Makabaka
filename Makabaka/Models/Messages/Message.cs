using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.Messages
{
	/// <summary>
	/// 消息，由一个或多个<see cref="Segment"/>组成
	/// </summary>
	public class Message : List<Segment>
	{
		/// <summary>
		/// 转换为字符串<br/>
		/// 注：如果非文本信息，会转化为CQ Code
		/// </summary>
		/// <returns>字符串</returns>
		public override string ToString()
		{
			var sb = new StringBuilder();
			foreach (var segment in this)
			{
				sb.Append(segment.ToString());
			}
			return sb.ToString();
		}

		/// <summary>
		/// 隐式转换为字符串<br/>
		/// 注：如果非文本信息，会转化为CQ Code
		/// </summary>
		/// <param name="segment">字符串</param>
		public static implicit operator string(Message segment)
		{
			return segment.ToString();
		}

		internal void PostProcessMessage()
		{
			for (int i = 0; i < Count; i++)
			{
				this[i] = this[i].PostProcessSegment();
			}
		}
	}
}
