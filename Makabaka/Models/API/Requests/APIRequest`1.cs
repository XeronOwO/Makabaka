using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.API.Requests
{
	internal class APIRequest<T> : APIRequest
	{
		[JsonProperty("params")]
		public T Params { get; set; }
	}
}
