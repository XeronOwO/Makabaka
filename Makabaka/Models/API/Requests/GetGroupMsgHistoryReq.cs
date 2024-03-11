using Newtonsoft.Json;

namespace Makabaka.Models.API.Requests
{
	internal class GetGroupMsgHistoryReq
	{
		[JsonProperty("group_id")]
		public long GroupId { get; set; }

		[JsonProperty("message_id")]
		public long MessageId { get; set; }

		[JsonProperty("count")]
		public int Count { get; set; }
	}
}
