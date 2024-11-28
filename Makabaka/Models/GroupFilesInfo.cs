namespace Makabaka.Models
{
	/// <summary>
	/// 群文件信息
	/// </summary>
	public class GroupFilesInfo
	{
		/// <summary>
		/// 文件列表
		/// </summary>
		public OnebotFileInfo[] Files { get; set; } = [];

		/// <summary>
		/// 文件夹列表
		/// </summary>
		public OnebotFolderInfo[] Folders { get; set; } = [];
	}
}
