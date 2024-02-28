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
	/// <a href="https://github.com/botuniverse/onebot-11/blob/master/event/notice.md#%E7%BE%A4%E7%A6%81%E8%A8%80">群禁言</a>事件参数
	/// </summary>
	public class GroupMuteEventArgs : NoticeEventArgs, IReply
	{
		/// <summary>
		/// 事件子类型，分别表示禁言、解除禁言<br/>可能的值：ban、lift_ban
		/// </summary>
		[JsonProperty("sub_type")]
		public string SubType { get; internal set; }

		/// <summary>
		/// 群号
		/// </summary>
		[JsonProperty("group_id")]
		public long GroupId { get; internal set; }

		/// <summary>
		/// 操作者 QQ 号
		/// </summary>
		[JsonProperty("operator_id")]
		public long OperatorId { get; internal set; }

		/// <summary>
		/// 被禁言 QQ 号
		/// </summary>
		[JsonProperty("user_id")]
		public long UserId { get; internal set; }

		/// <summary>
		/// 禁言时长，单位秒
		/// </summary>
		[JsonProperty("duration")]
		public long Duration { get; internal set; }

		/// <inheritdoc/>
		public Task<APIResponse<MessageIdRes>> ReplyAsync(Message message)
		{
			return Context.SendGroupMessageAsync(GroupId, message);
		}
	}
}
