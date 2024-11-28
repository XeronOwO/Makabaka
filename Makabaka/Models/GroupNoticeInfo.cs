using System;

namespace Makabaka.Models
{
	/// <summary>
	/// 群公告信息
	/// </summary>
	public class GroupNoticeInfo
	{
		/// <summary>
		/// 公告 ID
		/// </summary>
		public string NoticeId { get; set; } = string.Empty;

		/// <summary>
		/// 发送者 ID
		/// </summary>
		public ulong SenderId { get; set; }

		/// <summary>
		/// 发送时间
		/// </summary>
		public DateTime PublishTime { get; set; }

		/// <summary>
		/// 公告内容
		/// </summary>
		public GroupNoticeMessageInfo Message { get; set; } = new();
	}
}
