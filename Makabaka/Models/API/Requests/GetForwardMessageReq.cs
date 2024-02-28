using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.API.Requests
{
	internal class GetForwardMessageReq
	{
		[JsonProperty("id")]
		public string Id { get; set; }
	}
}
