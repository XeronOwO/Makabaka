using System.Text.Json.Serialization;

namespace Makabaka.Messages
{
	/// <summary>
	/// @某人数据
	/// </summary>
	public class AtData
	{
		/// <summary>
		/// @的 QQ 号，all 表示全体成员
		/// </summary>
		[JsonPropertyName("qq")]
		public string QQ { get; set; } = string.Empty;

		/// <summary>
		/// [Lagrange拓展] @的名称
		/// </summary>
		public string? Name { get; set; } = string.Empty;
	}
}
