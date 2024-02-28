using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.API.Responses
{
	/// <summary>
	/// 好友信息
	/// </summary>
	public class FriendRes
	{
		/// <summary>
		/// QQ 号
		/// </summary>
		[JsonProperty("user_id")]
		public long UserId { get; set; }

		/// <summary>
		/// 昵称
		/// </summary>
		[JsonProperty("nickname")]
		public string Nickname { get; set; }

		/// <summary>
		/// 备注名
		/// </summary>
		[JsonProperty("remark")]
		public string Remark { get; set; }
	}
}
