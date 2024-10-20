namespace Makabaka.Models
{
	/// <summary>
	/// 群信息
	/// </summary>
	public class GroupInfo
	{
		/// <summary>
		/// 群号
		/// </summary>
		public long GroupId { get; set; }

		/// <summary>
		/// 群名称
		/// </summary>
		public string GroupName { get; set; } = string.Empty;

		/// <summary>
		/// 成员数
		/// </summary>
		public int MemberCount { get; set; }

		/// <summary>
		/// 最大成员数（群容量）
		/// </summary>
		public int MaxMemberCount { get; set; }
	}
}
