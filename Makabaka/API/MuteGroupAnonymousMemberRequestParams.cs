using Makabaka.Models;

namespace Makabaka.API
{
	/// <summary>
	/// 群组匿名用户禁言请求参数
	/// </summary>
	/// <param name="GroupId">群号</param>
	/// <param name="Anonymous">可选，要禁言的匿名用户对象（群消息上报的 anonymous 字段）</param>
	/// <param name="AnonymousFlag">可选，要禁言的匿名用户的 flag（需从群消息上报的数据中获得）</param>
	/// <param name="Flag">可选，要禁言的匿名用户的 flag（需从群消息上报的数据中获得）</param>
	/// <param name="Duration">禁言时长，单位秒，无法取消匿名用户禁言</param>
	public record class MuteGroupAnonymousMemberRequestParams(
		ulong GroupId,
		GroupMessageAnonymousSenderInfo? Anonymous = null,
		string? AnonymousFlag = null,
		string? Flag = null,
		int Duration = 30 * 60
		)
	{
	}
}
