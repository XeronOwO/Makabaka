using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.API.Requests
{
	internal class GetGroupMemberListReq
	{
		[JsonProperty("group_id")]
		public long GroupId { get; set; }
	}
}
