using System;

namespace Makabaka.Models
{
	/// <summary>
	/// 文件夹信息
	/// </summary>
	public class OnebotFolderInfo
	{
		/// <summary>
		/// 群号
		/// </summary>
		public ulong GroupId { get; set; }

		/// <summary>
		/// 文件夹 ID
		/// </summary>
		public string FolderId { get; set; } = string.Empty;

		/// <summary>
		/// 文件夹名
		/// </summary>
		public string FolderName { get; set; } = string.Empty;

		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime CreateTime { get; set; }

		/// <summary>
		/// 创建者
		/// </summary>
		public ulong Creator { get; set; }

		/// <summary>
		/// 创建者名称
		/// </summary>
		public string CreateName { get; set; } = string.Empty;

		/// <summary>
		/// 所有文件数
		/// </summary>
		public uint TotalFileCount { get; set; }
	}
}
