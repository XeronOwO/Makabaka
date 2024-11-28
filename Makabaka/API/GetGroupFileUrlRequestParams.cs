using System.Text.Json.Serialization;

namespace Makabaka.API
{
	/// <summary>
	/// 获取群文件 URL 请求参数
	/// </summary>
	/// <param name="GroupId">群号</param>
	/// <param name="FileId">文件 ID</param>
	/// <param name="BusId">BusId</param>
	public record class GetGroupFileUrlRequestParams(
		ulong GroupId,
		string FileId,
		[property: JsonPropertyName("busid")] uint BusId
		)
	{
	}
}
