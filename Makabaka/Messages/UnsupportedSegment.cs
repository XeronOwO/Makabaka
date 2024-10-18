using Makabaka.Utils;
using System.Text.Json.Nodes;

namespace Makabaka.Messages
{
	/// <summary>
	/// 不支持的段消息
	/// </summary>
	[Segment(SegmentType.Unsupported)]
	public class UnsupportedSegment : Segment<JsonNode>
	{
	}
}
