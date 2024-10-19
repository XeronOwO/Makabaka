namespace Makabaka.API
{
	/// <summary>
	/// 处理加好友请求
	/// </summary>
	/// <param name="Flag">加好友请求的 flag（需从上报的数据中获得）</param>
	/// <param name="Approve">是否同意请求</param>
	/// <param name="Remark">添加后的好友备注（仅在同意时有效）</param>
	public record class SetFriendAddRequestRequestParams(
		string Flag,
		bool Approve = true,
		string? Remark = null
		)
	{
	}
}
