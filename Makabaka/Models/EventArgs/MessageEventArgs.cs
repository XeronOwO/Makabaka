using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.EventArgs
{
	/// <summary>
	/// <a href="https://github.com/botuniverse/onebot-11/blob/master/event/message.md">消息事件</a>事件参数
	/// </summary>
	public class MessageEventArgs : PostEventArgs
	{
		/// <summary>
		/// 消息类型
		/// </summary>
		[JsonProperty("message_type")]
		public string MessageType { get; internal set; }
	}
}
