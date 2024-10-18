using Makabaka.API;
using Makabaka.Messages;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Makabaka
{
	public partial interface IBotContext
	{
		internal BlockingCollection<APIContext> APISendQueue { get; }

		/// <summary>
		/// 执行 API<br/>在有自定义需求时再使用
		/// </summary>
		/// <typeparam name="TReq">请求参数类型</typeparam>
		/// <typeparam name="TRsp">响应数据类型</typeparam>
		/// <param name="action">用于指定要调用的 API</param>
		/// <param name="req">请求参数</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>执行 API 异步任务</returns>
		Task<APIResponse<TRsp>> ExecuteAPIAsync<TReq, TRsp>(string action, TReq req, CancellationToken cancellationToken = default);

		/// <summary>
		/// 执行 API<br/>在有自定义需求时再使用
		/// </summary>
		/// <typeparam name="TReq">请求参数类型</typeparam>
		/// <param name="action">用于指定要调用的 API</param>
		/// <param name="req">请求参数</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>执行 API 异步任务</returns>
		Task<APIResponse> ExecuteAPIAsync<TReq>(string action, TReq req, CancellationToken cancellationToken = default);

		/// <summary>
		/// 发送私聊消息
		/// </summary>
		/// <param name="userId">对方 QQ 号</param>
		/// <param name="message">要发送的内容</param>
		/// <param name="autoEscape">消息内容是否作为纯文本发送（即不解析 CQ 码），只在 message 字段是字符串时有效</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>发送私聊消息异步任务</returns>
		Task<APIResponse<MessageIdResponseData>> SendPrivateMessageAsync(
			long userId,
			Message message,
			bool autoEscape = false,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 发送群消息
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="message">要发送的内容</param>
		/// <param name="autoEscape">消息内容是否作为纯文本发送（即不解析 CQ 码），只在 message 字段是字符串时有效</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>发送群消息异步任务</returns>
		Task<APIResponse<MessageIdResponseData>> SendGroupMessageAsync(
			long groupId,
			Message message,
			bool autoEscape = false,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取商城表情密钥
		/// </summary>
		/// <param name="emojiIds">商城表情</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>获取商城表情密钥异步任务</returns>
		Task<APIResponse<string[]>> FetchMarketFaceKeyAsync(
			string[] emojiIds,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 撤回消息
		/// </summary>
		/// <param name="messageId">消息 ID</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>撤回消息异步任务</returns>
		Task<APIResponse> RevokeMessageAsync(
			long messageId,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取消息
		/// </summary>
		/// <param name="messageId">消息 ID</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>获取消息异步任务</returns>
		Task<APIResponse<GetMessageResponseData>> GetMessageAsync(
			long messageId,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取转发消息
		/// </summary>
		/// <param name="id">合并转发 ID</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>获取转发消息异步任务</returns>
		Task<APIResponse<GetForwardMessageResponseData>> GetForwardMessageAsync(
			string id,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 发送好友赞
		/// </summary>
		/// <param name="userId">对方 QQ 号</param>
		/// <param name="times">赞的次数，每个好友每天最多 10 次</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>发送好友赞异步任务</returns>
		Task<APIResponse> SendLikeAsync(
			long userId,
			int times = 1,
			CancellationToken cancellationToken = default
			);
	}
}
