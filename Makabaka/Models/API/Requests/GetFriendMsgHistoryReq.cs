using Newtonsoft.Json;

namespace Makabaka.Models.API.Requests
{
	internal class GetFriendMsgHistoryReq
	{
		[JsonProperty("user_id")]
		public long UserId { get; set; }

		[JsonProperty("message_id")]
		public long MessageId { get; set; }

		[JsonProperty("count")]
		public int Count { get; set; }
	}
}
