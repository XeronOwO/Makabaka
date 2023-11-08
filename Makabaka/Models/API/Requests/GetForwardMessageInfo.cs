using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.API.Requests
{
	internal class GetForwardMessageInfo
	{
		[JsonProperty("id")]
		public string Id { get; set; }
	}
}
