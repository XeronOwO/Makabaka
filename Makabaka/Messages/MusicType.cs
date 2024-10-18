using System.Text.Json.Serialization;

namespace Makabaka.Messages
{
	/// <summary>
	/// 音乐源类型
	/// </summary>
	public enum MusicType
	{
		/// <summary>
		/// QQ 音乐
		/// </summary>
		Qq,

		/// <summary>
		/// 网易云音乐
		/// </summary>
		[JsonPropertyName("163")]
		Netease,

		/// <summary>
		/// 虾米音乐
		/// </summary>
		[JsonPropertyName("xm")]
		Xiami,

		/// <summary>
		/// 自定义音乐
		/// </summary>
		Custom,
	}
}
