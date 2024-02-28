using Newtonsoft.Json;

namespace Makabaka.Models.EventArgs
{
	/// <summary>
	/// <a href="https://github.com/botuniverse/onebot-11/blob/master/event/notice.md#%E5%A5%BD%E5%8F%8B%E6%B7%BB%E5%8A%A0">好友添加</a>事件参数
	/// </summary>
	public class FriendAddEventArgs : NoticeEventArgs
	{
		/// <summary>
		/// 新添加好友 QQ 号
		/// </summary>
		[JsonProperty("user_id")]
		public long UserId { get; internal set; }
	}
}
