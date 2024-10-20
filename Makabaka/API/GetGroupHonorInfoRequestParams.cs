namespace Makabaka.API
{
	/// <summary>
	/// 获取群荣誉信息请求参数
	/// </summary>
	/// <param name="GroupId">群号</param>
	/// <param name="Type">要获取的群荣誉类型</param>
	public record class GetGroupHonorInfoRequestParams(
		long GroupId,
		GetGroupHonorInfoType Type
		)
	{
	}
}
