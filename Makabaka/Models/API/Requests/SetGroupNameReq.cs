using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.API.Requests
{
	internal class SetGroupNameReq
	{
		[JsonProperty("group_id")]
		public long GroupId { get; set; }

		[JsonProperty("group_name")]
		public string GroupName { get; set; }
	}
}
