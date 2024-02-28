using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.API.Requests
{
	internal class SetGroupLeaveReq
	{
		[JsonProperty("group_id")]
		public long GroupId { get; set; }

		[JsonProperty("is_dismiss")]
		public bool IsDismiss { get; set; }
	}
}
