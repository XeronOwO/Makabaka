namespace Makabaka.Models
{
	/// <summary>
	/// 龙王信息
	/// </summary>
	public class TalkativeInfo
	{
		/// <summary>
		/// QQ 号
		/// </summary>
		public ulong Uin { get; set; }

		/// <summary>
		/// 昵称
		/// </summary>
		public string Nick { get; set; } = string.Empty;

		/// <summary>
		/// 头像 URL
		/// </summary>
		public string Avatar { get; set; } = string.Empty;

		/// <summary>
		/// 头像尺寸
		/// </summary>
		public int AvatarSize { get; set; }

		/// <summary>
		/// 持续天数
		/// </summary>
		public int DayCount { get; set; }
	}
}
