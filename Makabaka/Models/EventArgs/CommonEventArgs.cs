using Makabaka.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.EventArgs
{
	public class CommonEventArgs : TypeEventArgs
	{
		/// <summary>
		/// 事件发生的时间戳
		/// </summary>
		[JsonProperty("time")]
		public long Time { get; internal set; }

		/// <summary>
		/// 事件发生的时间点
		/// </summary>
		[JsonIgnore]
		public DateTime DateTime => Time.ToDateTime();

		/// <summary>
		/// 收到事件的机器人 QQ 号
		/// </summary>
		[JsonProperty("self_id")]
		public long SelfId { get; internal set; }
	}
}
