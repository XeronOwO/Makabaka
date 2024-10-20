namespace Makabaka.API
{
	/// <summary>
	/// 获取群成员列表
	/// </summary>
	/// <param name="GroupId">群号</param>
	public record class GetGroupMemberListRequestParams(
		long GroupId
		)
	{
	}
}
