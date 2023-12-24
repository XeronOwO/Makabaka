using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.API.Requests
{
	internal class DeleteMessageInfo
	{
		[JsonProperty("message_id")]
		public int MessageId { get; set; }
	}
}
