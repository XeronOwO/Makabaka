using Makabaka.API;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;
using Makabaka.Utils;
using Makabaka.Messages;
using System;
using Makabaka.Exceptions;
using System.Timers;
using Makabaka.Events;

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

		public Task<APIResponse<MessageIdResponseData>> SendPrivateMessageAsync(
			long userId,
			Message message,
			bool autoEscape = false,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<SendPrivateMessageRequestParams, MessageIdResponseData>(
				"send_private_msg",
				new(userId, message),
				cancellationToken
				);
		}

		public Task<APIResponse<MessageIdResponseData>> SendGroupMessageAsync(
			long groupId,
			Message message,
			bool autoEscape = false,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<SendGroupMessageRequestParams, MessageIdResponseData>(
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

		public Task<APIResponse<GetMessageResponseData>> GetMessageAsync(
			long messageId,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<MessageIdRequestParams, GetMessageResponseData>(
				"get_msg",
				new(messageId),
				cancellationToken
				);
		}

		public Task<APIResponse<GetForwardMessageResponseData>> GetForwardMessageAsync(
			string id,
			CancellationToken cancellationToken = default
			)
		{
			return ExecuteAPIAsync<GetForwardMessageRequestParams, GetForwardMessageResponseData>(
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
	}
}
