using Newtonsoft.Json;

namespace Makabaka.Models.API.Requests
{
	internal class UploadPrivateFileReq
	{
		[JsonProperty("user_id")]
		public long UserId { get; set; }

		[JsonProperty("file")]
		public string File { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
