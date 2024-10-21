using Makabaka.API;
using Makabaka.Events;
using Makabaka.Exceptions;
using Makabaka.Messages;
using Makabaka.Models;
using Makabaka.Utils;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Makabaka
{
	internal partial class BotContext
	{
		BlockingCollection<APIContext> IBotContext.APISendQueue { get; } = [];

		public async Task<APIResponse<TRsp>> ExecuteAPIAsync<TReq, TRsp>(
			string action,
			TReq req,
			CancellationToken cancellationToken = default
			)
		{
			var timeoutCancellationTokenSource = new CancellationTokenSource(ApiTimeout);
			var linkedCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(
				cancellationToken,
				timeoutCancellationTokenSource.Token
				);

			var request = new APIRequest<TReq>(action, req);
			var context = new APIContext<APIResponse<TRsp>>(request);
			((IBotContext)this).APISendQueue.Add(context);

			var task = context.ResponseTaskCompletionSource.Task;

			try
			{
				var response = await task.WithCancellationToken(linkedCancellationTokenSource.Token);
				return (APIResponse<TRsp>)response;
			}
			catch (OperationCanceledException)
			{
				cancellationToken.ThrowIfCancellationRequested();
				throw new APITimeoutException(request.Echo);
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public async Task<APIResponse> ExecuteAPIAsync<TReq>(
			string action,
			TReq req,
			CancellationToken cancellationToken = default
			)
		{
			var timeoutCancellationTokenSource = new CancellationTokenSource(ApiTimeout);
			var linkedCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(
				cancellationToken,
				timeoutCancellationTokenSource.Token
				);

			var request = new APIRequest<TReq>(action, req);
			var context = new APIContext<APIResponse>(request);
			((IBotContext)this).APISendQueue.Add(context);

			var task = context.ResponseTaskCompletionSource.Task;

			try
			{
				var response = await task.WithCancellationToken(linkedCancellationTokenSource.Token);
				return response;
			}
			catch (OperationCanceledException)
			{
				cancellationToken.ThrowIfCancellationRequested();
				throw new APITimeoutException(request.Echo);
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public Task<APIResponse<MessageIdInfo>> SendPrivateMessageAsync(
			long userId,
			Message message,
			bool autoEscape = false,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<SendPrivateMessageRequestParams, MessageIdInfo>(
				"send_private_msg",
				new(userId, message),
				cancellationToken
				);
		}

		public Task<APIResponse<MessageIdInfo>> SendGroupMessageAsync(
			long groupId,
			Message message,
			bool autoEscape = false,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<SendGroupMessageRequestParams, MessageIdInfo>(
				"send_group_msg",
				new(groupId, message),
				cancellationToken
				);
		}

		public Task<APIResponse<string[]>> FetchMarketFaceKeyAsync(
			string[] emojiIds,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<FetchMarketFaceKeyRequestParams, string[]>(
				"fetch_mface_key",
				new(emojiIds),
				cancellationToken
				);
		}

		public Task<APIResponse> RevokeMessageAsync(
			long messageId,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<MessageIdRequestParams>(
				"delete_msg",
				new(messageId),
				cancellationToken
				);
		}

		public Task<APIResponse<MessageInfo>> GetMessageAsync(
			long messageId,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<MessageIdRequestParams, MessageInfo>(
				"get_msg",
				new(messageId),
				cancellationToken
				);
		}

		public Task<APIResponse<ForwardMessageInfo>> GetForwardMessageAsync(
			string id,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<GetForwardMessageRequestParams, ForwardMessageInfo>(
				"get_forward_msg",
				new(id),
				cancellationToken
				);
		}

		public Task<APIResponse> SendLikeAsync(
			long userId,
			int times = 1,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<SendLikeRequestParams>(
				"send_like",
				new(userId, times),
				cancellationToken
				);
		}

		public Task<APIResponse> KickGroupMemberAsync(
			long groupId,
			long userId,
			bool rejectAddRequest = false,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<KickGroupMemberRequestParams>(
			"send_like",
				new(groupId, userId, rejectAddRequest),
				cancellationToken
				);
		}

		public Task<APIResponse> MuteGroupMemberAsync(
			long groupId,
			long userId,
			int duration = 30 * 60,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<MuteGroupMemberRequestParams>(
				"set_group_ban",
				new(groupId, userId, duration),
				cancellationToken
				);
		}

		public Task<APIResponse> MuteGroupAnonymousMemberAsync(
			long groupId,
			GroupMessageAnonymousSenderInfo? anonymous = null,
			string? anonymousFlag = null,
			string? flag = null,
			int duration = 30 * 60,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<MuteGroupAnonymousMemberRequestParams>(
				"set_group_anonymous_ban",
				new(groupId, anonymous, anonymousFlag, flag, duration),
				cancellationToken
				);
		}

		public Task<APIResponse> MuteGroupAsync(
			long groupId,
			bool enable = true,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<MuteGroupRequestParams>(
				"set_group_whole_ban",
				new(groupId, enable),
				cancellationToken
				);
		}

		public Task<APIResponse> SetGroupAdminAsync(
			long groupId,
			long userId,
			bool enable = true,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<SetGroupAdminRequestParams>(
				"set_group_admin",
				new(groupId, userId, enable),
				cancellationToken
				);
		}

		public Task<APIResponse> SetGroupAnonymousAsync(
			long groupId,
			bool enable = true,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<SetGroupAnonymousRequestParams>(
				"set_group_anonymous",
				new(groupId, enable),
				cancellationToken
				);
		}

		public Task<APIResponse> SetGroupMemberCardAsync(
			long groupId,
			long userId,
			string? card = null,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<SetGroupMemberCardRequestParams>(
				"set_group_card",
				new(groupId, userId, card),
				cancellationToken
				);
		}

		public Task<APIResponse> SetGroupNameAsync(
			long groupId,
			string groupName,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<SetGroupNameRequestParams>(
				"set_group_card",
				new(groupId, groupName),
				cancellationToken
				);
		}

		public Task<APIResponse> LeaveGroupAsync(
			long groupId,
			bool isDismiss = false,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<LeaveGroupRequestParams>(
				"set_group_leave",
				new(groupId, isDismiss),
				cancellationToken
				);
		}

		public Task<APIResponse> SetGroupMemberTitleAsync(
			long groupId,
			long userId,
			string? specialTitle = null,
			int duration = -1,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<SetGroupMemberTitleRequestParams>(
				"set_group_special_title",
				new(groupId, userId, specialTitle, duration),
				cancellationToken
				);
		}

		public Task<APIResponse> SetFriendAddRequestAsync(
			string flag,
			bool approve = true,
			string? remark = null,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<SetFriendAddRequestRequestParams>(
				"set_friend_add_request",
				new(flag, approve, remark),
				cancellationToken
				);
		}

		public Task<APIResponse> SetGroupAddRequestAsync(
			string flag,
			GroupAddRequestEventType subType,
			bool approve = true,
			string? reason = null,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<SetGroupAddRequestRequestParams>(
				"set_group_add_request",
				new(flag, subType, approve, reason),
				cancellationToken
				);
		}

		public Task<APIResponse<LoginInfo>> GetLoginInfoAsync(
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<EmptyRequestParams, LoginInfo>(
				"get_login_info",
				new(),
				cancellationToken
				);
		}

		public Task<APIResponse<StrangerInfo>> GetStrangerInfoAsync(
			long userId,
			bool noCache = false,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<GetStrangerInfoRequestParams, StrangerInfo>(
				"get_stranger_info",
				new(userId, noCache),
				cancellationToken
				);
		}

		public Task<APIResponse<FriendInfo[]>> GetFriendListAsync(
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<EmptyRequestParams, FriendInfo[]>(
				"get_friend_list",
				new(),
				cancellationToken
				);
		}

		public Task<APIResponse<GroupInfo>> GetGroupInfoAsync(
			long groupId,
			bool noCache = false,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<GetGroupInfoRequestParams, GroupInfo>(
				"get_group_info",
				new(groupId, noCache),
				cancellationToken
				);
		}

		public Task<APIResponse<GroupInfo[]>> GetGroupListAsync(
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<EmptyRequestParams, GroupInfo[]>(
				"get_group_list",
				new(),
				cancellationToken
				);
		}

		public Task<APIResponse<GroupMemberInfo>> GetGroupMemberInfoAsync(
			long groupId,
			long userId,
			bool noCache = false,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<GetGroupMemberInfoRequestParams, GroupMemberInfo>(
				"get_group_member_info",
				new(groupId, userId, noCache),
				cancellationToken
				);
		}

		public Task<APIResponse<GroupMemberInfo[]>> GetGroupMemberListAsync(
			long groupId,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<GetGroupMemberListRequestParams, GroupMemberInfo[]>(
				"get_group_member_list",
				new(groupId),
				cancellationToken
				);
		}

		public Task<APIResponse<GroupHonorInfo>> GetGroupHonorInfoAsync(
			long groupId,
			GetGroupHonorInfoType type = GetGroupHonorInfoType.All,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<GetGroupHonorInfoRequestParams, GroupHonorInfo>(
				"get_group_honor_info",
				new(groupId, type),
				cancellationToken
				);
		}

		public Task<APIResponse<CookiesInfo>> GetCookiesAsync(
			string domain,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<GetCookiesRequestParams, CookiesInfo>(
				"get_cookies",
				new(domain),
				cancellationToken
				);
		}

		public Task<APIResponse<CsrfTokenInfo>> GetCsrfTokenAsync(
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<EmptyRequestParams, CsrfTokenInfo>(
				"get_csrf_token",
				new(),
				cancellationToken
				);
		}

		public Task<APIResponse<CredentialsInfo>> GetCredentialsAsync(
			string domain,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<GetCookiesRequestParams, CredentialsInfo>(
				"get_credentials",
				new(domain),
				cancellationToken
				);
		}

		public Task<APIResponse<RecordInfo>> GetRecordAsync(
			string file,
			GetRecordFormatType outFormat,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<GetRecordRequestParams, RecordInfo>(
				"get_record",
				new(file, outFormat),
				cancellationToken
				);
		}

		public Task<APIResponse<ImageInfo>> GetImageAsync(
			string file,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<GetImageRequestParams, ImageInfo>(
				"get_image",
				new(file),
				cancellationToken
				);
		}

		public Task<APIResponse<YesInfo>> CanSendImageAsync(
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<EmptyRequestParams, YesInfo>(
				"can_send_image",
				new(),
				cancellationToken
				);
		}

		public Task<APIResponse<YesInfo>> CanSendRecordAsync(
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<EmptyRequestParams, YesInfo>(
				"can_send_record",
				new(),
				cancellationToken
				);
		}

		public Task<APIResponse<StatusInfo>> GetStatusAsync(
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<EmptyRequestParams, StatusInfo>(
				"get_status",
				new(),
				cancellationToken
				);
		}

		public Task<APIResponse<VersionInfo>> GetVersionInfoAsync(
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<EmptyRequestParams, VersionInfo>(
				"get_version_info",
				new(),
				cancellationToken
				);
		}

		public Task<APIResponse> RestartAsync(
			long delay = 0,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<RestartRequestParams>(
				"set_restart",
				new(delay),
				cancellationToken
				);
		}

		public Task<APIResponse<string>> UploadImageAsync(
			string file,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<UploadImageRequestParams, string>(
				"upload_image",
				new(file),
				cancellationToken
				);
		}

		public Task<APIResponse> UploadGroupFileAsync(
			long groupId,
			string file,
			string? name = null,
			string? folder = null,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<UploadGroupFileRequestParams>(
				"upload_group_file",
				new(groupId, file, name, folder),
				cancellationToken
				);
		}

		public Task<APIResponse<GroupFilesInfo>> GetGroupFilesByFolderAsync(
			long groupId,
			string? folderId = null,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<GetGroupFilesRequestParams, GroupFilesInfo>(
				"get_group_files_by_folder",
				new(groupId, folderId),
				cancellationToken
				);
		}

		public Task<APIResponse<GroupFilesInfo>> GetGroupRootFilesAsync(
			long groupId,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<GetGroupFilesRequestParams, GroupFilesInfo>(
				"get_group_root_files",
				new(groupId),
				cancellationToken
				);
		}

		public Task<APIResponse<UrlInfo>> GetGroupFileUrlAsync(
			long groupId,
			string fileId,
			uint busid,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<GetGroupFileUrlRequestParams, UrlInfo>(
				"get_group_file_url",
				new(groupId, fileId, busid),
				cancellationToken
				);
		}
	}
}
