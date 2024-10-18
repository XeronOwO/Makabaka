using System.Collections.Generic;
using System.Text;

namespace Makabaka.Messages
{
	/// <summary>
	/// 消息
	/// </summary>
	public class Message : List<Segment>
	{
		/// <inheritdoc/>
		public override string ToString()
		{
			var sb = new StringBuilder();
			foreach (var segment in this)
			{
				sb.Append(segment.ToString());
			}
			return sb.ToString();
		}
	}
}
