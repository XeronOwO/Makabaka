﻿using Makabaka.Models.API.Responses;
using Makabaka.Models.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Makabaka.Models.EventArgs
{
	/// <summary>
	/// <a href="https://github.com/botuniverse/onebot-11/blob/master/event/notice.md#%E7%BE%A4%E6%B6%88%E6%81%AF%E6%92%A4%E5%9B%9E">群消息撤回</a>事件参数
	/// </summary>
	public class GroupRecallMessageEventArgs : NoticeEventArgs, IReply
	{
		/// <summary>
		/// 群号
		/// </summary>
		[JsonProperty("group_id")]
		public long GroupId { get; internal set; }

		/// <summary>
		/// 被禁言 QQ 号
		/// </summary>
		[JsonProperty("user_id")]
		public long UserId { get; internal set; }

		/// <summary>
		/// 操作者 QQ 号
		/// </summary>
		[JsonProperty("operator_id")]
		public long OperatorId { get; internal set; }

		/// <summary>
		/// 操作者 QQ 号
		/// </summary>
		[JsonProperty("message_id")]
		public long MessageId { get; internal set; }

		/// <inheritdoc/>
		public Task<APIResponse<MessageIdRes>> ReplyAsync(Message message)
		{
			return Context.SendGroupMessageAsync(GroupId, message);
		}
	}
}
