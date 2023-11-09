using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.EventArgs
{
	/// <summary>
	/// <a href="https://github.com/botuniverse/onebot-11/blob/master/event/notice.md#%E7%BE%A4%E6%88%90%E5%91%98%E5%A2%9E%E5%8A%A0">群成员增加</a>事件参数
	/// </summary>
	public class GroupMemberIncreaseEventArgs : NoticeEventArgs
	{
		/// <summary>
		/// 事件子类型，分别表示管理员已同意入群、管理员邀请入群<br/>
		/// 可能的值：approve、invite	
		/// </summary>
		[JsonProperty("sub_type")]
		public string SubType { get; internal set; }

		/// <summary>
		/// 群号
		/// </summary>
		[JsonProperty("group_id")]
		public long GroupId { get; internal set; }

		/// <summary>
		/// 操作者 QQ 号（如果是主动退群，则和 UserId 相同）
		/// </summary>
		[JsonProperty("operator_id")]
		public long OperatorId { get; internal set; }

		/// <summary>
		/// 加入者 QQ 号
		/// </summary>
		[JsonProperty("user_id")]
		public long UserId { get; internal set; }
	}
}
