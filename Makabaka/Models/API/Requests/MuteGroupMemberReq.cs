﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.API.Requests
{
	internal class MuteGroupMemberReq
	{
		[JsonProperty("group_id")]
		public long GroupId { get; set; }

		[JsonProperty("user_id")]
		public long UserId { get; set; }

		[JsonProperty("duration")]
		public int Duration { get; set; }
	}
}
