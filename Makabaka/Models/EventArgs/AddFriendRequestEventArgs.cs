using Makabaka.Models.API.Responses;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Makabaka.Models.EventArgs
{
	/// <summary>
	/// <a href="https://github.com/botuniverse/onebot-11/blob/master/event/request.md#%E5%8A%A0%E5%A5%BD%E5%8F%8B%E8%AF%B7%E6%B1%82">加好友请求</a>事件参数
	/// </summary>
	public class AddFriendRequestEventArgs : RequestEventArgs
	{
		/// <summary>
		/// 发送请求的 QQ 号
		/// </summary>
		[JsonProperty("user_id")]
		public long UserId { get; internal set; }

		/// <summary>
		/// 验证信息
		/// </summary>
		[JsonProperty("comment")]
		public string Comment { get; internal set; }

		/// <summary>
		/// 请求 flag，在调用处理请求的 API 时需要传入
		/// </summary>
		[JsonProperty("flag")]
		public string Flag { get; internal set; }

		/// <summary>
		/// 同意请求
		/// </summary>
		/// <param name="remark">添加后的好友备注（仅在同意时有效）</param>
		/// <returns>空信息响应</returns>
		public Task<APIResponse<EmptyInfo>> AcceptAsync(string remark = null)
		{
			return Session.SetFriendAddRequestAsync(Flag, true, remark);
		}

		/// <summary>
		/// 拒绝请求
		/// </summary>
		/// <returns>空信息响应</returns>
		public Task<APIResponse<EmptyInfo>> DenyAsync()
		{
			return Session.SetFriendAddRequestAsync(Flag, false);
		}
	}
}
