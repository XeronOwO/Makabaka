using Makabaka.Models.Messages;
using System.Collections.Generic;

namespace Makabaka.Models.API.Requests
{
	internal class SendForwardMessageNodeListReq : List<SendForwardMessageNodeReq>
	{
		public static SendForwardMessageNodeListReq FromNodeSegments(List<NodeSegment> nodes)
		{
			var result = new SendForwardMessageNodeListReq();
			foreach (var node in nodes)
			{
				result.Add(SendForwardMessageNodeReq.FromNodeSegment(node));
			}
			return result;
		}
	}
}
