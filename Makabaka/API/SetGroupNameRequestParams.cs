namespace Makabaka.API
{
	/// <summary>
	/// 设置群名
	/// </summary>
	/// <param name="GroupId">群号</param>
	/// <param name="GroupName">新群名</param>
	public record class SetGroupNameRequestParams(
		ulong GroupId,
		string GroupName
		)
	{
	}
}
