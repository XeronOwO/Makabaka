namespace Makabaka.API
{
	/// <summary>
	/// 群组单人禁言
	/// </summary>
	/// <param name="groupId">群号</param>
	/// <param name="userId">要禁言的 QQ 号</param>
	/// <param name="duration">禁言时长，单位秒，0 表示取消禁言</param>
	public class MuteGroupMemberRequestParams(
		long groupId,
		long userId,
		int duration = 30 * 60
		)
	{
		/// <summary>
		/// 群号
		/// </summary>
		public long GroupId { get; set; } = groupId;

		/// <summary>
		/// 要禁言的 QQ 号
		/// </summary>
		public long UserId { get; set; } = userId;

		/// <summary>
		/// 禁言时长，单位秒，0 表示取消禁言
		/// </summary>
		public int Duration { get; set; } = duration;
	}
}
