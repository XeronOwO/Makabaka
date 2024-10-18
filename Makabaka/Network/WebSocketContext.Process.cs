using Makabaka.API;
using Makabaka.Events;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Makabaka.Network
{
	internal partial class WebSocketContext
	{

		[Meta(MetaEventType.Lifecycle)]
		private async Task<bool> ProcessLifecycleAsync(JsonNode node)
		{
			try
			{
				var info = node.Deserialize<LifecycleEventArgs>(_jsonSerializerOptions);
				if (info == null)
				{
					_logger.LogError(SR.MessageDeserializeAsFailed, nameof(LifecycleEventArgs));
					return false;
				}

				info.Context = botContext;
				await botContext.InvokeOnLifecycle(this, info);
			}
			catch (Exception e)
			{
				_logger.LogError(e, SR.MessageHandleError);
			}
			return true;
		}

		[Meta(MetaEventType.Heartbeat)]
		private async Task<bool> ProcessHeartbeatAsync(JsonNode node)
		{
			try
			{
				var info = node.Deserialize<HeartbeatEventArgs>(_jsonSerializerOptions);
				if (info == null)
				{
					_logger.LogError(SR.MessageDeserializeAsFailed, nameof(HeartbeatEventArgs));
					return false;
				}

				info.Context = botContext;
				await botContext.InvokeOnHeartbeat(this, info);
			}
			catch (Exception e)
			{
				_logger.LogError(e, SR.MessageHandleError);
			}
			return true;
		}

		[Message(MessageEventType.Private)]
		private async Task<bool> ProcessPrivateMessageAsync(JsonNode node)
		{
			try
			{
				var info = node.Deserialize<PrivateMessageEventArgs>(_jsonSerializerOptions);
				if (info == null)
				{
					_logger.LogError(SR.MessageDeserializeAsFailed, nameof(PrivateMessageEventArgs));
					return false;
				}

				_logger.LogInformation(SR.PrivateMessage, info.UserId, info.Message.ToString());

				info.Context = botContext;
				await botContext.InvokeOnPrivateMessage(this, info);
			}
			catch (Exception e)
			{
				_logger.LogError(e, SR.MessageHandleError);
			}
			return true;
		}

		[Message(MessageEventType.Group)]
		private async Task<bool> ProcessGroupMessageAsync(JsonNode node)
		{
			try
			{
				var info = node.Deserialize<GroupMessageEventArgs>(_jsonSerializerOptions);
				if (info == null)
				{
					_logger.LogError(SR.MessageDeserializeAsFailed, nameof(GroupMessageEventArgs));
					return false;
				}

				_logger.LogInformation(SR.GroupMessage, info.GroupId, info.UserId, info.Message.ToString());

				info.Context = botContext;
				await botContext.InvokeOnGroupMessage(this, info);
			}
			catch (Exception e)
			{
				_logger.LogError(e, SR.MessageHandleError);
			}
			return true;
		}

		[Notice(NoticeEventType.GroupUpload)]
		private async Task<bool> ProcessGroupFileUploadAsync(JsonNode node)
		{
			try
			{
				var info = node.Deserialize<GroupFileUploadEventArgs>(_jsonSerializerOptions);
				if (info == null)
				{
					_logger.LogError(SR.MessageDeserializeAsFailed, nameof(GroupFileUploadEventArgs));
					return false;
				}

				info.Context = botContext;
				await botContext.InvokeOnGroupFileUploadMessage(this, info);
			}
			catch (Exception e)
			{
				_logger.LogError(e, SR.MessageHandleError);
			}
			return true;
		}

		[Notice(NoticeEventType.GroupAdmin)]
		private async Task<bool> ProcessGroupAdminChangeAsync(JsonNode node)
		{
			try
			{
				var info = node.Deserialize<GroupAdminChangeEventArgs>(_jsonSerializerOptions);
				if (info == null)
				{
					_logger.LogError(SR.MessageDeserializeAsFailed, nameof(GroupAdminChangeEventArgs));
					return false;
				}

				info.Context = botContext;
				await botContext.InvokeOnGroupAdminChange(this, info);
			}
			catch (Exception e)
			{
				_logger.LogError(e, SR.MessageHandleError);
			}
			return true;
		}

		[Notice(NoticeEventType.GroupDecrease)]
		private async Task<bool> ProcessGroupMemberDecreaseAsync(JsonNode node)
		{
			try
			{
				var info = node.Deserialize<GroupMemberDecreaseEventArgs>(_jsonSerializerOptions);
				if (info == null)
				{
					_logger.LogError(SR.MessageDeserializeAsFailed, nameof(GroupMemberDecreaseEventArgs));
					return false;
				}

				info.Context = botContext;
				await botContext.InvokeOnGroupMemberDecrease(this, info);
			}
			catch (Exception e)
			{
				_logger.LogError(e, SR.MessageHandleError);
			}
			return true;
		}

		[Notice(NoticeEventType.GroupIncrease)]
		private async Task<bool> ProcessGroupMemberIncreaseAsync(JsonNode node)
		{
			try
			{
				var info = node.Deserialize<GroupMemberIncreaseEventArgs>(_jsonSerializerOptions);
				if (info == null)
				{
					_logger.LogError(SR.MessageDeserializeAsFailed, nameof(GroupMemberIncreaseEventArgs));
					return false;
				}

				info.Context = botContext;
				await botContext.InvokeOnGroupMemberIncrease(this, info);
			}
			catch (Exception e)
			{
				_logger.LogError(e, SR.MessageHandleError);
			}
			return true;
		}

		[Notice(NoticeEventType.GroupBan)]
		private async Task<bool> ProcessGroupMemberMuteAsync(JsonNode node)
		{
			try
			{
				var info = node.Deserialize<GroupMemberMuteEventArgs>(_jsonSerializerOptions);
				if (info == null)
				{
					_logger.LogError(SR.MessageDeserializeAsFailed, nameof(GroupMemberMuteEventArgs));
					return false;
				}

				info.Context = botContext;
				await botContext.InvokeOnGroupMemberMute(this, info);
			}
			catch (Exception e)
			{
				_logger.LogError(e, SR.MessageHandleError);
			}
			return true;
		}

		[Notice(NoticeEventType.FriendAdd)]
		private async Task<bool> ProcessFriendAddAsync(JsonNode node)
		{
			try
			{
				var info = node.Deserialize<FriendAddEventArgs>(_jsonSerializerOptions);
				if (info == null)
				{
					_logger.LogError(SR.MessageDeserializeAsFailed, nameof(FriendAddEventArgs));
					return false;
				}

				info.Context = botContext;
				await botContext.InvokeOnFriendAdd(this, info);
			}
			catch (Exception e)
			{
				_logger.LogError(e, SR.MessageHandleError);
			}
			return true;
		}

		[Notice(NoticeEventType.GroupRecall)]
		private async Task<bool> ProcessGroupMessageWithdrawAsync(JsonNode node)
		{
			try
			{
				var info = node.Deserialize<GroupMessageWithdrawEventArgs>(_jsonSerializerOptions);
				if (info == null)
				{
					_logger.LogError(SR.MessageDeserializeAsFailed, nameof(GroupMessageWithdrawEventArgs));
					return false;
				}

				info.Context = botContext;
				await botContext.InvokeOnGroupMessageWithdraw(this, info);
			}
			catch (Exception e)
			{
				_logger.LogError(e, SR.MessageHandleError);
			}
			return true;
		}

		[Notice(NoticeEventType.FriendRecall)]
		private async Task<bool> ProcessFriendMessageWithdrawAsync(JsonNode node)
		{
			try
			{
				var info = node.Deserialize<FriendMessageWithdrawEventArgs>(_jsonSerializerOptions);
				if (info == null)
				{
					_logger.LogError(SR.MessageDeserializeAsFailed, nameof(FriendMessageWithdrawEventArgs));
					return false;
				}

				info.Context = botContext;
				await botContext.InvokeOnFriendMessageWithdraw(this, info);
			}
			catch (Exception e)
			{
				_logger.LogError(e, SR.MessageHandleError);
			}
			return true;
		}

		[Notice(NoticeEventType.Reaction)]
		private async Task<bool> ProcessGroupReactionAsync(JsonNode node)
		{
			try
			{
				var info = node.Deserialize<ReactionEventArgs>(_jsonSerializerOptions);
				if (info == null)
				{
					_logger.LogError(SR.MessageDeserializeAsFailed, nameof(ReactionEventArgs));
					return false;
				}

				info.Context = botContext;
				await botContext.InvokeOnGroupReaction(this, info);
			}
			catch (Exception e)
			{
				_logger.LogError(e, SR.MessageHandleError);
			}
			return true;
		}

		[Notify(NotifyEventType.Poke)]
		private async Task<bool> ProcessGroupPokeAsync(JsonNode node)
		{
			try
			{
				var info = node.Deserialize<GroupPokeEventArgs>(_jsonSerializerOptions);
				if (info == null)
				{
					_logger.LogError(SR.MessageDeserializeAsFailed, nameof(GroupPokeEventArgs));
					return false;
				}

				info.Context = botContext;
				await botContext.InvokeOnGroupPoke(this, info);
			}
			catch (Exception e)
			{
				_logger.LogError(e, SR.MessageHandleError);
			}
			return true;
		}

		[Notify(NotifyEventType.LuckyKing)]
		private async Task<bool> ProcessGroupLuckyKingAsync(JsonNode node)
		{
			try
			{
				var info = node.Deserialize<GroupLuckyKingEventArgs>(_jsonSerializerOptions);
				if (info == null)
				{
					_logger.LogError(SR.MessageDeserializeAsFailed, nameof(GroupLuckyKingEventArgs));
					return false;
				}

				info.Context = botContext;
				await botContext.InvokeOnGroupLuckyKing(this, info);
			}
			catch (Exception e)
			{
				_logger.LogError(e, SR.MessageHandleError);
			}
			return true;
		}

		[Notify(NotifyEventType.Honor)]
		private async Task<bool> ProcessGroupMemberHonorChangeAsync(JsonNode node)
		{
			try
			{
				var info = node.Deserialize<GroupMemberHonorChangeEventArgs>(_jsonSerializerOptions);
				if (info == null)
				{
					_logger.LogError(SR.MessageDeserializeAsFailed, nameof(GroupMemberHonorChangeEventArgs));
					return false;
				}

				info.Context = botContext;
				await botContext.InvokeOnGroupMemberHonorChange(this, info);
			}
			catch (Exception e)
			{
				_logger.LogError(e, SR.MessageHandleError);
			}
			return true;
		}

		[Request(RequestEventType.Friend)]
		private async Task<bool> ProcessFriendAddRequestAsync(JsonNode node)
		{
			try
			{
				var info = node.Deserialize<FriendAddRequestEventArgs>(_jsonSerializerOptions);
				if (info == null)
				{
					_logger.LogError(SR.MessageDeserializeAsFailed, nameof(FriendAddRequestEventArgs));
					return false;
				}

				info.Context = botContext;
				await botContext.InvokeOnFriendAddRequest(this, info);
			}
			catch (Exception e)
			{
				_logger.LogError(e, SR.MessageHandleError);
			}
			return true;
		}

		[Request(RequestEventType.Group)]
		private async Task<bool> ProcessGroupAddRequestAsync(JsonNode node)
		{
			try
			{
				var info = node.Deserialize<GroupAddRequestEventArgs>(_jsonSerializerOptions);
				if (info == null)
				{
					_logger.LogError(SR.MessageDeserializeAsFailed, nameof(GroupAddRequestEventArgs));
					return false;
				}

				info.Context = botContext;
				await botContext.InvokeOnGroupAddRequest(this, info);
			}
			catch (Exception e)
			{
				_logger.LogError(e, SR.MessageHandleError);
			}
			return true;
		}

		protected ConcurrentDictionary<Guid, APIContext> APIReceiveDict { get; } = [];

		[API]
		private Task<bool> ProcessAPIAsync(JsonNode node)
		{
			try
			{
				var echo = Guid.Parse((string)node["echo"]!);
				if (!APIReceiveDict.TryRemove(echo, out var apiContext))
				{
					_logger.LogError(SR.UnknownAPIEcho, echo);
					return Task.FromResult(true);
				}

				var response = node.Deserialize(apiContext.ResponseType, _jsonSerializerOptions);
				if (response == null)
				{
					_logger.LogError(SR.MessageDeserializeAsFailed, apiContext.ResponseType.Name);
					return Task.FromResult(false);
				}

				apiContext.ResponseTaskCompletionSource.SetResult((APIResponse)response);
			}
			catch (Exception e)
			{
				_logger.LogError(e, SR.MessageHandleError);
			}
			return Task.FromResult(true);
		}
	}
}
