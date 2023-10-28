using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.Senders
{
	/// <summary>
	/// <a href="https://github.com/botuniverse/onebot-11/blob/master/event/message.md#%E7%BE%A4%E6%B6%88%E6%81%AF">群消息</a>发送者
	/// </summary>
	public class GroupSender
	{
		/// <summary>
		/// 发送者 QQ 号
		/// </summary>
		[JsonProperty("user_id")]
		public long UserId { get; set; }

		/// <summary>
		/// 昵称
		/// </summary>
		[JsonProperty("nickname")]
		public string NickName { get; set; }

		/// <summary>
		/// 群名片／备注
		/// </summary>
		[JsonProperty("card")]
		public string Card { get; set; }

		/// <summary>
		/// 性别，male 或 female 或 unknown
		/// </summary>
		[JsonProperty("sex")]
		public string Sex { get; set; }

		/// <summary>
		/// 年龄
		/// </summary>
		[JsonProperty("age")]
		public int Age { get; set; }

		/// <summary>
		/// 地区
		/// </summary>
		[JsonProperty("area")]
		public string Area { get; set; }

		/// <summary>
		/// 成员等级
		/// </summary>
		[JsonProperty("level")]
		public string Level { get; set; }

		/// <summary>
		/// 角色，owner 或 admin 或 member
		/// </summary>
		[JsonProperty("role")]
		public string Role { get; set; }

		/// <summary>
		/// 专属头衔
		/// </summary>
		[JsonProperty("title")]
		public string Title { get; set; }
	}
}
