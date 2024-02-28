using Makabaka.Models.Messages;
using Newtonsoft.Json;

namespace Makabaka.Models.API.Requests
{
	internal class SendForwardMessageNodeReq
	{
		[JsonProperty("data")]
		public SendForwardMessageNodeDataReq Data { get; set; }

		public static SendForwardMessageNodeReq FromNodeSegment(NodeSegment node)
		{
			return new()
			{
				Data = new()
				{
					Name = node.Nickname,
					Uin = node.UserId,
					Content = node.Content,
				},
			};
		}
	}
}
