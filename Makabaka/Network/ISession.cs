using Makabaka.Models.API.Responses;
using Makabaka.Models.Messages;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Makabaka.Network
{
	/// <summary>
	/// 会话接口，定义一些通用函数
	/// </summary>
	public interface ISession
	{
		/// <summary>
		/// 当获得API响应
		/// </summary>
		internal void OnAPIResponse(string data, JObject json, int retcode, string echo);

		/// <summary>
		/// 会话的唯一标识符
		/// </summary>
		Guid Guid { get; }

		#region API

		/// <summary>
		/// 发送私聊消息
		/// </summary>
		/// <param name="userId">群号</param>
		/// <param name="message">要发送的内容</param>
		/// <returns>消息ID信息响应</returns>
		Task<APIResponse<MessageIdInfo>> SendPrivateMessageAsync(long userId, Message message);

		/// <summary>
		/// 发送群消息
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="message">要发送的内容</param>
		/// <returns>消息ID信息响应</returns>
		Task<APIResponse<MessageIdInfo>> SendGroupMessageAsync(long groupId, Message message);

		/// <summary>
		/// 撤回消息
		/// </summary>
		/// <param name="messageId">消息ID</param>
		/// <returns>空信息响应</returns>
		Task<APIResponse<EmptyInfo>> DeleteMessageAsync(long messageId);

		/// <summary>
		/// 获取消息
		/// </summary>
		/// <param name="messageId">消息ID</param>
		/// <returns>消息信息响应</returns>
		Task<APIResponse<MessageInfo>> GetMessageAsync(long messageId);

		/// <summary>
		/// 获取合并转发消息
		/// </summary>
		/// <param name="id">合并转发 ID</param>
		/// <returns>合并转发消息信息响应</returns>
		Task<APIResponse<ForwardMessageInfo>> GetForwardMessageAsync(string id);

		/// <summary>
		/// 发送好友赞
		/// </summary>
		/// <param name="userId">对方 QQ 号</param>
		/// <param name="times">赞的次数，每个好友每天最多 10 次</param>
		/// <returns>空消息响应</returns>
		Task<APIResponse<EmptyInfo>> SendLikeAsync(long userId, int times = 1);

		/// <summary>
		/// 群组踢人
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="userId">要踢的 QQ 号</param>
		/// <param name="rejectAddRequest">拒绝此人的加群请求</param>
		/// <returns>空信息响应</returns>
		Task<APIResponse<EmptyInfo>> KickGroupMemberAsync(long groupId, long userId, bool rejectAddRequest = false);

		/// <summary>
		/// 群组单人禁言
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="userId">要禁言的 QQ 号</param>
		/// <param name="duration">禁言时长，单位秒，0 表示取消禁言</param>
		/// <returns>空信息响应</returns>
		Task<APIResponse<EmptyInfo>> MuteGroupMemberAsync(long groupId, long userId, int duration = 30 * 60);

		/// <summary>
		/// 群组取消单人禁言
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="userId">要取消禁言的 QQ 号</param>
		/// <returns>空信息响应</returns>
		Task<APIResponse<EmptyInfo>> UnmuteGroupMemberAsync(long groupId, long userId);

		/// <summary>
		/// 群组全员禁言
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <returns>空信息响应</returns>
		Task<APIResponse<EmptyInfo>> MuteGroupAllAsync(long groupId);

		/// <summary>
		/// 群组取消全员禁言
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <returns>空信息响应</returns>
		Task<APIResponse<EmptyInfo>> UnmuteGroupAllAsync(long groupId);

		/// <summary>
		/// 群组设置管理员
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="userId">要设置管理员的 QQ 号</param>
		/// <param name="enable">true 为设置，false 为取消</param>
		/// <returns>空信息响应</returns>
		Task<APIResponse<EmptyInfo>> SetGroupAdminAsync(long groupId, long userId, bool enable = true);

		/// <summary>
		/// 设置群名片（群备注）
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="userId">要设置的 QQ 号</param>
		/// <param name="card">群名片内容，不填或空字符串表示删除群名片</param>
		/// <returns>空信息响应</returns>
		Task<APIResponse<EmptyInfo>> SetGroupCardAsync(long groupId, long userId, string card);

		/// <summary>
		/// 设置群名
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="groupName">新群名</param>
		/// <returns>空信息响应</returns>
		Task<APIResponse<EmptyInfo>> SetGroupNameAsync(long groupId, string groupName);

		/// <summary>
		/// 退出群组
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="isDismiss">是否解散，如果登录号是群主，则仅在此项为 true 时能够解散</param>
		/// <returns>空信息响应</returns>
		Task<APIResponse<EmptyInfo>> LeaveGroupAsync(long groupId, bool isDismiss);

		/// <summary>
		/// 获取登录号信息
		/// </summary>
		/// <returns>登录信息响应</returns>
		Task<APIResponse<LoginInfo>> GetLoginInfoAsync();

		/// <summary>
		/// 获取好友列表
		/// </summary>
		/// <returns>好友信息列表响应</returns>
		Task<APIResponse<FriendInfoList>> GetFriendListAsync();

		/// <summary>
		/// 获取群信息
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="noCache">是否不使用缓存（使用缓存可能更新不及时，但响应更快）</param>
		/// <returns>群信息响应</returns>
		Task<APIResponse<GroupInfo>> GetGroupAsync(long groupId, bool noCache);

		/// <summary>
		/// 获取群列表
		/// </summary>
		/// <returns>群列表信息响应</returns>
		Task<APIResponse<GroupInfoList>> GetGroupListAsync();

		/// <summary>
		/// 获取群成员信息
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="userId">QQ 号</param>
		/// <param name="noCache">是否不使用缓存（使用缓存可能更新不及时，但响应更快）</param>
		/// <returns>群成员信息响应</returns>
		Task<APIResponse<GroupMemberInfo>> GetGroupMemberAsync(long groupId, long userId, bool noCache = false);

		/// <summary>
		/// 获取群成员列表<br/>响应内容为 JSON 数组，每个元素的内容和上面的 get_group_member_info 接口相同，但对于同一个群组的同一个成员，获取列表时和获取单独的成员信息时，某些字段可能有所不同，例如 area、title 等字段在获取列表时无法获得，具体应以单独的成员信息为准。
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <returns>群成员信息列表响应</returns>
		Task<APIResponse<GroupMemberInfoList>> GetGroupMemberListAsync(long groupId);

		/// <summary>
		/// 获取 Cookies
		/// </summary>
		/// <param name="domain">需要获取 cookies 的域名</param>
		/// <returns>Cookies信息响应</returns>
		Task<APIResponse<CookiesInfo>> GetCookiesAsync(string domain);

		/// <summary>
		/// 检查是否可以发送图片
		/// </summary>
		/// <returns>是否信息响应</returns>
		Task<APIResponse<YesInfo>> CanSendImageAsync();

		/// <summary>
		/// 检查是否可以发送语音
		/// </summary>
		/// <returns>是否信息响应</returns>
		Task<APIResponse<YesInfo>> CanSendRecordAsync();

		/// <summary>
		/// 获取Onebot<a href="https://github.com/botuniverse/onebot-11/blob/master/api/public.md#get_version_info-%E8%8E%B7%E5%8F%96%E7%89%88%E6%9C%AC%E4%BF%A1%E6%81%AF">版本信息</a>
		/// </summary>
		/// <returns>版本信息响应</returns>
		Task<APIResponse<VersionInfo>> GetVersionInfoAsync();

		/// <summary>
		/// 重启 OneBot 实现<br/>由于重启 OneBot 实现同时需要重启 API 服务，这意味着当前的 API 请求会被中断，因此需要异步地重启，接口返回的 status 是 async。
		/// </summary>
		/// <returns>空信息响应</returns>
		Task<APIResponse<EmptyInfo>> RestartAsync();

		#endregion
	}
}
