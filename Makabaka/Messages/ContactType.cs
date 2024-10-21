using System.Text.Json.Serialization;

namespace Makabaka.Messages
{
	/// <summary>
	/// 推荐类型
	/// </summary>
	public enum ContactType
	{
		/// <summary>
		/// 推荐好友
		/// </summary>
		[JsonPropertyName("qq")]
		QQ,

		/// <summary>
		/// 推荐群
		/// </summary>
		Group,
	}
}
