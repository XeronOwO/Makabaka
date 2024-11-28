namespace Makabaka.Models
{
	/// <summary>
	/// 陌生人信息
	/// </summary>
	public class StrangerInfo
	{
		/// <summary>
		/// QQ 号
		/// </summary>
		public ulong UserId { get; set; }

		/// <summary>
		/// 昵称
		/// </summary>
		public string Nickname { get; set; } = string.Empty;

		/// <summary>
		/// 性别
		/// </summary>
		public SexType Sex { get; set; }

		/// <summary>
		/// 年龄
		/// </summary>
		public int Age { get; set; }
	}
}
