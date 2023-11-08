using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.EventArgs
{
	/// <summary>
	/// <a href="https://github.com/botuniverse/onebot-11/blob/master/event/notice.md">通知事件</a>事件参数
	/// </summary>
	public class NoticeEventArgs : PostEventArgs
	{
		/// <summary>
		/// 通知类型
		/// </summary>
		[JsonProperty("notice_type")]
		public string NoticeType { get; internal set; }
	}
}
