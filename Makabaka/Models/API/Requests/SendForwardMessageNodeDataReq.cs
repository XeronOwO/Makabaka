using Makabaka.Models.Messages;
using Newtonsoft.Json;

namespace Makabaka.Models.API.Requests
{
	internal class SendForwardMessageNodeDataReq
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("uin")]
		public string Uin { get; set; }

		[JsonProperty("content")]
		public Message Content { get; set; }
	}
}
