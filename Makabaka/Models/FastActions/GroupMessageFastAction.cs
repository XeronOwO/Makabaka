using Makabaka.Models.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.FastActions
{
	/// <summary>
	/// <a href="https://github.com/botuniverse/onebot-11/blob/master/event/message.md#%E5%BF%AB%E9%80%9F%E6%93%8D%E4%BD%9C-1">群消息快速操作</a><br/>
	/// 当收到群消息后，可以使用此快速操作
	/// </summary>
	public class GroupMessageFastAction : IFastAction
	{
		/// <summary>
		/// 要回复的内容<br/>
		/// 默认情况：不回复
		/// </summary>
		[JsonProperty("reply")]
		public Message Message { get; set; }

		/// <summary>
		/// 消息内容是否作为纯文本发送（即不解析 CQ 码），只在 reply 字段是字符串时有效<br/>
		/// 默认情况：不转义<br/>
		/// <a href="https://github.com/LagrangeDev/Lagrange.Core">Lagrange.Core</a> 暂不支持该功能，强制设为 false
		/// </summary>
		[JsonProperty("auto_escape")]
		public bool AutoEscape { get; }

		/// <summary>
		/// 是否要在回复开头 at 发送者（自动添加），发送者是匿名用户时无效<br/>
		/// 默认情况：at 发送者
		/// </summary>
		[JsonProperty("at_sender")]
		public bool AtSender { get; set; }

		/// <summary>
		/// 撤回该条消息<br/>
		/// 默认情况：不撤回
		/// </summary>
		[JsonProperty("delete")]
		public bool Delete { get; set; }

		/// <summary>
		/// 把发送者踢出群组（需要登录号权限足够），<strong>不拒绝</strong>此人后续加群请求，发送者是匿名用户时无效<br/>
		/// 默认情况：不踢
		/// </summary>
		[JsonProperty("kick")]
		public bool Kick { get; set; }

		/// <summary>
		/// 把发送者禁言 ban_duration 指定时长，对匿名用户也有效<br/>
		/// 默认情况：不禁言
		/// </summary>
		[JsonProperty("ban")]
		public bool Ban { get; set; }

		/// <summary>
		/// 禁言时长<br/>
		/// 默认情况：30 分钟
		/// </summary>
		[JsonProperty("ban_duration")]
		public int BanDuration { get; set; }

		/// <summary>
		/// 创建群消息快速操作
		/// </summary>
		/// <param name="message">要回复的内容<br/>默认情况：不回复</param>
		/// <param name="atSender">是否要在回复开头 at 发送者（自动添加），发送者是匿名用户时无效<br/>默认情况：at 发送者</param>
		/// <param name="delete">撤回该条消息<br/>默认情况：不撤回</param>
		/// <param name="kick">把发送者踢出群组（需要登录号权限足够），<strong>不拒绝</strong>此人后续加群请求，发送者是匿名用户时无效<br/>默认情况：不踢</param>
		/// <param name="ban">把发送者禁言 ban_duration 指定时长，对匿名用户也有效<br/>默认情况：不禁言</param>
		/// <param name="banDuration">禁言时长<br/>默认情况：30 分钟</param>
		public GroupMessageFastAction(Message message = null, bool atSender = true, bool delete = false, bool kick = false, bool ban = false, int banDuration = 30 * 60)
		{
			Message = message;
			AutoEscape = false;
			AtSender = atSender;
			Delete = delete;
			Kick = kick;
			Ban = ban;
			BanDuration = banDuration;
		}
	}
}
