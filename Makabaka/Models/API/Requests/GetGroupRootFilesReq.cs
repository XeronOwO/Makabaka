using Newtonsoft.Json;

namespace Makabaka.Models.API.Requests
{
	internal class GetGroupRootFilesReq
	{
		[JsonProperty("group_id")]
		public long GroupId { get; set; }
	}
}
