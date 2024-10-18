namespace Makabaka.Events
{
	/// <summary>
	/// 群成员荣誉变动事件参数
	/// </summary>
	public class GroupMemberHonorChangeEventArgs : NotifyEventArgs
	{
		/// <summary>
		/// 群号
		/// </summary>
		public long GroupId { get; set; }

		/// <summary>
		/// 荣誉类型，分别表示龙王、群聊之火、快乐源泉
		/// </summary>
		public GroupHonorType HonorType { get; set; }

		/// <summary>
		/// 成员 QQ 号
		/// </summary>
		public long UserId { get; set; }
	}
}
