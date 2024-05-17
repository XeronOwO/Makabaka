using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

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
				if (segment != null)
				{
					sb.Append(segment.ToString());
				}
			}
			return sb.ToString();
		}

		/// <summary>
		/// 隐式转换为字符串<br/>
		/// 注：如果非文本信息，会转化为CQ Code
		/// </summary>
		/// <param name="message">消息</param>
		public static implicit operator string(Message message)
		{
			return message.ToString();
		}

		/// <summary>
		/// 用于在使用<see cref="JsonConvert.DeserializeObject{T}(string)"/>反序列化消息后，对消息段进行后处理（例如，将<see cref="Segment"/>转换为特定的<see cref="TextSegment"/>，以此类推）<br/>如果您不会使用，请不要调用
		/// </summary>
		public void PostProcessMessage()
		{
			for (int i = 0; i < Count; i++)
			{
				this[i] = this[i].PostProcessSegment();
			}
		}
	}
}
