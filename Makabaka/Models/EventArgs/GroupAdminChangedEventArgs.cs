using Makabaka.Models.API.Responses;
using Makabaka.Models.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Makabaka.Models.EventArgs
{
	/// <summary>
	/// <a href="https://github.com/botuniverse/onebot-11/blob/master/event/notice.md#%E7%BE%A4%E7%AE%A1%E7%90%86%E5%91%98%E5%8F%98%E5%8A%A8">群管理员变动</a>事件参数
	/// </summary>
	public class GroupAdminChangedEventArgs : NoticeEventArgs, IReply
	{
		/// <summary>
		/// 事件子类型，分别表示设置和取消管理员<br/>可能的值：set、unset
		/// </summary>
		[JsonProperty("sub_type")]
		public string SubType { get; set; }

		/// <summary>
		/// 群号
		/// </summary>
		[JsonProperty("group_id")]
		public long GroupId { get; set; }

		/// <summary>
		/// 管理员 QQ 号
		/// </summary>
		[JsonProperty("user_id")]
		public long UserId { get; set; }

		/// <inheritdoc/>
		public async Task<APIResponse<MessageIdInfo>> Reply(Message message)
		{
			return await Session.SendGroupMessageAsync(GroupId, message);
		}
	}
}
