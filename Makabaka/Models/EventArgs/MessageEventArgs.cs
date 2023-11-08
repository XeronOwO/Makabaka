using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.EventArgs
{
	/// <summary>
	/// 消息事件参数
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
