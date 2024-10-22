using System.Text.Json.Serialization;

namespace Makabaka.Models
{
	/// <summary>
	/// 群文件系统操作信息
	/// </summary>
	public class GroupFileSystemOperationInfo
	{
		/// <summary>
		/// 消息
		/// </summary>
		[JsonPropertyName("msg")]
		public string Message { get; set; } = string.Empty;
	}
}
