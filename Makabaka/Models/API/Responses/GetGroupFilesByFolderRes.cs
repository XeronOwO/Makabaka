using Newtonsoft.Json;
using System.Collections.Generic;

namespace Makabaka.Models.API.Responses
{
	/// <summary>
	/// 获取群子目录文件列表响应
	/// </summary>
	public class GetGroupFilesByFolderRes
	{
		/// <summary>
		/// 文件列表
		/// </summary>
		[JsonProperty("files")]
		public List<GroupFileInfo> Files { get; set; }

		/// <summary>
		/// 文件夹列表
		/// </summary>
		[JsonProperty("folders")]
		public List<GroupFolderInfo> Folders { get; set; }
	}
}
