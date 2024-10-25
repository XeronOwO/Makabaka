namespace Makabaka.API
{
	/// <summary>
	/// 获取群文件 URL 请求参数
	/// </summary>
	/// <param name="GroupId">群号</param>
	/// <param name="FileId">文件 ID</param>
	/// <param name="Busid">BusId</param>
	public record class GetGroupFileUrlRequestParams(
		long GroupId,
		string FileId,
		uint Busid
		)
	{
	}
}
