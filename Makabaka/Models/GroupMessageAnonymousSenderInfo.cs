namespace Makabaka.Models
{
	/// <summary>
	/// 群消息匿名发送者信息
	/// </summary>
	public class GroupMessageAnonymousSenderInfo
	{
		/// <summary>
		/// 匿名用户 ID
		/// </summary>
		public ulong Id { get; set; }

		/// <summary>
		/// 匿名用户名称
		/// </summary>
		public string Name { get; set; } = string.Empty;

		/// <summary>
		/// 匿名用户 flag，在调用禁言 API 时需要传入
		/// </summary>
		public string Flag { get; set; } = string.Empty;
	}
}
