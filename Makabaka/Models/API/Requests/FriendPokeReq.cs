using Newtonsoft.Json;

namespace Makabaka.Models.API.Requests
{
	internal class FriendPokeReq
	{
		[JsonProperty("user_id")]
		public long UserId { get; set; }
	}
}
