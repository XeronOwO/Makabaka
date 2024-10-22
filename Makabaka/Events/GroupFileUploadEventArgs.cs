using Makabaka.Models;

namespace Makabaka.Events
{
	/// <summary>
	/// 群文件上传事件参数
	/// </summary>
	public class GroupFileUploadEventArgs : NoticeEventArgs
	{
		/// <summary>
		/// 群号
		/// </summary>
		public long GroupId { get; set; }

		/// <summary>
		/// 发送者 QQ 号
		/// </summary>
		public long UserId { get; set; }

		/// <summary>
		/// 文件信息
		/// </summary>
		public UploadGroupFileInfo File { get; set; } = new();
	}
}
