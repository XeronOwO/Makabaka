using Makabaka.API;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;
using Makabaka.Utils;
using Makabaka.Messages;
using System;
using Makabaka.Exceptions;

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
	}
}
