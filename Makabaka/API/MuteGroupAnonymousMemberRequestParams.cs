using Makabaka.Events;

namespace Makabaka.API
{
	/// <summary>
	/// 群组匿名用户禁言请求参数
	/// </summary>
	/// <param name="groupId">群号</param>
	/// <param name="anonymous">可选，要禁言的匿名用户对象（群消息上报的 anonymous 字段）</param>
	/// <param name="anonymousFlag">可选，要禁言的匿名用户的 flag（需从群消息上报的数据中获得）</param>
	/// <param name="flag">可选，要禁言的匿名用户的 flag（需从群消息上报的数据中获得）</param>
	/// <param name="duration">禁言时长，单位秒，无法取消匿名用户禁言</param>
	public class MuteGroupAnonymousMemberRequestParams(
		long groupId,
		GroupMessageAnonymousSenderInfo? anonymous = null,
		string? anonymousFlag = null,
		string? flag = null,
		int duration = 30 * 60
		)
	{
		/// <summary>
		/// 群号
		/// </summary>
		public long GroupId { get; set; } = groupId;

		/// <summary>
		/// 可选，要禁言的匿名用户对象（群消息上报的 anonymous 字段）
		/// </summary>
		public GroupMessageAnonymousSenderInfo? Anonymous { get; set; } = anonymous;

		/// <summary>
		/// 可选，要禁言的匿名用户的 flag（需从群消息上报的数据中获得）
		/// </summary>
		public string? AnonymousFlag { get; set; } = anonymousFlag;

		/// <summary>
		/// 可选，要禁言的匿名用户的 flag（需从群消息上报的数据中获得）
		/// </summary>
		public string? Flag { get; set; } = flag;

		/// <summary>
		/// 禁言时长，单位秒，无法取消匿名用户禁言
		/// </summary>
		public int Duration { get; set; } = duration;
	}
}
