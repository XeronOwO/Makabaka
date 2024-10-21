using System;
using System.Text.Json.Serialization;

namespace Makabaka.Models
{
	/// <summary>
	/// 文件信息
	/// </summary>
	public class OnebotFileInfo
	{
		/// <summary>
		/// 群聊 ID
		/// </summary>
		public long GroupId { get; set; }

		/// <summary>
		/// 文件 ID
		/// </summary>
		public string FileId { get; set; } = string.Empty;

		/// <summary>
		/// 文件名
		/// </summary>
		public string FileName { get; set; } = string.Empty;

		/// <summary>
		/// BusId
		/// </summary>
		[JsonPropertyName("busid")]
		public int BusId { get; set; }

		/// <summary>
		/// 文件大小
		/// </summary>
		public ulong FileSize { get; set; }

		/// <summary>
		/// 上传时间
		/// </summary>
		public DateTime UploadTime { get; set; }

		/// <summary>
		/// 过期时间
		/// </summary>
		public DateTime DeadTime { get; set; }

		/// <summary>
		/// 修改时间
		/// </summary>
		public DateTime ModifyTime { get; set; }

		/// <summary>
		/// 下载次数
		/// </summary>
		public uint DownloadTimes { get; set; }

		/// <summary>
		/// 上传者
		/// </summary>
		public long Uploader { get; set; }

		/// <summary>
		/// 上传者名称
		/// </summary>
		public string UploaderName { get; set; } = string.Empty;
	}
}
