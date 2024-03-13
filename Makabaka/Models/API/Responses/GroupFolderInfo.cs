using Newtonsoft.Json;

namespace Makabaka.Models.API.Responses
{
	/// <summary>
	/// 群文件夹信息
	/// </summary>
	public class GroupFolderInfo
	{
		/// <summary>
		/// 群号
		/// </summary>
		[JsonProperty("group_id")]
		public long GroupId { get; set; }

		/// <summary>
		/// 文件夹ID
		/// </summary>
		[JsonProperty("folder_id")]
		public string FolderId { get; set; }

		/// <summary>
		/// 文件名
		/// </summary>
		[JsonProperty("folder_name")]
		public string FolderName { get; set; }

		/// <summary>
		/// 创建时间
		/// </summary>
		[JsonProperty("create_time")]
		public long CreateTime { get; set; }

		/// <summary>
		/// 创建者
		/// </summary>
		[JsonProperty("creator")]
		public long Creator { get; set; }

		/// <summary>
		/// 创建者名字
		/// </summary>
		[JsonProperty("creator_name")]
		public string CreatorName { get; set; }

		/// <summary>
		/// 子文件数量
		/// </summary>
		[JsonProperty("total_file_count")]
		public int TotalFileCount { get; set; }
	}
}
