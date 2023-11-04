using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.FastActions
{
	/// <summary>
	/// 添加好友请求快速操作
	/// </summary>
	public class AddFriendRequestFastAction : IFastAction
	{
		/// <summary>
		/// 是否同意请求<br/>
		/// 默认情况：不处理
		/// </summary>
		[JsonProperty("approve")]
		public bool? Approve { get; set; }

		/// <summary>
		/// 添加后的好友备注（仅在同意时有效）<br/>
		/// 默认情况：无备注
		/// </summary>
		[JsonProperty("remark")]
		public string Remark { get; set; }

		/// <summary>
		/// 创建添加好友请求快速操作
		/// </summary>
		/// <param name="approve">是否同意请求<br/>默认情况：不处理</param>
		/// <param name="remark">添加后的好友备注（仅在同意时有效）<br/>默认情况：无备注</param>
		public AddFriendRequestFastAction(bool? approve, string remark)
		{
			Approve = approve;
			Remark = remark;
		}
	}
}
