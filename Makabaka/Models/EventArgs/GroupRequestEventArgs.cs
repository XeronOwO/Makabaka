using Makabaka.Models.API.Responses;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Makabaka.Models.EventArgs
{
	/// <summary>
	/// <a href="https://github.com/botuniverse/onebot-11/blob/master/event/request.md#%E5%8A%A0%E7%BE%A4%E8%AF%B7%E6%B1%82%E9%82%80%E8%AF%B7">加群请求／邀请</a>事件参数
	/// </summary>
	public class GroupRequestEventArgs : RequestEventArgs
	{
		/// <summary>
		/// 请求子类型，分别表示加群请求、邀请登录号入群
		/// </summary>
		[JsonProperty("sub_type")]
		public string SubType { get; internal set; }

		/// <summary>
		/// 群号
		/// </summary>
		[JsonProperty("group_id")]
		public long GroupId { get; internal set; }

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
		/// <returns>空信息响应</returns>
		public Task<APIResponse<EmptyInfo>> AcceptAsync()
		{
			return Session.SetGroupRequestAsync(Flag, SubType);
		}

		/// <summary>
		/// 拒绝请求
		/// </summary>
		/// <param name="reason">拒绝理由（仅在拒绝时有效）</param>
		/// <returns>空信息响应</returns>
		public Task<APIResponse<EmptyInfo>> DenyAsync(string reason)
		{
			return Session.SetGroupRequestAsync(Flag, SubType, false, reason);
		}
	}
}
