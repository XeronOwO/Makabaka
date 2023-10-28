using Makabaka.Models.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.API.Requests
{
	internal class SendGroupMessageInfo
	{
		[JsonProperty("group_id")]
		public long GroupId { get; set; }

		[JsonProperty("message")]
		public Message Message { get; set; }

		[JsonProperty("auto_escape")]
		public bool AutoEscape { get; set; } = false;
	}
}
