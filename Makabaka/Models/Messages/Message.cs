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
		public override string ToString()
		{
			var sb = new StringBuilder();
			foreach (var segment in this)
			{
				sb.Append(segment.ToString());
			}
			return sb.ToString();
		}

		public static implicit operator string(Message segment)
		{
			return segment.ToString();
		}
	}
}
