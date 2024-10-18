namespace Makabaka.Events
{
	/// <summary>
	/// 群成员减少类型
	/// </summary>
	public enum GroupMemberDecreaseEventType
	{
		/// <summary>
		/// 主动退群
		/// </summary>
		Leave,

		/// <summary>
		/// 成员被踢
		/// </summary>
		Kick,

		/// <summary>
		/// 登录号被踢
		/// </summary>
		KickMe,
	}
}
