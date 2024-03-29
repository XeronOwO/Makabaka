﻿using Newtonsoft.Json;

namespace Makabaka.Models.API.Requests
{
	internal class SetFriendAddRequestReq
	{
		[JsonProperty("flag")]
		public string Flag { get; set; }

		[JsonProperty("approve")]
		public bool Approve { get; set; }

		[JsonProperty("remark")]
		public string Remark { get; set; }
	}
}
