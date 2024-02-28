using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.API.Responses
{
	/// <summary>
	/// 登录号信息
	/// </summary>
	public class LoginRes
	{
		/// <summary>
		/// QQ 号
		/// </summary>
		[JsonProperty("user_id")]
		public long UserId { get; set; }

		/// <summary>
		/// QQ 昵称
		/// </summary>
		[JsonProperty("nickname")]
		public string Nickname { get; set; }
	}
}
