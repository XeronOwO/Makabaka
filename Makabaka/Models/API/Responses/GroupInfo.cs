using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.API.Responses
{
	/// <summary>
	/// 群信息
	/// </summary>
	public class GroupInfo
	{
		/// <summary>
		/// 群号
		/// </summary>
		[JsonProperty("group_id")]
		public long GroupId { get; internal set; }

		/// <summary>
		/// 群名称
		/// </summary>
		[JsonProperty("group_name")]
		public string GroupName { get; internal set; }

		/// <summary>
		/// 成员数
		/// </summary>
		[JsonProperty("member_count")]
		public int MemberCount { get; internal set; }

		/// <summary>
		/// 最大成员数（群容量）
		/// </summary>
		[JsonProperty("max_member_count")]
		public int MaxMemberCount { get; internal set; }
	}
}
