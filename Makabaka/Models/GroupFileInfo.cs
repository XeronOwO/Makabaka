namespace Makabaka.Models
{
	/// <summary>
	/// 群文件信息
	/// </summary>
	public class GroupFileInfo
	{
		/// <summary>
		/// 文件 ID
		/// </summary>
		public string Id { get; set; } = string.Empty;

		/// <summary>
		/// 文件名
		/// </summary>
		public string Name { get; set; } = string.Empty;

		/// <summary>
		/// 文件大小（字节数）
		/// </summary>
		public long Size { get; set; }

		/// <summary>
		/// busid（目前不清楚有什么作用）
		/// </summary>
		public long Busid { get; set; }

		/// <summary>
		/// [Lagrange拓展] 文件 URL
		/// </summary>
		public string Url { get; set; } = string.Empty;
	}
}
