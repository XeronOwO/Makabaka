namespace Makabaka.Models
{
	/// <summary>
	/// 群成员信息
	/// </summary>
	public class GroupMemberInfo
	{
		/// <summary>
		/// 群号
		/// </summary>
		public long GroupId { get; set; }

		/// <summary>
		/// QQ 号
		/// </summary>
		public long UserId { get; set; }

		/// <summary>
		/// 昵称
		/// </summary>
		public string Nickname { get; set; } = string.Empty;

		/// <summary>
		/// 群名片／备注
		/// </summary>
		public string? Card { get; set; } = string.Empty;

		/// <summary>
		/// 性别
		/// </summary>
		public SexType Sex { get; set; }

		/// <summary>
		/// 年龄
		/// </summary>
		public int Age { get; set; }

		/// <summary>
		/// 地区
		/// </summary>
		public string Area { get; set; } = string.Empty;

		/// <summary>
		/// 加群时间戳
		/// </summary>
		public long JoinTime { get; set; }

		/// <summary>
		/// 最后发言时间戳
		/// </summary>
		public long LastSentTime { get; set; }

		/// <summary>
		/// 成员等级
		/// </summary>
		public string Level { get; set; } = string.Empty;

		/// <summary>
		/// 角色
		/// </summary>
		public GroupRoleType Role { get; set; }

		/// <summary>
		/// 是否不良记录成员
		/// </summary>
		public bool Unfriendly { get; set; }

		/// <summary>
		/// 专属头衔
		/// </summary>
		public string Title { get; set; } = string.Empty;

		/// <summary>
		/// 专属头衔过期时间戳
		/// </summary>
		public long TitleExpireTime { get; set; }

		/// <summary>
		/// 是否允许修改群名片
		/// </summary>
		public bool CardChangeable { get; set; }
	}
}
