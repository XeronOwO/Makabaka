using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.API.Requests
{
	internal class APIRequest
	{
		[JsonProperty("action")]
		public string Action { get; set; }

		[JsonProperty("echo")]
		public string Echo { get; set; }
	}
}
