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

		#region API

		/// <summary>
		/// 获取Onebot<a href="https://github.com/botuniverse/onebot-11/blob/master/api/public.md#get_version_info-%E8%8E%B7%E5%8F%96%E7%89%88%E6%9C%AC%E4%BF%A1%E6%81%AF">版本信息</a>
		/// </summary>
		/// <returns>版本信息响应</returns>
		Task<APIResponse<VersionInfo>> GetVersionInfoAsync();

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
		/// 群组踢人
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="userId">要踢的 QQ 号</param>
		/// <param name="rejectAddRequest">拒绝此人的加群请求</param>
		/// <returns>纯Json信息响应</returns>
		Task<APIResponse<EmptyInfo>> KickGroupMemberAsync(long groupId, long userId, bool rejectAddRequest = false);

		/// <summary>
		/// 群组单人禁言
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="userId">要禁言的 QQ 号</param>
		/// <param name="duration">禁言时长，单位秒，0 表示取消禁言</param>
		/// <returns>纯Json信息响应</returns>
		Task<APIResponse<EmptyInfo>> MuteGroupMemberAsync(long groupId, long userId, int duration = 30 * 60);

		/// <summary>
		/// 群组取消单人禁言
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="userId">要取消禁言的 QQ 号</param>
		/// <returns>纯Json信息响应</returns>
		Task<APIResponse<EmptyInfo>> UnmuteGroupMemberAsync(long groupId, long userId);

		/// <summary>
		/// 群组全员禁言
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <returns>纯Json信息响应</returns>
		Task<APIResponse<EmptyInfo>> MuteGroupAllAsync(long groupId);

		/// <summary>
		/// 群组取消全员禁言
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <returns>纯Json信息响应</returns>
		Task<APIResponse<EmptyInfo>> UnmuteGroupAllAsync(long groupId);

		/// <summary>
		/// 群组设置管理员
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="userId">要设置管理员的 QQ 号</param>
		/// <param name="enable">true 为设置，false 为取消</param>
		/// <returns>纯Json信息响应</returns>
		Task<APIResponse<EmptyInfo>> SetGroupAdminAsync(long groupId, long userId, bool enable = true);

		/// <summary>
		/// 设置群名片（群备注）
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="userId">要设置的 QQ 号</param>
		/// <param name="card">群名片内容，不填或空字符串表示删除群名片</param>
		/// <returns>纯Json信息响应</returns>
		Task<APIResponse<EmptyInfo>> SetGroupCardAsync(long groupId, long userId, string card);

		/// <summary>
		/// 设置群名
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="groupName">新群名</param>
		/// <returns>纯Json信息响应</returns>
		Task<APIResponse<EmptyInfo>> SetGroupNameAsync(long groupId, string groupName);

		/// <summary>
		/// 退出群组
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="isDismiss">是否解散，如果登录号是群主，则仅在此项为 true 时能够解散</param>
		/// <returns>纯Json信息响应</returns>
		Task<APIResponse<EmptyInfo>> LeaveGroupAsync(long groupId, bool isDismiss);

		/// <summary>
		/// 获取登录号信息
		/// </summary>
		/// <returns>登录信息响应</returns>
		Task<APIResponse<LoginInfo>> GetLoginInfoAsync();

		/// <summary>
		/// 获取群信息
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="noCache">是否不使用缓存（使用缓存可能更新不及时，但响应更快）</param>
		/// <returns>群信息响应</returns>
		Task<APIResponse<GroupInfo>> GetGroupInfoAsync(long groupId, bool noCache);

		/// <summary>
		/// 获取群列表
		/// </summary>
		/// <returns>群列表信息响应</returns>
		Task<APIResponse<GroupListInfo>> GetGroupListAsync();

		#endregion
	}
}
