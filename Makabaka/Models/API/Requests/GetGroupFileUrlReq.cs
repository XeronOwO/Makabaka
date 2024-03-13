using Newtonsoft.Json;

namespace Makabaka.Models.API.Requests
{
	internal class GetGroupFileUrlReq
	{
		[JsonProperty("group_id")]
		public long GroupId { get; set; }

		[JsonProperty("file_id")]
		public string FileId { get; set; }

		[JsonProperty("busid")]
		public int BusId { get; set; }
	}
}
