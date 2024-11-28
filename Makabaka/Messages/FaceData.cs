using System.Text.Json.Serialization;

namespace Makabaka.Messages
{
	/// <summary>
	/// QQ 表情数据
	/// </summary>
	public class FaceData
	{
		/// <summary>
		/// QQ 表情 ID。见 <a href="https://github.com/richardchien/coolq-http-api/wiki/%E8%A1%A8%E6%83%85-CQ-%E7%A0%81-ID-%E8%A1%A8">QQ 表情 ID 表</a><br/>
		/// ✔ 收<br/>
		/// ✔ 发
		/// </summary>
		public string Id { get; set; } = string.Empty;

		/// <summary>
		/// [Lagrange拓展] 是否是大表情
		/// </summary>
		[JsonPropertyName("large")]
		public bool IsLarge { get; set; } = false;
	}
}
