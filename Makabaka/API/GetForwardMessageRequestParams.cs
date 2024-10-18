namespace Makabaka.API
{
	/// <summary>
	/// 获取转发消息请求参数
	/// </summary>
	/// <param name="Id">合并转发 ID</param>
	public record class GetForwardMessageRequestParams(string Id)
	{
	}
}
