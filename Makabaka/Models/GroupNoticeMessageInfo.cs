namespace Makabaka.Models
{
	/// <summary>
	/// 群公告消息信息
	/// </summary>
	public class GroupNoticeMessageInfo
	{
		/// <summary>
		/// 文本
		/// </summary>
		public string Text { get; set; } = string.Empty;

		/// <summary>
		/// 图片列表
		/// </summary>
		public GroupNoticeImageInfo[] Images { get; set; } = [];
	}
}
