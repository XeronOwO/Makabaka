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
	internal abstract class WebSocketContext : IWebSocketContext
	{
		#region 构造函数与参数

		public abstract Guid Guid { get; }

		public WebSocketContext()
		{

		}

		#endregion

		#region API执行

		public abstract Task<APIResponse<TResult>> ExecuteAPIAsync<TResult>(string action, string echo);

		public abstract Task<APIResponse<TResult>> ExecuteAPIAsync<TResult, TParam>(string action, TParam @params, string echo);

		public abstract void OnAPIResponse(string data, JObject json, int retcode, string echo);

		#endregion

		#region API

		public Task<APIResponse<MessageIdRes>> SendPrivateMessageAsync(long userId, Message message)
		{
			return ExecuteAPIAsync<MessageIdRes, SendPrivateMessageReq>("send_private_msg", new()
			{
				UserId = userId,
				Message = message,
			}, Guid.NewGuid().ToString());
		}

		public Task<APIResponse<MessageIdRes>> SendGroupMessageAsync(long groupId, Message message)
		{
			return ExecuteAPIAsync<MessageIdRes, SendGroupMessageReq>("send_group_msg", new()
			{
				GroupId = groupId,
				Message = message,
			}, Guid.NewGuid().ToString());
		}

		public Task<APIResponse<EmptyRes>> DeleteMessageAsync(long messageId)
		{
			return ExecuteAPIAsync<EmptyRes, DeleteMessageReq>("delete_msg", new()
			{
				MessageId = messageId,
			}, Guid.NewGuid().ToString());
		}

		public async Task<APIResponse<MessageRes>> GetMessageAsync(long messageId)
		{
			var response = await ExecuteAPIAsync<MessageRes, GetMessageReq>("get_msg", new()
			{
				MessageId = messageId,
			}, Guid.NewGuid().ToString());
			response.Data.Message.PostProcessMessage();
			return response;
		}

		public async Task<APIResponse<ForwardMessageRes>> GetForwardMessageAsync(string id)
		{
			var response = await ExecuteAPIAsync<ForwardMessageRes, GetForwardMessageReq>("get_forward_msg", new()
			{
				Id = id,
			}, Guid.NewGuid().ToString());
			foreach (var node in response.Data.Message)
			{
				node.PostProcessContent();
			}
			return response;
		}

		public async Task<APIResponse<EmptyRes>> SendLikeAsync(long userId, int times = 1)
		{
			var response = await ExecuteAPIAsync<EmptyRes, SendLikeReq>("send_like", new()
			{
				UserId = userId,
				Times = times,
			}, Guid.NewGuid().ToString());
			return response;
		}

		public Task<APIResponse<EmptyRes>> KickGroupMemberAsync(long groupId, long userId, bool rejectAddRequest = false)
		{
			return ExecuteAPIAsync<EmptyRes, KickGroupMemberReq>("set_group_kick", new()
			{
				GroupId = groupId,
				UserId = userId,
				RejectAddRequest = rejectAddRequest,
			}, Guid.NewGuid().ToString());
		}

		public Task<APIResponse<EmptyRes>> MuteGroupMemberAsync(long groupId, long userId, int duration = 30 * 60)
		{
			return ExecuteAPIAsync<EmptyRes, MuteGroupMemberReq>("set_group_ban", new()
			{
				GroupId = groupId,
				UserId = userId,
				Duration = duration,
			}, Guid.NewGuid().ToString());
		}

		public Task<APIResponse<EmptyRes>> UnmuteGroupMemberAsync(long groupId, long userId)
		{
			return MuteGroupMemberAsync(groupId, userId, 0);
		}

		public Task<APIResponse<EmptyRes>> MuteGroupAllAsync(long groupId)
		{
			return ExecuteAPIAsync<EmptyRes, MuteGroupAllReq>("set_group_whole_ban", new()
			{
				GroupId = groupId,
				Enable = true,
			}, Guid.NewGuid().ToString());
		}

		public Task<APIResponse<EmptyRes>> UnmuteGroupAllAsync(long groupId)
		{
			return ExecuteAPIAsync<EmptyRes, MuteGroupAllReq>("set_group_whole_ban", new()
			{
				GroupId = groupId,
				Enable = false,
			}, Guid.NewGuid().ToString());
		}

		public Task<APIResponse<EmptyRes>> SetGroupAdminAsync(long groupId, long userId, bool enable = true)
		{
			return ExecuteAPIAsync<EmptyRes, SetGroupAdminReq>("set_group_admin", new()
			{
				GroupId = groupId,
				UserId = userId,
				Enable = false,
			}, Guid.NewGuid().ToString());
		}

		public Task<APIResponse<EmptyRes>> SetGroupCardAsync(long groupId, long userId, string card)
		{
			return ExecuteAPIAsync<EmptyRes, SetGroupCardReq>("set_group_card", new()
			{
				GroupId = groupId,
				UserId = userId,
				Card = card,
			}, Guid.NewGuid().ToString());
		}

		public Task<APIResponse<EmptyRes>> SetGroupNameAsync(long groupId, string groupName)
		{
			return ExecuteAPIAsync<EmptyRes, SetGroupNameReq>("set_group_name", new()
			{
				GroupId = groupId,
				GroupName = groupName,
			}, Guid.NewGuid().ToString());
		}

		public Task<APIResponse<EmptyRes>> LeaveGroupAsync(long groupId, bool isDismiss)
		{
			return ExecuteAPIAsync<EmptyRes, SetGroupLeaveReq>("set_group_leave", new()
			{
				GroupId = groupId,
				IsDismiss = isDismiss,
			}, Guid.NewGuid().ToString());
		}

		public Task<APIResponse<EmptyRes>> SetFriendAddRequestAsync(string flag, bool approve = true, string remark = null)
		{
			return ExecuteAPIAsync<EmptyRes, SetFriendAddRequestReq>("set_friend_add_request", new()
			{
				Flag = flag,
				Approve = approve,
				Remark = remark,
			}, Guid.NewGuid().ToString());
		}

		public Task<APIResponse<EmptyRes>> SetGroupAddRequestAsync(string flag, string subType, bool approve = true, string reason = null)
		{
			return ExecuteAPIAsync<EmptyRes, SetGroupAddRequestReq>("set_group_add_request", new()
			{
				Flag = flag,
				SubType = subType,
				Approve = approve,
				Reason = reason,
			}, Guid.NewGuid().ToString());
		}

		public Task<APIResponse<LoginRes>> GetLoginInfoAsync()
		{
			return ExecuteAPIAsync<LoginRes>("get_login_info", Guid.NewGuid().ToString());
		}

		public Task<APIResponse<FriendListRes>> GetFriendListAsync()
		{
			return ExecuteAPIAsync<FriendListRes>("get_friend_list", Guid.NewGuid().ToString());
		}

		public Task<APIResponse<GroupRes>> GetGroupAsync(long groupId, bool noCache)
		{
			return ExecuteAPIAsync<GroupRes, GetGroupReq>("get_group_info", new()
			{
				GroupId = groupId,
				NoCache = noCache,
			}, Guid.NewGuid().ToString());
		}

		public Task<APIResponse<GroupListRes>> GetGroupListAsync()
		{
			return ExecuteAPIAsync<GroupListRes>("get_group_list", Guid.NewGuid().ToString());
		}

		public Task<APIResponse<GroupMemberRes>> GetGroupMemberAsync(long groupId, long userId, bool noCache = false)
		{
			return ExecuteAPIAsync<GroupMemberRes, GetGroupMemberReq>("get_group_member_info", new()
			{
				GroupId = groupId,
				UserId = userId,
				NoCache = noCache,
			}, Guid.NewGuid().ToString());
		}

		public Task<APIResponse<GroupMemberListRes>> GetGroupMemberListAsync(long groupId)
		{
			return ExecuteAPIAsync<GroupMemberListRes, GetGroupMemberListReq>("get_group_member_list", new()
			{
				GroupId = groupId,
			}, Guid.NewGuid().ToString());
		}

		public Task<APIResponse<CookiesRes>> GetCookiesAsync(string domain)
		{
			return ExecuteAPIAsync<CookiesRes, GetCookiesReq>("get_cookies", new()
			{
				Domain = domain,
			}, Guid.NewGuid().ToString());
		}

		public Task<APIResponse<YesRes>> CanSendImageAsync()
		{
			return ExecuteAPIAsync<YesRes>("can_send_image", Guid.NewGuid().ToString());
		}

		public Task<APIResponse<YesRes>> CanSendRecordAsync()
		{
			return ExecuteAPIAsync<YesRes>("can_send_record", Guid.NewGuid().ToString());
		}

		public Task<APIResponse<VersionRes>> GetVersionInfoAsync()
		{
			return ExecuteAPIAsync<VersionRes>("get_version_info", Guid.NewGuid().ToString());
		}

		public Task<APIResponse<EmptyRes>> RestartAsync()
		{
			return ExecuteAPIAsync<EmptyRes>("set_restart", Guid.NewGuid().ToString());
		}

		#endregion

		#region 拓展API

		public Task<APIResponse<string>> SendForwardMessageAsync(List<NodeSegment> nodes)
		{
			return ExecuteAPIAsync<string, SendForwardMessageReq>("send_forward_msg", new()
			{
				Messages = SendForwardMessageNodeListReq.FromNodeSegments(nodes),
			}, Guid.NewGuid().ToString());
		}

		#endregion
	}
}
