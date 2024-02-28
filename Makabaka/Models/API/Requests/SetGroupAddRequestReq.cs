using Newtonsoft.Json;

namespace Makabaka.Models.API.Requests
{
	internal class SetGroupAddRequestReq
	{
		[JsonProperty("flag")]
		public string Flag { get; set; }

		[JsonProperty("sub_type")]
		public string SubType { get; set; }

		[JsonProperty("approve")]
		public bool Approve { get; set; }

		[JsonProperty("reason")]
		public string Reason { get; set; }
	}
}
