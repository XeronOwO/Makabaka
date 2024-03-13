using Newtonsoft.Json;

namespace Makabaka.Models.API.Requests
{
	internal class GetGroupFilesByFolderReq
	{
		[JsonProperty("group_id")]
		public long GroupId { get; set; }

		[JsonProperty("folder_id")]
		public string FolderId { get; set; }
	}
}
