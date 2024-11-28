namespace Makabaka.Events
{
	/// <summary>
	/// 群内戳一戳事件参数
	/// </summary>
	public class GroupPokeEventArgs : NotifyEventArgs
	{
		/// <summary>
		/// 群号
		/// </summary>
		public ulong GroupId { get; set; }

		/// <summary>
		/// 发送者 QQ 号
		/// </summary>
		public ulong UserId { get; set; }

		/// <summary>
		/// 被戳者 QQ 号
		/// </summary>
		public ulong TargetId { get; set; }
	}
}
