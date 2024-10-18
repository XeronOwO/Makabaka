namespace Makabaka.Events
{
	/// <summary>
	/// 通知事件类型
	/// </summary>
	public enum NoticeEventType
	{
		/// <summary>
		/// 群文件上传
		/// </summary>
		GroupUpload,

		/// <summary>
		/// 群管理员变动
		/// </summary>
		GroupAdmin,

		/// <summary>
		/// 群成员减少
		/// </summary>
		GroupDecrease,

		/// <summary>
		/// 群成员增加
		/// </summary>
		GroupIncrease,

		/// <summary>
		/// 群禁言
		/// </summary>
		GroupBan,

		/// <summary>
		/// 好友添加
		/// </summary>
		FriendAdd,

		/// <summary>
		/// 群消息撤回
		/// </summary>
		GroupRecall,

		/// <summary>
		/// 好友消息撤回
		/// </summary>
		FriendRecall,

		/// <summary>
		/// 群内通知
		/// </summary>
		Notify,

		/// <summary>
		/// 群表情回应
		/// </summary>
		Reaction,
	}
}
