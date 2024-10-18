namespace Makabaka.Events
{
	/// <summary>
	/// 加好友请求事件参数
	/// </summary>
	public class FriendAddRequestEventArgs : RequestEventArgs
	{
		/// <summary>
		/// 发送请求的 QQ 号
		/// </summary>
		public long UserId { get; set; }

		/// <summary>
		/// 验证信息
		/// </summary>
		public string Comment { get; set; } = string.Empty;

		/// <summary>
		/// 请求 flag，在调用处理请求的 API 时需要传入
		/// </summary>
		public string Flag { get; set; } = string.Empty;
	}
}
