using System.Text.Json.Serialization;

namespace Makabaka.Models
{
	/// <summary>
	///	群成员荣誉信息
	/// </summary>
	public class GroupMemberHonorInfo
	{
		/// <summary>
		/// QQ 号
		/// </summary>
		public ulong Uin { get; set; }

		/// <summary>
		/// 名称
		/// </summary>
		public string Name { get; set; } = string.Empty;

		/// <summary>
		/// 头像 URL
		/// </summary>
		public string Avatar { get; set; } = string.Empty;

		/// <summary>
		/// 荣誉描述
		/// </summary>
		[JsonPropertyName("desc")]
		public string Description { get; set; } = string.Empty;

		/// <summary>
		/// 按钮文本
		/// </summary>
		[JsonPropertyName("btnText")]
		public string ButtonText { get; set; } = string.Empty;

		/// <summary>
		/// 文本
		/// </summary>
		public string Text { get; set; } = string.Empty;
	}
}
