using Newtonsoft.Json;

namespace Makabaka.Models.API.Responses
{
	/// <summary>
	/// 获取群文件资源链接结果
	/// </summary>
	public class GetGroupFileUrlRes
	{
		/// <summary>
		/// 文件下载链接
		/// </summary>
		[JsonProperty("url")]
		public string Url { get; set; }
	}
}
