using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.API.Requests
{
	internal class MuteGroupAllInfo
	{
		[JsonProperty("group_id")]
		public long GroupId { get; set; }

		[JsonProperty("enable")]
		public bool Enable { get; set; }
	}
}
