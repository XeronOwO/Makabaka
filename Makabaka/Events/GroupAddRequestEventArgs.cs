namespace Makabaka.Events
{
	/// <summary>
	/// 加群请求／邀请事件参数
	/// </summary>
	public class GroupAddRequestEventArgs : RequestEventArgs
	{
		/// <summary>
		/// 请求子类型，分别表示加群请求、邀请登录号入群
		/// </summary>
		public GroupAddRequestEventType SubType { get; set; }

		/// <summary>
		/// 群号
		/// </summary>
		public long GroupId { get; set; }

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
