namespace Makabaka.API
{
	/// <summary>
	/// 群组全员禁言请求参数
	/// </summary>
	/// <param name="GroupId">群号</param>
	/// <param name="Enable">是否禁言</param>
	public record class MuteGroupRequestParams(
		ulong GroupId,
		bool Enable = true
		)
	{
	}
}
