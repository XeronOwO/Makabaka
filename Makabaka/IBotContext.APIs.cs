﻿using Makabaka.API;
using Makabaka.Events;
using Makabaka.Messages;
using Makabaka.Models;
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
		/// <returns>响应数据</returns>
		Task<APIResponse<TRsp>> ExecuteAPIAsync<TReq, TRsp>(string action, TReq req, CancellationToken cancellationToken = default);

		/// <summary>
		/// 执行 API<br/>在有自定义需求时再使用
		/// </summary>
		/// <typeparam name="TReq">请求参数类型</typeparam>
		/// <param name="action">用于指定要调用的 API</param>
		/// <param name="req">请求参数</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns></returns>
		Task<APIResponse> ExecuteAPIAsync<TReq>(string action, TReq req, CancellationToken cancellationToken = default);

		/// <summary>
		/// 发送私聊消息
		/// </summary>
		/// <param name="userId">对方 QQ 号</param>
		/// <param name="message">要发送的内容</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>消息 ID 信息</returns>
		Task<APIResponse<MessageIdInfo>> SendPrivateMessageAsync(
			ulong userId,
			Message message,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 发送群消息
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="message">要发送的内容</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>消息 ID 信息</returns>
		Task<APIResponse<MessageIdInfo>> SendGroupMessageAsync(
			ulong groupId,
			Message message,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取商城表情密钥
		/// </summary>
		/// <param name="emojiIds">商城表情</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>密钥列表</returns>
		Task<APIResponse<string[]>> FetchMarketFaceKeyAsync(
			string[] emojiIds,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 撤回消息
		/// </summary>
		/// <param name="messageId">消息 ID</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns></returns>
		Task<APIResponse> RevokeMessageAsync(
			long messageId,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取消息
		/// </summary>
		/// <param name="messageId">消息 ID</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>消息信息</returns>
		Task<APIResponse<MessageInfo>> GetMessageAsync(
			long messageId,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取转发消息
		/// </summary>
		/// <param name="id">合并转发 ID</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>转发消息信息</returns>
		Task<APIResponse<ForwardMessageInfo>> GetForwardMessageAsync(
			string id,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 发送好友赞
		/// </summary>
		/// <param name="userId">对方 QQ 号</param>
		/// <param name="times">赞的次数，每个好友每天最多 10 次</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns></returns>
		Task<APIResponse> SendLikeAsync(
			ulong userId,
			int times = 1,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 踢出群成员
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="userId">要踢的 QQ 号</param>
		/// <param name="rejectAddRequest">拒绝此人的加群请求</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns></returns>
		Task<APIResponse> KickGroupMemberAsync(
			ulong groupId,
			ulong userId,
			bool rejectAddRequest = false,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 群组单人禁言
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="userId">要禁言的 QQ 号</param>
		/// <param name="duration">禁言时长，单位秒，0 表示取消禁言</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns></returns>
		Task<APIResponse> MuteGroupMemberAsync(
			ulong groupId,
			ulong userId,
			int duration = 30 * 60,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 群组匿名用户禁言
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="anonymous">可选，要禁言的匿名用户对象（群消息上报的 anonymous 字段）</param>
		/// <param name="anonymousFlag">可选，要禁言的匿名用户的 flag（需从群消息上报的数据中获得）</param>
		/// <param name="flag">可选，要禁言的匿名用户的 flag（需从群消息上报的数据中获得）</param>
		/// <param name="duration">禁言时长，单位秒，无法取消匿名用户禁言</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns></returns>
		Task<APIResponse> MuteGroupAnonymousMemberAsync(
			ulong groupId,
			GroupMessageAnonymousSenderInfo? anonymous = null,
			string? anonymousFlag = null,
			string? flag = null,
			int duration = 30 * 60,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 群组全员禁言
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="enable">是否禁言</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns></returns>
		Task<APIResponse> MuteGroupAsync(
			ulong groupId,
			bool enable = true,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 群组设置管理员
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="userId">要设置管理员的 QQ 号</param>
		/// <param name="enable">true 为设置，false 为取消</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns></returns>
		Task<APIResponse> SetGroupAdminAsync(
			ulong groupId,
			ulong userId,
			bool enable = true,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 群组匿名
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="enable">是否允许匿名聊天</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns></returns>
		Task<APIResponse> SetGroupAnonymousAsync(
			ulong groupId,
			bool enable = true,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 设置群名片（群备注）
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="userId">要设置的 QQ 号</param>
		/// <param name="card">群名片内容，不填或空字符串表示删除群名片</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns></returns>
		Task<APIResponse> SetGroupMemberCardAsync(
			ulong groupId,
			ulong userId,
			string? card = null,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 设置群名
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="groupName">新群名</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns></returns>
		Task<APIResponse> SetGroupNameAsync(
			ulong groupId,
			string groupName,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 退出群组
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="isDismiss">是否解散，如果登录号是群主，则仅在此项为 true 时能够解散</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns></returns>
		Task<APIResponse> LeaveGroupAsync(
			ulong groupId,
			bool isDismiss = false,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 设置群组专属头衔
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="userId">要设置的 QQ 号</param>
		/// <param name="specialTitle">专属头衔，不填或空字符串表示删除专属头衔</param>
		/// <param name="duration">专属头衔有效期，单位秒，-1 表示永久，不过此项似乎没有效果，可能是只有某些特殊的时间长度有效，有待测试</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns></returns>
		Task<APIResponse> SetGroupMemberTitleAsync(
			ulong groupId,
			ulong userId,
			string? specialTitle = null,
			int duration = -1,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 处理加好友请求
		/// </summary>
		/// <param name="flag">加好友请求的 flag（需从上报的数据中获得）</param>
		/// <param name="approve">是否同意请求</param>
		/// <param name="remark">添加后的好友备注（仅在同意时有效）</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns></returns>
		Task<APIResponse> SetFriendAddRequestAsync(
			string flag,
			bool approve = true,
			string? remark = null,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 处理加群请求／邀请
		/// </summary>
		/// <param name="flag">加群请求的 flag（需从上报的数据中获得）</param>
		/// <param name="subType">add 或 invite，请求类型（需要和上报消息中的 sub_type 字段相符）</param>
		/// <param name="approve">是否同意请求／邀请</param>
		/// <param name="reason">拒绝理由（仅在拒绝时有效）</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns></returns>
		Task<APIResponse> SetGroupAddRequestAsync(
			string flag,
			GroupAddRequestEventType subType,
			bool approve = true,
			string? reason = null,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取登录号信息
		/// </summary>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>登录信息</returns>
		Task<APIResponse<LoginInfo>> GetLoginInfoAsync(
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取陌生人信息
		/// </summary>
		/// <param name="userId">QQ 号</param>
		/// <param name="noCache">是否不使用缓存（使用缓存可能更新不及时，但响应更快）</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>陌生人信息</returns>
		Task<APIResponse<StrangerInfo>> GetStrangerInfoAsync(
			ulong userId,
			bool noCache = false,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取好友列表
		/// </summary>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>好友信息列表</returns>
		Task<APIResponse<FriendInfo[]>> GetFriendListAsync(
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取群信息
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="noCache">是否不使用缓存（使用缓存可能更新不及时，但响应更快）</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>群信息</returns>
		Task<APIResponse<GroupInfo>> GetGroupInfoAsync(
			ulong groupId,
			bool noCache = false,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取群列表
		/// </summary>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>群信息列表</returns>
		Task<APIResponse<GroupInfo[]>> GetGroupListAsync(
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取群成员信息
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="userId">QQ 号</param>
		/// <param name="noCache">是否不使用缓存（使用缓存可能更新不及时，但响应更快）</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>群成员信息</returns>
		Task<APIResponse<GroupMemberInfo>> GetGroupMemberInfoAsync(
			ulong groupId,
			ulong userId,
			bool noCache = false,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取群成员列表<br/>
		/// 响应内容为 JSON 数组，每个元素的内容和上面的 get_group_member_info 接口相同，但对于同一个群组的同一个成员，获取列表时和获取单独的成员信息时，某些字段可能有所不同，例如 area、title 等字段在获取列表时无法获得，具体应以单独的成员信息为准。
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>群成员信息列表</returns>
		Task<APIResponse<GroupMemberInfo[]>> GetGroupMemberListAsync(
			ulong groupId,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取群荣誉信息
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="type">要获取的群荣誉类型</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>群荣誉信息</returns>
		Task<APIResponse<GroupHonorInfo>> GetGroupHonorInfoAsync(
			ulong groupId,
			GetGroupHonorInfoType type = GetGroupHonorInfoType.All,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取 Cookies
		/// </summary>
		/// <param name="domain">需要获取 cookies 的域名</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>Cookies 信息</returns>
		Task<APIResponse<CookiesInfo>> GetCookiesAsync(
			string domain,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取 CSRF Token
		/// </summary>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>CSRF Token 信息</returns>
		Task<APIResponse<CsrfTokenInfo>> GetCsrfTokenAsync(
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取 QQ 相关接口凭证
		/// </summary>
		/// <param name="domain">需要获取 cookies 的域名</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>凭证信息</returns>
		Task<APIResponse<CredentialsInfo>> GetCredentialsAsync(
			string domain,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取语音
		/// </summary>
		/// <param name="file">收到的语音文件名（消息段的 file 参数），如 0B38145AA44505000B38145AA4450500.silk</param>
		/// <param name="outFormat">要转换到的格式</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>语音信息</returns>
		Task<APIResponse<RecordInfo>> GetRecordAsync(
			string file,
			GetRecordFormatType outFormat,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取图片
		/// </summary>
		/// <param name="file">收到的图片文件名（消息段的 file 参数），如 6B4DE3DFD1BD271E3297859D41C530F5.jpg</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>图片信息</returns>
		Task<APIResponse<ImageInfo>> GetImageAsync(
			string file,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 检查是否可以发送图片
		/// </summary>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>是否信息</returns>
		Task<APIResponse<YesInfo>> CanSendImageAsync(
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 检查是否可以发送语音
		/// </summary>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>是否信息</returns>
		Task<APIResponse<YesInfo>> CanSendRecordAsync(
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取运行状态
		/// </summary>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>状态信息</returns>
		Task<APIResponse<StatusInfo>> GetStatusAsync(
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取版本信息
		/// </summary>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>版本信息</returns>
		Task<APIResponse<VersionInfo>> GetVersionInfoAsync(
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 重启 OneBot 实现
		/// </summary>
		/// <param name="delay">要延迟的毫秒数，如果默认情况下无法重启，可以尝试设置延迟为 2000 左右</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns></returns>
		Task<APIResponse> RestartAsync(
			long delay = 0,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 上传图片
		/// </summary>
		/// <param name="file">
		/// 图片文件<br/>
		/// file 参数除了支持使用收到的图片文件名直接发送外，还支持：<br/>
		/// - 绝对路径，例如 file:///C:\\Users\Richard\Pictures\1.png，格式使用 <a href="https://tools.ietf.org/html/rfc8089">file URI</a><br/>
		/// - 网络 URL，例如 http://i1.piimg.com/567571/fdd6e7b6d93f1ef0.jpg<br/>
		/// - Base64 编码，例如 base64://iVBORw0KGgoAAAANSUhEUgAAABQAAAAVCAIAAADJt1n/AAAAKElEQVQ4EWPk5+RmIBcwkasRpG9UM4mhNxpgowFGMARGEwnBIEJVAAAdBgBNAZf+QAAAAABJRU5ErkJggg==
		/// </param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>图片链接</returns>
		Task<APIResponse<string>> UploadImageAsync(
			string file,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 上传群文件
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="file">文件路径</param>
		/// <param name="name">名称</param>
		/// <param name="folder">文件夹</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns></returns>
		Task<APIResponse> UploadGroupFileAsync(
			ulong groupId,
			string file,
			string? name = null,
			string? folder = null,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取群文件信息
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="folderId">文件夹 ID ，留空表示根文件夹</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>群文件信息</returns>
		Task<APIResponse<GroupFilesInfo>> GetGroupFilesByFolderAsync(
			ulong groupId,
			string? folderId = null,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取群根文件夹文件信息
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>群文件信息</returns>
		Task<APIResponse<GroupFilesInfo>> GetGroupRootFilesAsync(
			ulong groupId,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取群文件 URL
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="fileId">文件 ID</param>
		/// <param name="busId">BusId</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>链接信息</returns>
		Task<APIResponse<UrlInfo>> GetGroupFileUrlAsync(
			ulong groupId,
			string fileId,
			uint busId,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 移动群文件
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="fileId">文件 ID</param>
		/// <param name="parentDirectory">原文件夹</param>
		/// <param name="targetDirectory">目标文件夹</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>群文件系统操作信息</returns>
		Task<APIResponse<GroupFileSystemOperationInfo>> MoveGroupFileAsync(
			ulong groupId,
			string fileId,
			string parentDirectory,
			string targetDirectory,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 删除群文件
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="fileId">文件 ID</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>群文件系统操作信息</returns>
		Task<APIResponse<GroupFileSystemOperationInfo>> DeleteGroupFileAsync(
			ulong groupId,
			string fileId,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 创建群文件夹
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="name">文件夹名称</param>
		/// <param name="parentId">父级文件夹 ID</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>群文件系统操作信息</returns>
		Task<APIResponse<GroupFileSystemOperationInfo>> CreateGroupFolderAsync(
			ulong groupId,
			string name,
			string parentId = "",
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 删除群文件夹
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="folderId">文件夹 ID</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>群文件系统操作信息</returns>
		Task<APIResponse<GroupFileSystemOperationInfo>> DeleteGroupFolderAsync(
			ulong groupId,
			string folderId,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 重命名群文件夹
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="folderId">文件夹 ID</param>
		/// <param name="newFolderName">新文件夹名称</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>群文件系统操作信息</returns>
		Task<APIResponse<GroupFileSystemOperationInfo>> RenameGroupFolderAsync(
			ulong groupId,
			string folderId,
			string newFolderName,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 上传私聊文件
		/// </summary>
		/// <param name="userId">QQ</param>
		/// <param name="file">文件路径</param>
		/// <param name="name">名称</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>上传私聊文件异步任务</returns>
		Task<APIResponse> UploadPrivateFileAsync(
			ulong userId,
			string file,
			string? name = null,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取自定义表情包
		/// </summary>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>表情包链接列表</returns>
		Task<APIResponse<string[]>> FetchCustomFaceAsync(
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 设置 QQ 头像
		/// </summary>
		/// <param name="file">
		/// file 参数除了支持使用收到的图片文件名直接发送外，还支持：<br/>
		/// - 绝对路径，例如 file:///C:\\Users\Richard\Pictures\1.png，格式使用 <a href="https://tools.ietf.org/html/rfc8089">file URI</a><br/>
		/// - 网络 URL，例如 http://i1.piimg.com/567571/fdd6e7b6d93f1ef0.jpg<br/>
		/// - Base64 编码，例如 base64://iVBORw0KGgoAAAANSUhEUgAAABQAAAAVCAIAAADJt1n/AAAAKElEQVQ4EWPk5+RmIBcwkasRpG9UM4mhNxpgowFGMARGEwnBIEJVAAAdBgBNAZf+QAAAAABJRU5ErkJggg==
		/// </param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns></returns>
		Task<APIResponse> SetQQAvatarAsync(
			string file,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 删除群公告
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="noticeId">公告 ID</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns></returns>
		Task<APIResponse> DeleteGroupNoticeAsync(
			ulong groupId,
			string noticeId,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取群公告
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>群公告信息列表</returns>
		Task<APIResponse<GroupNoticeInfo[]>> GetGroupNoticeAsync(
			ulong groupId,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 设置群聊机器人
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="botId">机器人 ID</param>
		/// <param name="enable">是否启用</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>机器人 ID</returns>
		Task<APIResponse<ulong>> SetGroupBotAsync(
			ulong groupId,
			ulong botId,
			uint enable,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 发送群聊机器人回调
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="botId">机器人 ID</param>
		/// <param name="data_1">参数1</param>
		/// <param name="data_2">参数2</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>机器人 ID</returns>
		Task<APIResponse<ulong>> SendGroupBotCallbackAsync(
			ulong groupId,
			ulong botId,
			string? data_1 = null,
			string? data_2 = null,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 创建群公告
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="content">内容</param>
		/// <param name="image">图片</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>公告 ID</returns>
		Task<APIResponse<string>> CreateGroupNoticeAsync(
			ulong groupId,
			string content,
			string? image = null,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 设置群头像
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="file">
		/// file 参数除了支持使用收到的图片文件名直接发送外，还支持：<br/>
		/// - 绝对路径，例如 file:///C:\\Users\Richard\Pictures\1.png，格式使用 <a href="https://tools.ietf.org/html/rfc8089">file URI</a><br/>
		/// - 网络 URL，例如 http://i1.piimg.com/567571/fdd6e7b6d93f1ef0.jpg<br/>
		/// - Base64 编码，例如 base64://iVBORw0KGgoAAAANSUhEUgAAABQAAAAVCAIAAADJt1n/AAAAKElEQVQ4EWPk5+RmIBcwkasRpG9UM4mhNxpgowFGMARGEwnBIEJVAAAdBgBNAZf+QAAAAABJRU5ErkJggg==
		/// </param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns></returns>
		Task<APIResponse> SetGroupPortraitAsync(
			ulong groupId,
			string file,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 删除精华消息
		/// </summary>
		/// <param name="messageId">消息 ID</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns></returns>
		Task<APIResponse> DeleteEssenceMessageAsync(
			long messageId,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 好友戳一戳
		/// </summary>
		/// <param name="userId">用户 ID</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns></returns>
		Task<APIResponse> PokeFriendAsync(
			ulong userId,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取群精华消息列表
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>精华消息列表</returns>
		Task<APIResponse<EssenceMessageSegment[]>> GetGroupEssenceMessageListAsync(
			ulong groupId,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取好友消息历史记录
		/// </summary>
		/// <param name="userId">用户 ID</param>
		/// <param name="messageId">基准消息 ID</param>
		/// <param name="count">消息数量</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>好友消息信息</returns>
		Task<APIResponse<PrivateMessagesInfo>> GetFriendMessageHistoryAsync(
			ulong userId,
			long messageId,
			uint count,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取群聊消息历史记录
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="messageId">基准消息 ID</param>
		/// <param name="count">消息数量</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>群聊消息信息</returns>
		Task<APIResponse<GroupMessagesInfo>> GetGroupMessageHistoryAsync(
			ulong groupId,
			long messageId,
			uint count,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 获取音乐 Ark
		/// </summary>
		/// <param name="title">标题</param>
		/// <param name="desc">简介</param>
		/// <param name="jumpUrl">跳转链接</param>
		/// <param name="musicUrl">音乐链接</param>
		/// <param name="sourceIcon">图标源</param>
		/// <param name="tag">标签</param>
		/// <param name="preview">预览</param>
		/// <param name="sourceMsgId">源消息 ID</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>音乐 Ark</returns>
		Task<APIResponse<string>> GetMusicArkAsync(
			string title = "",
			string desc = "",
			string jumpUrl = "",
			string musicUrl = "",
			string sourceIcon = "",
			string tag = "",
			string preview = "",
			string sourceMsgId = "",
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 群聊戳一戳
		/// </summary>
		/// <param name="userId">用户 ID</param>
		/// <param name="groupId">群号</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns></returns>
		Task<APIResponse> PokeGroupMemberAsync(
			ulong userId,
			ulong groupId,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 标记消息已读
		/// </summary>
		/// <param name="messageId">消息 ID</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns></returns>
		Task<APIResponse> MarkMessageAsReadAsync(
			long messageId,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 发送转发消息
		/// </summary>
		/// <param name="messages">转发消息</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>转发消息 ID</returns>
		Task<APIResponse<string>> SendForwardMessageAsync(
			Message messages,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 发送群聊转发消息
		/// </summary>
		/// <param name="groupId">群号</param>
		/// <param name="messages">转发消息</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>转发消息 ID</returns>
		Task<APIResponse<string>> SendGroupForwardMessageAsync(
			ulong groupId,
			Message messages,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 发送消息
		/// </summary>
		/// <param name="messageType">消息类型</param>
		/// <param name="message">要发送的内容</param>
		/// <param name="userId">对方 QQ 号（消息类型为 <see cref="MessageEventType.Private"/> 时需要）</param>
		/// <param name="groupId">群号（消息类型为 <see cref="MessageEventType.Group"/> 时需要）</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>消息 ID 信息</returns>
		Task<APIResponse<MessageIdInfo>> SendMessageAsync(
			MessageEventType messageType,
			Message message,
			ulong userId = 0,
			ulong groupId = 0,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 发送私聊转发消息
		/// </summary>
		/// <param name="userId">用户 ID</param>
		/// <param name="messages">转发消息</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns>转发消息 ID</returns>
		Task<APIResponse<string>> SendPrivateForwardMessageAsync(
			ulong userId,
			Message messages,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// 设置精华消息
		/// </summary>
		/// <param name="messageId">消息 ID</param>
		/// <param name="cancellationToken">取消令牌</param>
		/// <returns></returns>
		Task<APIResponse> SetEssenceMessageAsync(
			long messageId,
			CancellationToken cancellationToken = default
			);
	}
}
