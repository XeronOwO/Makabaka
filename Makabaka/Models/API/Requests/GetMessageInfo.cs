using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.API.Requests
{
	internal class GetMessageInfo
	{
		[JsonProperty("message_id")]
		public int MessageId { get; set; }
	}
}
