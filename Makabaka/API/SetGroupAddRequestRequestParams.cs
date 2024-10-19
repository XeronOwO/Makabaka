using Makabaka.Events;

namespace Makabaka.API
{
	/// <summary>
	/// 处理加群请求／邀请
	/// </summary>
	/// <param name="Flag">加群请求的 flag（需从上报的数据中获得）</param>
	/// <param name="SubType">add 或 invite，请求类型（需要和上报消息中的 sub_type 字段相符）</param>
	/// <param name="Approve">是否同意请求／邀请</param>
	/// <param name="Reason">拒绝理由（仅在拒绝时有效）</param>
	public record class SetGroupAddRequestRequestParams(
		string Flag,
		GroupAddRequestEventType SubType,
		bool Approve = true,
		string? Reason = null
		)
	{
	}
}
