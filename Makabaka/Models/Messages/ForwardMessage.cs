using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.Messages
{
	/// <summary>
	/// 转发消息，由一个或多个<see cref="NodeSegment"/>组成
	/// </summary>
	public class ForwardMessage : List<NodeSegment>
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
		/// <param name="message">消息</param>
		public static implicit operator string(ForwardMessage message)
		{
			return message.ToString();
		}
	}
}
