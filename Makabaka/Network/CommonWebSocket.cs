using Makabaka.Models.API.Requests;
using Makabaka.Models.API.Responses;
using Makabaka.Models.Messages;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Makabaka.Network
{
	internal abstract class CommonWebSocket : ISession
	{
		#region 构造函数与参数

		public abstract Guid Guid { get; }

		public CommonWebSocket()
		{

		}

		#endregion

		#region API执行

		public abstract Task<APIResponse<TResult>> ExecuteAPIAsync<TResult>(string action, string echo)
			where TResult : class, new();

		public abstract Task<APIResponse<TResult>> ExecuteAPIAsync<TResult, TParam>(string action, TParam @params, string echo)
			where TResult : class, new();

		public abstract void OnAPIResponse(string data, JObject json, int retcode, string echo);

		#endregion

		#region API

		public async Task<APIResponse<VersionInfo>> GetVersionInfoAsync()
		{
			return await ExecuteAPIAsync<VersionInfo>("get_version_info", Guid.NewGuid().ToString());
		}

		public async Task<APIResponse<MessageIdInfo>> SendPrivateMessageAsync(long userId, Message message)
		{
			return await ExecuteAPIAsync<MessageIdInfo, SendPrivateMessageInfo>("send_private_msg", new()
			{
				UserId = userId,
				Message = message,
			}, Guid.NewGuid().ToString());
		}

		public async Task<APIResponse<MessageIdInfo>> SendGroupMessageAsync(long groupId, Message message)
		{
			return await ExecuteAPIAsync<MessageIdInfo, SendGroupMessageInfo>("send_group_msg", new()
			{
				GroupId = groupId,
				Message = message,
			}, Guid.NewGuid().ToString());
		}

		public async Task<APIResponse<EmptyInfo>> KickGroupMemberAsync(long groupId, long userId, bool rejectAddRequest = false)
		{
			return await ExecuteAPIAsync<EmptyInfo, KickGroupMemberInfo>("set_group_kick", new()
			{
				GroupId = groupId,
				UserId = userId,
				RejectAddRequest = rejectAddRequest,
			}, Guid.NewGuid().ToString());
		}

		public async Task<APIResponse<EmptyInfo>> MuteGroupMemberAsync(long groupId, long userId, int duration = 30 * 60)
		{
			return await ExecuteAPIAsync<EmptyInfo, MuteGroupMemberInfo>("set_group_ban", new()
			{
				GroupId = groupId,
				UserId = userId,
				Duration = duration,
			}, Guid.NewGuid().ToString());
		}

		public async Task<APIResponse<EmptyInfo>> UnmuteGroupMemberAsync(long groupId, long userId)
		{
			return await MuteGroupMemberAsync(groupId, userId, 0);
		}

		public async Task<APIResponse<EmptyInfo>> MuteGroupAllAsync(long groupId)
		{
			return await ExecuteAPIAsync<EmptyInfo, MuteGroupAllInfo>("set_group_whole_ban", new()
			{
				GroupId = groupId,
				Enable = true,
			}, Guid.NewGuid().ToString());
		}

		public async Task<APIResponse<EmptyInfo>> UnmuteGroupAllAsync(long groupId)
		{
			return await ExecuteAPIAsync<EmptyInfo, MuteGroupAllInfo>("set_group_whole_ban", new()
			{
				GroupId = groupId,
				Enable = false,
			}, Guid.NewGuid().ToString());
		}

		public async Task<APIResponse<EmptyInfo>> SetGroupAdminAsync(long groupId, long userId, bool enable = true)
		{
			return await ExecuteAPIAsync<EmptyInfo, SetGroupAdminInfo>("set_group_admin", new()
			{
				GroupId = groupId,
				UserId = userId,
				Enable = false,
			}, Guid.NewGuid().ToString());
		}

		public async Task<APIResponse<EmptyInfo>> SetGroupCardAsync(long groupId, long userId, string card)
		{
			return await ExecuteAPIAsync<EmptyInfo, SetGroupCardInfo>("set_group_card", new()
			{
				GroupId = groupId,
				UserId = userId,
				Card = card,
			}, Guid.NewGuid().ToString());
		}

		public async Task<APIResponse<EmptyInfo>> SetGroupNameAsync(long groupId, string groupName)
		{
			return await ExecuteAPIAsync<EmptyInfo, SetGroupNameInfo>("set_group_name", new()
			{
				GroupId = groupId,
				GroupName = groupName,
			}, Guid.NewGuid().ToString());
		}

		public async Task<APIResponse<EmptyInfo>> LeaveGroupAsync(long groupId, bool isDismiss)
		{
			return await ExecuteAPIAsync<EmptyInfo, SetGroupLeaveInfo>("set_group_leave", new()
			{
				GroupId = groupId,
				IsDismiss = isDismiss,
			}, Guid.NewGuid().ToString());
		}

		public async Task<APIResponse<LoginInfo>> GetLoginInfoAsync()
		{
			return await ExecuteAPIAsync<LoginInfo>("get_login_info", Guid.NewGuid().ToString());
		}

		public async Task<APIResponse<GroupInfo>> GetGroupInfoAsync(long groupId, bool noCache)
		{
			return await ExecuteAPIAsync<GroupInfo, GetGroupInfoInfo>("get_group_info", new()
			{
				GroupId = groupId,
				NoCache = noCache,
			}, Guid.NewGuid().ToString());
		}

		public async Task<APIResponse<GroupListInfo>> GetGroupListAsync()
		{
			return await ExecuteAPIAsync<GroupListInfo>("get_group_list", Guid.NewGuid().ToString());
		}

		public async Task<APIResponse<ForwardMessageInfo>> GetForwardMessage(string id)
		{
			var response = await ExecuteAPIAsync<ForwardMessageInfo, GetForwardMessageInfo>("get_forward_msg", new()
			{
				Id = id,
			}, Guid.NewGuid().ToString());
			foreach (var node in response.Data.Message)
			{
				node.PostProcessContent();
			}
			return response;
		}

		#endregion
	}
}
