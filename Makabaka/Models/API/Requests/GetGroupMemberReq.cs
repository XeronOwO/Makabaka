﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.API.Requests
{
	internal class GetGroupMemberReq
	{
		[JsonProperty("group_id")]
		public long GroupId { get; set; }

		[JsonProperty("user_id")]
		public long UserId { get; set; }

		[JsonProperty("no_cache")]
		public bool NoCache { get; set; }
	}
}
