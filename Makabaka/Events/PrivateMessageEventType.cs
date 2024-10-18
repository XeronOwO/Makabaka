namespace Makabaka.Events
{
	/// <summary>
	/// 私聊消息事件子类型
	/// </summary>
	public enum PrivateMessageEventType
	{
		/// <summary>
		/// 好友消息
		/// </summary>
		Friend,

		/// <summary>
		/// 群临时会话消息
		/// </summary>
		Group,

		/// <summary>
		/// 其他消息
		/// </summary>
		Other
	}
}
