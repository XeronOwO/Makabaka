using Makabaka.API;
using Makabaka.Events;
using Makabaka.Messages;
using Makabaka.Models;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Makabaka
{
	public partial interface IBotContext
	{
		internal BlockingCollection<APIContext> APISendQueue { get; }

		/// <summary>
		/// 执行 API<br/>在有自定义需求时再使用
		/// </summary>
		/// <typeparam name="TReq">请求参数类型</typeparam>
		/// <typeparam name="TRsp">响应数据类型</typeparam>
		/// <param name="action">用于指定要调用的 API</param>
		/// <param name="req">请求参数</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>执行 API 异步任务</returns>
		Task<APIResponse<TRsp>> ExecuteAPIAsync<TReq, TRsp>(string action, TReq req, CancellationToken cancellationToken = default);

		/// <summary>
		/// 执行 API<br/>在有自定义需求时再使用
		/// </summary>
		/// <typeparam name="TReq">请求参数类型</typeparam>
		/// <param name="action">用于指定要调用的 API</param>
		/// <param name="req">请求参数</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>执行 API 异步任务</returns>
		Task<APIResponse> ExecuteAPIAsync<TReq>(string action, TReq req, CancellationToken cancellationToken = default);

		/// <summary>
		/// 发送私聊消息
		/// </summary>
		/// <param name="userId">对方 QQ 号</param>
		/// <param name="message">要发送的内容</param>
		/// <param name="autoEscape">消息内容是否作为纯文本发送（即不解析 CQ 码），只在 message 字段是字符串时有效</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>发送私聊消息异步任务</returns>
		Task<APIResponse<MessageIdInfo>> SendPrivateMessageAsync(
			long userId,
			Message message,
			bool autoEscape = false,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 发送群消息
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="message">要发送的内容</param>
		/// <param name="autoEscape">消息内容是否作为纯文本发送（即不解析 CQ 码），只在 message 字段是字符串时有效</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>发送群消息异步任务</returns>
		Task<APIResponse<MessageIdInfo>> SendGroupMessageAsync(
			long groupId,
			Message message,
			bool autoEscape = false,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取商城表情密钥
		/// </summary>
		/// <param name="emojiIds">商城表情</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>获取商城表情密钥异步任务</returns>
		Task<APIResponse<string[]>> FetchMarketFaceKeyAsync(
			string[] emojiIds,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 撤回消息
		/// </summary>
		/// <param name="messageId">消息 ID</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>撤回消息异步任务</returns>
		Task<APIResponse> RevokeMessageAsync(
			long messageId,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取消息
		/// </summary>
		/// <param name="messageId">消息 ID</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>获取消息异步任务</returns>
		Task<APIResponse<MessageInfo>> GetMessageAsync(
			long messageId,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取转发消息
		/// </summary>
		/// <param name="id">合并转发 ID</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>获取转发消息异步任务</returns>
		Task<APIResponse<ForwardMessageInfo>> GetForwardMessageAsync(
			string id,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 发送好友赞
		/// </summary>
		/// <param name="userId">对方 QQ 号</param>
		/// <param name="times">赞的次数，每个好友每天最多 10 次</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>发送好友赞异步任务</returns>
		Task<APIResponse> SendLikeAsync(
			long userId,
			int times = 1,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 踢出群成员
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="userId">要踢的 QQ 号</param>
		/// <param name="rejectAddRequest">拒绝此人的加群请求</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>踢出群成员异步任务</returns>
		Task<APIResponse> KickGroupMemberAsync(
			long groupId,
			long userId,
			bool rejectAddRequest = false,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 群组单人禁言
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="userId">要禁言的 QQ 号</param>
		/// <param name="duration">禁言时长，单位秒，0 表示取消禁言</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>群组单人禁言异步任务</returns>
		Task<APIResponse> MuteGroupMemberAsync(
			long groupId,
			long userId,
			int duration = 30 * 60,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 群组匿名用户禁言
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="anonymous">可选，要禁言的匿名用户对象（群消息上报的 anonymous 字段）</param>
		/// <param name="anonymousFlag">可选，要禁言的匿名用户的 flag（需从群消息上报的数据中获得）</param>
		/// <param name="flag">可选，要禁言的匿名用户的 flag（需从群消息上报的数据中获得）</param>
		/// <param name="duration">禁言时长，单位秒，无法取消匿名用户禁言</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>群组匿名用户禁言异步任务</returns>
		Task<APIResponse> MuteGroupAnonymousMemberAsync(
			long groupId,
			GroupMessageAnonymousSenderInfo? anonymous = null,
			string? anonymousFlag = null,
			string? flag = null,
			int duration = 30 * 60,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 群组全员禁言
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="enable">是否禁言</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>群组全员禁言异步任务</returns>
		Task<APIResponse> MuteGroupAsync(
			long groupId,
			bool enable = true,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 群组设置管理员
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="userId">要设置管理员的 QQ 号</param>
		/// <param name="enable">true 为设置，false 为取消</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>群组设置管理员异步任务</returns>
		Task<APIResponse> SetGroupAdminAsync(
			long groupId,
			long userId,
			bool enable = true,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 群组匿名
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="enable">是否允许匿名聊天</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>群组匿名异步任务</returns>
		Task<APIResponse> SetGroupAnonymousAsync(
			long groupId,
			bool enable = true,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 设置群名片（群备注）
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="userId">要设置的 QQ 号</param>
		/// <param name="card">群名片内容，不填或空字符串表示删除群名片</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>设置群名片（群备注）异步任务</returns>
		Task<APIResponse> SetGroupMemberCardAsync(
			long groupId,
			long userId,
			string? card = null,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 设置群名
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="groupName">新群名</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>设置群名异步任务</returns>
		Task<APIResponse> SetGroupNameAsync(
			long groupId,
			string groupName,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 退出群组
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="isDismiss">是否解散，如果登录号是群主，则仅在此项为 true 时能够解散</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>退出群组异步任务</returns>
		Task<APIResponse> LeaveGroupAsync(
			long groupId,
			bool isDismiss = false,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 设置群组专属头衔
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="userId">要设置的 QQ 号</param>
		/// <param name="specialTitle">专属头衔，不填或空字符串表示删除专属头衔</param>
		/// <param name="duration">专属头衔有效期，单位秒，-1 表示永久，不过此项似乎没有效果，可能是只有某些特殊的时间长度有效，有待测试</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>设置群组专属头衔异步任务</returns>
		Task<APIResponse> SetGroupMemberTitleAsync(
			long groupId,
			long userId,
			string? specialTitle = null,
			int duration = -1,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 处理加好友请求
		/// </summary>
		/// <param name="flag">加好友请求的 flag（需从上报的数据中获得）</param>
		/// <param name="approve">是否同意请求</param>
		/// <param name="remark">添加后的好友备注（仅在同意时有效）</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>处理加好友请求异步任务</returns>
		Task<APIResponse> SetFriendAddRequestAsync(
			string flag,
			bool approve = true,
			string? remark = null,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 处理加群请求／邀请
		/// </summary>
		/// <param name="flag">加群请求的 flag（需从上报的数据中获得）</param>
		/// <param name="subType">add 或 invite，请求类型（需要和上报消息中的 sub_type 字段相符）</param>
		/// <param name="approve">是否同意请求／邀请</param>
		/// <param name="reason">拒绝理由（仅在拒绝时有效）</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>处理加群请求／邀请异步任务</returns>
		Task<APIResponse> SetGroupAddRequestAsync(
			string flag,
			GroupAddRequestEventType subType,
			bool approve = true,
			string? reason = null,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取登录号信息
		/// </summary>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>获取登录号信息异步任务</returns>
		Task<APIResponse<LoginInfo>> GetLoginInfoAsync(
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取陌生人信息
		/// </summary>
		/// <param name="userId">QQ 号</param>
		/// <param name="noCache">是否不使用缓存（使用缓存可能更新不及时，但响应更快）</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>获取陌生人信息异步任务</returns>
		Task<APIResponse<StrangerInfo>> GetStrangerInfoAsync(
			long userId,
			bool noCache = false,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取好友列表
		/// </summary>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>获取好友列表异步任务</returns>
		Task<APIResponse<FriendInfo[]>> GetFriendListAsync(
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取群信息
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="noCache">是否不使用缓存（使用缓存可能更新不及时，但响应更快）</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>获取群信息异步任务</returns>
		Task<APIResponse<GroupInfo>> GetGroupInfoAsync(
			long groupId,
			bool noCache = false,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取群列表
		/// </summary>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>获取群列表异步任务</returns>
		Task<APIResponse<GroupInfo[]>> GetGroupListAsync(
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取群成员信息
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="userId">QQ 号</param>
		/// <param name="noCache">是否不使用缓存（使用缓存可能更新不及时，但响应更快）</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>获取群成员信息异步任务</returns>
		Task<APIResponse<GroupMemberInfo>> GetGroupMemberInfoAsync(
			long groupId,
			long userId,
			bool noCache = false,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取群成员列表<br/>
		/// 响应内容为 JSON 数组，每个元素的内容和上面的 get_group_member_info 接口相同，但对于同一个群组的同一个成员，获取列表时和获取单独的成员信息时，某些字段可能有所不同，例如 area、title 等字段在获取列表时无法获得，具体应以单独的成员信息为准。
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>获取群成员列表异步任务</returns>
		Task<APIResponse<GroupMemberInfo[]>> GetGroupMemberListAsync(
			long groupId,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取群荣誉信息
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="type">要获取的群荣誉类型</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>获取群荣誉信息异步任务</returns>
		Task<APIResponse<GroupHonorInfo>> GetGroupHonorInfoAsync(
			long groupId,
			GetGroupHonorInfoType type = GetGroupHonorInfoType.All,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取 Cookies
		/// </summary>
		/// <param name="domain">需要获取 cookies 的域名</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>获取 Cookies 异步任务</returns>
		Task<APIResponse<CookiesInfo>> GetCookiesAsync(
			string domain,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取 CSRF Token
		/// </summary>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>获取 CSRF Token 异步任务</returns>
		Task<APIResponse<CsrfTokenInfo>> GetCsrfTokenAsync(
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取 QQ 相关接口凭证
		/// </summary>
		/// <param name="domain">需要获取 cookies 的域名</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>获取 QQ 相关接口凭证异步任务</returns>
		Task<APIResponse<CredentialsInfo>> GetCredentialsAsync(
			string domain,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取语音
		/// </summary>
		/// <param name="file">收到的语音文件名（消息段的 file 参数），如 0B38145AA44505000B38145AA4450500.silk</param>
		/// <param name="outFormat">要转换到的格式</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>获取语音异步任务</returns>
		Task<APIResponse<RecordInfo>> GetRecordAsync(
			string file,
			GetRecordFormatType outFormat,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取图片
		/// </summary>
		/// <param name="file">收到的图片文件名（消息段的 file 参数），如 6B4DE3DFD1BD271E3297859D41C530F5.jpg</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>获取图片异步任务</returns>
		Task<APIResponse<ImageInfo>> GetImageAsync(
			string file,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 检查是否可以发送图片
		/// </summary>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>检查是否可以发送图片异步任务</returns>
		Task<APIResponse<YesInfo>> CanSendImageAsync(
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 检查是否可以发送语音
		/// </summary>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>检查是否可以发送语音异步任务</returns>
		Task<APIResponse<YesInfo>> CanSendRecordAsync(
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取运行状态
		/// </summary>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>获取运行状态异步任务</returns>
		Task<APIResponse<StatusInfo>> GetStatusAsync(
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取版本信息
		/// </summary>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>获取版本信息异步任务</returns>
		Task<APIResponse<VersionInfo>> GetVersionInfoAsync(
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 重启 OneBot 实现
		/// </summary>
		/// <param name="delay">要延迟的毫秒数，如果默认情况下无法重启，可以尝试设置延迟为 2000 左右</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>重启 OneBot 实现异步任务</returns>
		Task<APIResponse> RestartAsync(
			long delay = 0,
			CancellationToken cancellationToken = default
			);
	}
}
