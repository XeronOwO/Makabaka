using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.API.Requests
{
	internal class SendLikeReq
	{
		[JsonProperty("user_id")]
		public long UserId { get; set; }

		[JsonProperty("times")]
		public int Times { get; set; }
	}
}
