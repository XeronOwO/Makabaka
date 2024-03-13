using Newtonsoft.Json;

namespace Makabaka.Models.API.Requests
{
	internal class UploadGroupFileReq
	{
		[JsonProperty("group_id")]
		public long GroupId { get; set; }

		[JsonProperty("file")]
		public string File { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("folder")]
		public string Folder { get; set; }
	}
}
