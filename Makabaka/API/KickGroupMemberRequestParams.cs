namespace Makabaka.API
{
	/// <summary>
	/// 踢出群成员请求参数
	/// </summary>
	/// <param name="groupId">群号</param>
	/// <param name="userId">要踢的 QQ 号</param>
	/// <param name="rejectAddRequest">拒绝此人的加群请求</param>
	public class KickGroupMemberRequestParams(
		long groupId,
		long userId,
		bool rejectAddRequest = false
		)
	{
		/// <summary>
		/// 群号
		/// </summary>
		public long GroupId { get; set; } = groupId;

		/// <summary>
		/// 要踢的 QQ 号
		/// </summary>
		public long UserId { get; set; } = userId;

		/// <summary>
		/// 拒绝此人的加群请求
		/// </summary>
		public bool RejectAddRequest { get; set; } = rejectAddRequest;
	}
}
