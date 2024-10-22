using System.Text.Json.Serialization;

namespace Makabaka.Models
{
	/// <summary>
	/// 操作群文件信息
	/// </summary>
	public class OperateGroupFileInfo
	{
		/// <summary>
		/// 消息
		/// </summary>
		[JsonPropertyName("msg")]
		public string Message { get; set; } = string.Empty;
	}
}
