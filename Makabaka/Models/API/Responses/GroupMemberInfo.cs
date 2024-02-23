using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.API.Responses
{
	/// <summary>
	/// 群成员信息
	/// </summary>
	public class GroupMemberInfo
	{
		/// <summary>
		/// 群号
		/// </summary>
		[JsonProperty("group_id")]
		public long GroupId { get; set; }

		/// <summary>
		/// QQ 号
		/// </summary>
		[JsonProperty("user_id")]
		public long UserId { get; set; }

		/// <summary>
		/// 昵称
		/// </summary>
		[JsonProperty("nickname")]
		public string Nickname { get; set; }

		/// <summary>
		/// 群名片／备注
		/// </summary>
		[JsonProperty("card")]
		public string Card { get; set; }

		/// <summary>
		/// 性别，male 或 female 或 unknown
		/// </summary>
		[JsonProperty("sex")]
		public SexType Sex { get; set; }

		/// <summary>
		/// 年龄
		/// </summary>
		[JsonProperty("age")]
		public int Age { get; set; }

		/// <summary>
		/// 地区
		/// </summary>
		[JsonProperty("area")]
		public string Area { get; set; }

		/// <summary>
		/// 加群时间戳
		/// </summary>
		[JsonProperty("join_time")]
		public long JoinTime { get; set; }

		/// <summary>
		/// 最后发言时间戳
		/// </summary>
		[JsonProperty("last_sent_time")]
		public long LastSentTime { get; set; }

		/// <summary>
		/// 成员等级
		/// </summary>
		[JsonProperty("level")]
		public string Level { get; set; }

		/// <summary>
		/// 角色，owner 或 admin 或 member
		/// </summary>
		[JsonProperty("role")]
		public RoleType Role { get; set; }

		/// <summary>
		/// 是否不良记录成员
		/// </summary>
		[JsonProperty("unfriendly")]
		public bool Unfriendly { get; set; }

		/// <summary>
		/// 专属头衔
		/// </summary>
		[JsonProperty("title")]
		public string Title { get; set; }

		/// <summary>
		/// 专属头衔过期时间戳
		/// </summary>
		[JsonProperty("title_expire_time")]
		public long TitleExpireTime { get; set; }

		/// <summary>
		/// 是否允许修改群名片
		/// </summary>
		[JsonProperty("card_changeable")]
		public bool CardChangeable { get; set; }
	}
}
