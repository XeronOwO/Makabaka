using Makabaka.Events;

namespace Makabaka.API
{
	/// <summary>
	/// 获取陌生人信息响应数据
	/// </summary>
	public class GetStrangerInfoResponseData
	{
		/// <summary>
		/// QQ 号
		/// </summary>
		public long UserId { get; set; }

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
