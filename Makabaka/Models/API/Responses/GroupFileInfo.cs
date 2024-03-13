using Newtonsoft.Json;

namespace Makabaka.Models.API.Responses
{
	/// <summary>
	/// 群文件信息
	/// </summary>
	public class GroupFileInfo
	{
		/// <summary>
		/// 群号
		/// </summary>
		[JsonProperty("group_id")]
		public long GroupId { get; set; }

		/// <summary>
		/// 文件ID
		/// </summary>
		[JsonProperty("file_id")]
		public string FileId { get; set; }

		/// <summary>
		/// 文件名
		/// </summary>
		[JsonProperty("file_name")]
		public string FileName { get; set; }

		/// <summary>
		/// 文件类型
		/// </summary>
		[JsonProperty("busid")]
		public int Busid { get; set; }

		/// <summary>
		/// 文件大小
		/// </summary>
		[JsonProperty("file_size")]
		public long FileSize { get; set; }

		/// <summary>
		/// 上传时间
		/// </summary>
		[JsonProperty("upload_time")]
		public long UploadTime { get; set; }

		/// <summary>
		/// 过期时间,永久文件恒为0
		/// </summary>
		[JsonProperty("dead_time")]
		public long DeadTime { get; set; }

		/// <summary>
		/// 最后修改时间
		/// </summary>
		[JsonProperty("modify_time")]
		public long ModifyTime { get; set; }

		/// <summary>
		/// 下载次数
		/// </summary>
		[JsonProperty("download_times")]
		public int DownloadTimes { get; set; }

		/// <summary>
		/// 上传者ID
		/// </summary>
		[JsonProperty("uploader")]
		public long Uploader { get; set; }

		/// <summary>
		/// 上传者名字
		/// </summary>
		[JsonProperty("uploader_name")]
		public string UploaderName { get; set; }
	}
}
