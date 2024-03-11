using Newtonsoft.Json;

namespace Makabaka.Models.EventArgs
{
	/// <summary>
	/// 文件信息
	/// </summary>
	public class FileInfo
	{
		/// <summary>
		/// 文件 ID
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; internal set; }

		/// <summary>
		/// 文件名
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; internal set; }

		/// <summary>
		/// 文件大小（字节数）
		/// </summary>
		[JsonProperty("size")]
		public long Size { get; internal set; }

		/// <summary>
		/// busid（目前不清楚有什么作用）
		/// </summary>
		[JsonProperty("busid")]
		public long Busid { get; internal set; }
	}
}
