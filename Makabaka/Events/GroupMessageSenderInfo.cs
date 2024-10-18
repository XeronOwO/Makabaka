namespace Makabaka.Events
{
	/// <summary>
	/// 群消息发送者信息<br/>
	/// 需要注意的是，sender 中的各字段是尽最大努力提供的，也就是说，不保证每个字段都一定存在，也不保证存在的字段都是完全正确的（缓存可能过期）。
	/// </summary>
	public class GroupMessageSenderInfo : MessageSenderInfo
	{
		/// <summary>
		/// 群名片／备注
		/// </summary>
		public string Card { get; set; } = string.Empty;

		/// <summary>
		/// 地区
		/// </summary>
		public string Area { get; set; } = string.Empty;

		/// <summary>
		/// 成员等级
		/// </summary>
		public string Level { get; set; } = string.Empty;

		/// <summary>
		/// 角色
		/// </summary>
		public GroupRole Role { get; set; }

		/// <summary>
		/// 专属头衔
		/// </summary>
		public string Title { get; set; } = string.Empty;
	}
}
