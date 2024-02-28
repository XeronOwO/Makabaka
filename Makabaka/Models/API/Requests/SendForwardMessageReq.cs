using Newtonsoft.Json;

namespace Makabaka.Models.API.Requests
{
	internal class SendForwardMessageReq
	{
		[JsonProperty("messages")]
		public SendForwardMessageNodeListReq Messages { get; set; }
	}
}
