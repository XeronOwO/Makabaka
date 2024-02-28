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

		public Task<APIResponse<MessageIdInfo>> SendPrivateMessageAsync(long userId, Message message)
		{
			return ExecuteAPIAsync<MessageIdInfo, SendPrivateMessageInfo>("send_private_msg", new()
			{
				UserId = userId,
				Message = message,
			}, Guid.NewGuid().ToString());
		}

		public Task<APIResponse<MessageIdInfo>> SendGroupMessageAsync(long groupId, Message message)
		{
			return ExecuteAPIAsync<MessageIdInfo, SendGroupMessageInfo>("send_group_msg", new()
			{
				GroupId = groupId,
				Message = message,
			}, Guid.NewGuid().ToString());
		}

		public Task<APIResponse<EmptyInfo>> DeleteMessageAsync(long messageId)
		{
			return ExecuteAPIAsync<EmptyInfo, DeleteMessageInfo>("delete_msg", new()
			{
				MessageId = messageId,
			}, Guid.NewGuid().ToString());
		}

		public async Task<APIResponse<MessageInfo>> GetMessageAsync(long messageId)
		{
			var response = await ExecuteAPIAsync<MessageInfo, GetMessageInfo>("get_msg", new()
			{
				MessageId = messageId,
			}, Guid.NewGuid().ToString());
			response.Data.Message.PostProcessMessage();
			return response;
		}

		public async Task<APIResponse<ForwardMessageInfo>> GetForwardMessageAsync(string id)
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

		public async Task<APIResponse<EmptyInfo>> SendLikeAsync(long userId, int times = 1)
		{
			var response = await ExecuteAPIAsync<EmptyInfo, SendLikeInfo>("send_like", new()
			{
				UserId = userId,
				Times = times,
			}, Guid.NewGuid().ToString());
			return response;
		}

		public Task<APIResponse<EmptyInfo>> KickGroupMemberAsync(long groupId, long userId, bool rejectAddRequest = false)
		{
			return ExecuteAPIAsync<EmptyInfo, KickGroupMemberInfo>("set_group_kick", new()
			{
				GroupId = groupId,
				UserId = userId,
				RejectAddRequest = rejectAddRequest,
			}, Guid.NewGuid().ToString());
		}

		public Task<APIResponse<EmptyInfo>> MuteGroupMemberAsync(long groupId, long userId, int duration = 30 * 60)
		{
			return ExecuteAPIAsync<EmptyInfo, MuteGroupMemberInfo>("set_group_ban", new()
			{
				GroupId = groupId,
				UserId = userId,
				Duration = duration,
			}, Guid.NewGuid().ToString());
		}

		public Task<APIResponse<EmptyInfo>> UnmuteGroupMemberAsync(long groupId, long userId)
		{
			return MuteGroupMemberAsync(groupId, userId, 0);
		}

		public Task<APIResponse<EmptyInfo>> MuteGroupAllAsync(long groupId)
		{
			return ExecuteAPIAsync<EmptyInfo, MuteGroupAllInfo>("set_group_whole_ban", new()
			{
				GroupId = groupId,
				Enable = true,
			}, Guid.NewGuid().ToString());
		}

		public Task<APIResponse<EmptyInfo>> UnmuteGroupAllAsync(long groupId)
		{
			return ExecuteAPIAsync<EmptyInfo, MuteGroupAllInfo>("set_group_whole_ban", new()
			{
				GroupId = groupId,
				Enable = false,
			}, Guid.NewGuid().ToString());
		}

		public Task<APIResponse<EmptyInfo>> SetGroupAdminAsync(long groupId, long userId, bool enable = true)
		{
			return ExecuteAPIAsync<EmptyInfo, SetGroupAdminInfo>("set_group_admin", new()
			{
				GroupId = groupId,
				UserId = userId,
				Enable = false,
			}, Guid.NewGuid().ToString());
		}

		public Task<APIResponse<EmptyInfo>> SetGroupCardAsync(long groupId, long userId, string card)
		{
			return ExecuteAPIAsync<EmptyInfo, SetGroupCardInfo>("set_group_card", new()
			{
				GroupId = groupId,
				UserId = userId,
				Card = card,
			}, Guid.NewGuid().ToString());
		}

		public Task<APIResponse<EmptyInfo>> SetGroupNameAsync(long groupId, string groupName)
		{
			return ExecuteAPIAsync<EmptyInfo, SetGroupNameInfo>("set_group_name", new()
			{
				GroupId = groupId,
				GroupName = groupName,
			}, Guid.NewGuid().ToString());
		}

		public Task<APIResponse<EmptyInfo>> LeaveGroupAsync(long groupId, bool isDismiss)
		{
			return ExecuteAPIAsync<EmptyInfo, SetGroupLeaveInfo>("set_group_leave", new()
			{
				GroupId = groupId,
				IsDismiss = isDismiss,
			}, Guid.NewGuid().ToString());
		}

		public Task<APIResponse<EmptyInfo>> SetFriendAddRequestAsync(string flag, bool approve = true, string remark = null)
		{
			return ExecuteAPIAsync<EmptyInfo, SetFriendAddRequestInfo>("set_friend_add_request", new()
			{
				Flag = flag,
				Approve = approve,
				Remark = remark,
			}, Guid.NewGuid().ToString());
		}

		public Task<APIResponse<EmptyInfo>> SetGroupRequestAsync(string flag, string subType, bool approve = true, string reason = null)
		{
			return ExecuteAPIAsync<EmptyInfo, SetGroupAddRequestInfo>("set_group_add_request", new()
			{
				Flag = flag,
				SubType = subType,
				Approve = approve,
				Reason = reason,
			}, Guid.NewGuid().ToString());
		}

		public Task<APIResponse<LoginInfo>> GetLoginInfoAsync()
		{
			return ExecuteAPIAsync<LoginInfo>("get_login_info", Guid.NewGuid().ToString());
		}

		public Task<APIResponse<FriendInfoList>> GetFriendListAsync()
		{
			return ExecuteAPIAsync<FriendInfoList>("get_friend_list", Guid.NewGuid().ToString());
		}

		public Task<APIResponse<GroupInfo>> GetGroupAsync(long groupId, bool noCache)
		{
			return ExecuteAPIAsync<GroupInfo, GetGroupInfo>("get_group_info", new()
			{
				GroupId = groupId,
				NoCache = noCache,
			}, Guid.NewGuid().ToString());
		}

		public Task<APIResponse<GroupInfoList>> GetGroupListAsync()
		{
			return ExecuteAPIAsync<GroupInfoList>("get_group_list", Guid.NewGuid().ToString());
		}

		public Task<APIResponse<GroupMemberInfo>> GetGroupMemberAsync(long groupId, long userId, bool noCache = false)
		{
			return ExecuteAPIAsync<GroupMemberInfo, GetGroupMemberInfo>("get_group_member_info", new()
			{
				GroupId = groupId,
				UserId = userId,
				NoCache = noCache,
			}, Guid.NewGuid().ToString());
		}

		public Task<APIResponse<GroupMemberInfoList>> GetGroupMemberListAsync(long groupId)
		{
			return ExecuteAPIAsync<GroupMemberInfoList, GetGroupMemberListInfo>("get_group_member_list", new()
			{
				GroupId = groupId,
			}, Guid.NewGuid().ToString());
		}

		public Task<APIResponse<CookiesInfo>> GetCookiesAsync(string domain)
		{
			return ExecuteAPIAsync<CookiesInfo, GetCookiesInfo>("get_cookies", new()
			{
				Domain = domain,
			}, Guid.NewGuid().ToString());
		}

		public Task<APIResponse<YesInfo>> CanSendImageAsync()
		{
			return ExecuteAPIAsync<YesInfo>("can_send_image", Guid.NewGuid().ToString());
		}

		public Task<APIResponse<YesInfo>> CanSendRecordAsync()
		{
			return ExecuteAPIAsync<YesInfo>("can_send_record", Guid.NewGuid().ToString());
		}

		public Task<APIResponse<VersionInfo>> GetVersionInfoAsync()
		{
			return ExecuteAPIAsync<VersionInfo>("get_version_info", Guid.NewGuid().ToString());
		}

		public Task<APIResponse<EmptyInfo>> RestartAsync()
		{
			return ExecuteAPIAsync<EmptyInfo>("set_restart", Guid.NewGuid().ToString());
		}

		#endregion
	}
}
