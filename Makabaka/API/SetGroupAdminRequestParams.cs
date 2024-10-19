namespace Makabaka.API
{
	/// <summary>
	/// 群组设置管理员请求参数
	/// </summary>
	/// <param name="GroupId">群号</param>
	/// <param name="UserId">要设置管理员的 QQ 号</param>
	/// <param name="Enable">true 为设置，false 为取消</param>
	public record class SetGroupAdminRequestParams(
		long GroupId,
		long UserId,
		bool Enable = true
		)
	{
	}
}
