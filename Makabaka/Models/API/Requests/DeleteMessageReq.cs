using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.API.Requests
{
	internal class DeleteMessageReq
	{
		[JsonProperty("message_id")]
		public long MessageId { get; set; }
	}
}
