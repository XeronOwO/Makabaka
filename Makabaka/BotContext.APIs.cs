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
			ulong userId,
			Message message,
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
			ulong groupId,
			Message message,
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
			ulong userId,
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
			ulong groupId,
			ulong userId,
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
			ulong groupId,
			ulong userId,
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
			ulong groupId,
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
			ulong groupId,
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
			ulong groupId,
			ulong userId,
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
			ulong groupId,
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
			ulong groupId,
			ulong userId,
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
			ulong groupId,
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
			ulong groupId,
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
			ulong groupId,
			ulong userId,
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
			ulong userId,
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
			ulong groupId,
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
			ulong groupId,
			ulong userId,
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
			ulong groupId,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<GroupIdRequestParams, GroupMemberInfo[]>(
				"get_group_member_list",
				new(groupId),
				cancellationToken
				);
		}

		public Task<APIResponse<GroupHonorInfo>> GetGroupHonorInfoAsync(
			ulong groupId,
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
			ulong groupId,
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
			ulong groupId,
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
			ulong groupId,
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
			ulong groupId,
			string fileId,
			uint busId,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<GetGroupFileUrlRequestParams, UrlInfo>(
				"get_group_file_url",
				new(groupId, fileId, busId),
				cancellationToken
				);
		}

		public Task<APIResponse<GroupFileSystemOperationInfo>> MoveGroupFileAsync(
			ulong groupId,
			string fileId,
			string parentDirectory,
			string targetDirectory,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<MoveGroupFileRequestParams, GroupFileSystemOperationInfo>(
				"move_group_file",
				new(groupId, fileId, parentDirectory, targetDirectory),
				cancellationToken
				);
		}

		public Task<APIResponse<GroupFileSystemOperationInfo>> DeleteGroupFileAsync(
			ulong groupId,
			string fileId,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<DeleteGroupFileRequestParams, GroupFileSystemOperationInfo>(
				"delete_group_file",
				new(groupId, fileId),
				cancellationToken
				);
		}

		public Task<APIResponse<GroupFileSystemOperationInfo>> CreateGroupFolderAsync(
			ulong groupId,
			string name,
			string parentId = "",
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<CreateGroupFolderRequestParams, GroupFileSystemOperationInfo>(
				"create_group_file_folder",
				new(groupId, name, parentId),
				cancellationToken
				);
		}

		public Task<APIResponse<GroupFileSystemOperationInfo>> DeleteGroupFolderAsync(
			ulong groupId,
			string folderId,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<DeleteGroupFolderRequestParams, GroupFileSystemOperationInfo>(
				"delete_group_file_folder",
				new(groupId, folderId),
				cancellationToken
				);
		}

		public Task<APIResponse<GroupFileSystemOperationInfo>> RenameGroupFolderAsync(
			ulong groupId,
			string folderId,
			string newFolderName,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<RenameGroupFolderRequestParams, GroupFileSystemOperationInfo>(
				"rename_group_file_folder",
				new(groupId, folderId, newFolderName),
				cancellationToken
				);
		}

		public Task<APIResponse> UploadPrivateFileAsync(
			ulong userId,
			string file,
			string? name = null,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<UploadPrivateFileRequestParams>(
				"upload_private_file",
				new(userId, file, name),
				cancellationToken
				);
		}

		public Task<APIResponse<string[]>> FetchCustomFaceAsync(
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<EmptyRequestParams, string[]>(
				"fetch_custom_face",
				new(),
				cancellationToken
				);
		}

		public Task<APIResponse> SetQQAvatarAsync(
			string file,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<SetQQAvatarRequestParams>(
				"set_qq_avatar",
				new(file),
				cancellationToken
				);
		}

		public Task<APIResponse> DeleteGroupNoticeAsync(
			ulong groupId,
			string noticeId,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<DeleteGroupNoticeRequestParams>(
				"_del_group_notice",
				new(groupId, noticeId),
				cancellationToken
				);
		}

		public Task<APIResponse<GroupNoticeInfo[]>> GetGroupNoticeAsync(
			ulong groupId,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<GroupIdRequestParams, GroupNoticeInfo[]>(
				"_get_group_notice",
				new(groupId),
				cancellationToken
				);
		}

		public Task<APIResponse<ulong>> SetGroupBotAsync(
			ulong groupId,
			ulong botId,
			uint enable,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<SetGroupBotRequestParams, ulong>(
				"set_group_bot_status",
				new(groupId, botId, enable),
				cancellationToken
				);
		}

		public Task<APIResponse<ulong>> SendGroupBotCallbackAsync(
			ulong groupId,
			ulong botId,
			string? data_1 = null,
			string? data_2 = null,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<SendGroupBotCallbackRequestParams, ulong>(
				"send_group_bot_callback",
				new(groupId, botId, data_1, data_2),
				cancellationToken
				);
		}

		public Task<APIResponse<string>> CreateGroupNoticeAsync(
			ulong groupId,
			string content,
			string? image = null,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<CreateGroupNoticeRequestParams, string>(
				"_send_group_notice",
				new(groupId, content, image),
				cancellationToken
				);
		}

		public Task<APIResponse> SetGroupPortraitAsync(
			ulong groupId,
			string file,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<SetGroupPortraitRequestParams>(
				"_send_group_notice",
				new(groupId, file),
				cancellationToken
				);
		}

		public Task<APIResponse> DeleteEssenceMessageAsync(
			long messageId,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<MessageIdRequestParams>(
				"delete_essence_msg",
				new(messageId),
				cancellationToken
				);
		}

		public Task<APIResponse> PokeFriendAsync(
			ulong userId,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<FriendPokeRequestParams>(
				"friend_poke",
				new(userId),
				cancellationToken
				);
		}

		public Task<APIResponse<EssenceMessageSegment[]>> GetGroupEssenceMessageListAsync(
			ulong groupId,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<GroupIdRequestParams, EssenceMessageSegment[]>(
				"get_essence_msg_list",
				new(groupId),
				cancellationToken
				);
		}

		public async Task<APIResponse<PrivateMessagesInfo>> GetFriendMessageHistoryAsync(
			ulong userId,
			long messageId,
			uint count,
			CancellationToken cancellationToken = default
			)
		{
			var result = await ExecuteAPIAsync<GetFriendMessageHistoryRequestParams, PrivateMessagesInfo>(
				"get_friend_msg_history",
				new(userId, messageId, count),
				cancellationToken
				);

			if (result.Data != null)
			{
				foreach (var message in result.Data.Messages)
				{
					// 方面起见，直接使用 EventArgs 反序列化，因此需要手动设置 Context
					message.Context = this;
				}
			}

			return result;
		}

		public async Task<APIResponse<GroupMessagesInfo>> GetGroupMessageHistoryAsync(
			ulong groupId,
			long messageId,
			uint count,
			CancellationToken cancellationToken = default
			)
		{
			var result = await ExecuteAPIAsync<GetGroupMessageHistoryRequestParams, GroupMessagesInfo>(
				"get_group_msg_history",
				new(groupId, messageId, count),
				cancellationToken
				);

			if (result.Data != null)
			{
				foreach (var message in result.Data.Messages)
				{
					// 方面起见，直接使用 EventArgs 反序列化，因此需要手动设置 Context
					message.Context = this;
				}
			}

			return result;
		}

		public Task<APIResponse<string>> GetMusicArkAsync(
			string title = "",
			string desc = "",
			string jumpUrl = "",
			string musicUrl = "",
			string sourceIcon = "",
			string tag = "",
			string preview = "",
			string sourceMsgId = "",
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<GetMusicArkRequestParams, string>(
				"get_music_ark",
				new(title, desc, jumpUrl, musicUrl, sourceIcon, tag, preview, sourceMsgId),
				cancellationToken
				);
		}

		public Task<APIResponse> PokeGroupMemberAsync(
			ulong userId,
			ulong groupId,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<GroupPokeRequestParams>(
				"group_poke",
				new(userId, groupId),
				cancellationToken
				);
		}

		public Task<APIResponse> MarkMessageAsReadAsync(
			long messageId,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<MessageIdRequestParams>(
				"mark_msg_as_read",
				new(messageId),
				cancellationToken
				);
		}

		public Task<APIResponse<string>> SendForwardMessageAsync(
			Message messages,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<SendForwardMessageRequestParams, string>(
				"send_forward_msg",
				new(messages),
				cancellationToken
				);
		}

		public Task<APIResponse<string>> SendGroupForwardMessageAsync(
			ulong groupId,
			Message messages,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<SendGroupForwardMessageRequestParams, string>(
				"send_group_forward_msg",
				new(groupId, messages),
				cancellationToken
				);
		}

		public Task<APIResponse<MessageIdInfo>> SendMessageAsync(
			MessageEventType messageType,
			Message message,
			ulong userId = 0,
			ulong groupId = 0,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<SendMessageRequestParams, MessageIdInfo>(
				"send_msg",
				new(messageType, message, userId, groupId),
				cancellationToken
				);
		}

		public Task<APIResponse<string>> SendPrivateForwardMessageAsync(
			ulong userId,
			Message messages,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<SendPrivateForwardMessageRequestParams, string>(
				"send_private_forward_msg",
				new(userId, messages),
				cancellationToken
				);
		}

		public Task<APIResponse> SetEssenceMessageAsync(
			long messageId,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<SetEssenceMessageRequestParams>(
				"set_essence_msg",
				new(messageId),
				cancellationToken
				);
		}
	}
}
