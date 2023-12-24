using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.Senders
{
	/// <summary>
	/// <a href="https://github.com/botuniverse/onebot-11/blob/master/event/message.md#%E7%BE%A4%E6%B6%88%E6%81%AF">消息</a>发送者<br/>需要注意的是，sender 中的各字段是尽最大努力提供的，也就是说，不保证每个字段都一定存在，也不保证存在的字段都是完全正确的（缓存可能过期）。尤其对于匿名消息，此字段不具有参考价值。
	/// </summary>
	public class Sender
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
