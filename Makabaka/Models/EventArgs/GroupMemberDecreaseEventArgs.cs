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
	/// <a href="https://github.com/botuniverse/onebot-11/blob/master/event/notice.md#%E7%BE%A4%E6%88%90%E5%91%98%E5%87%8F%E5%B0%91">群成员减少</a>事件参数
	/// </summary>
	public class GroupMemberDecreaseEventArgs : NoticeEventArgs, IReply
	{
		/// <summary>
		/// 事件子类型，分别表示主动退群、成员被踢、登录号被踢<br/>
		/// 可能的值：leave、kick、kick_me
		/// </summary>
		[JsonProperty("sub_type")]
		public string SubType { get; internal set; }

		/// <summary>
		/// 群号
		/// </summary>
		[JsonProperty("group_id")]
		public long GroupId { get; internal set; }

		/// <summary>
		/// 操作者 QQ 号（如果是主动退群，则和 UserId 相同）
		/// </summary>
		[JsonProperty("operator_id")]
		public long OperatorId { get; internal set; }

		/// <summary>
		/// 离开者 QQ 号
		/// </summary>
		[JsonProperty("user_id")]
		public long UserId { get; internal set; }

		/// <inheritdoc/>
		public Task<APIResponse<MessageIdInfo>> ReplyAsync(Message message)
		{
			return Session.SendGroupMessageAsync(GroupId, message);
		}
	}
}
