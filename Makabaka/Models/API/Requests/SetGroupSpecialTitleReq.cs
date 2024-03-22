using Newtonsoft.Json;

namespace Makabaka.Models.API.Requests
{
	internal class SetGroupSpecialTitleReq
	{
		[JsonProperty("group_id")]
		public long GroupId { get; set; }

		[JsonProperty("user_id")]
		public long UserId { get; set; }

		[JsonProperty("special_title")]
		public string SpecialTitle { get; set; }
	}
}
