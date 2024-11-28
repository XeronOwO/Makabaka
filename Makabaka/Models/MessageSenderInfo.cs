namespace Makabaka.Models
{
	/// <summary>
	/// 消息发送者信息<br/>
	/// 需要注意的是，sender 中的各字段是尽最大努力提供的，也就是说，不保证每个字段都一定存在，也不保证存在的字段都是完全正确的（缓存可能过期）。
	/// </summary>
	public class MessageSenderInfo
	{
		/// <summary>
		/// 发送者 QQ 号
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
