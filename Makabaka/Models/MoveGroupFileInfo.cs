using System.Text.Json.Serialization;

namespace Makabaka.Models
{
	/// <summary>
	/// 移动群文件信息
	/// </summary>
	public class MoveGroupFileInfo
	{
		/// <summary>
		/// 消息
		/// </summary>
		[JsonPropertyName("msg")]
		public string Message { get; set; } = string.Empty;
	}
}
