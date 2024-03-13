using Newtonsoft.Json;

namespace Makabaka.Models.API.Requests
{
	internal class GroupPokeReq
	{
		[JsonProperty("group_id")]
		public long GroupId { get; set; }

		[JsonProperty("user_id")]
		public long UserId { get; set; }
	}
}
