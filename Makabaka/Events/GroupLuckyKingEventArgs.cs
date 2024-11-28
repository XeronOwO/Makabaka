namespace Makabaka.Events
{
	/// <summary>
	/// 群红包运气王事件参数
	/// </summary>
	public class GroupLuckyKingEventArgs : NotifyEventArgs
	{
		/// <summary>
		/// 群号
		/// </summary>
		public ulong GroupId { get; set; }

		/// <summary>
		/// 红包发送者 QQ 号
		/// </summary>
		public ulong UserId { get; set; }

		/// <summary>
		/// 运气王 QQ 号
		/// </summary>
		public ulong TargetId { get; set; }
	}
}
