using Makabaka.Models.API.Responses;
using Makabaka.Models.EventArgs;
using Makabaka.Network;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Makabaka.Services
{
	/// <summary>
	/// 服务接口，提供服务的基本控制，以及事件回调
	/// </summary>
	public interface IService
	{
		#region 基本功能

		/// <summary>
		/// 启动服务
		/// </summary>
		/// <returns>任务</returns>
		Task StartAsync();

		/// <summary>
		/// 等待服务停止
		/// </summary>
		/// <returns>任务</returns>
		Task WaitAsync();

		/// <summary>
		/// 停止服务
		/// </summary>
		/// <returns>任务</returns>
		Task StopAsync();

		#endregion

		#region 属性

		/// <summary>
		/// 获取服务中所有有效的会话
		/// </summary>
		List<ISession> Sessions { get; }

		#endregion

		#region 事件

		/// <summary>
		/// <a href="https://github.com/botuniverse/onebot-11/blob/master/event/meta.md#%E7%94%9F%E5%91%BD%E5%91%A8%E6%9C%9F">生命周期</a>事件
		/// </summary>
		event EventHandler<LifeCycleEventArgs> OnLifeCycle;

		internal void SendLifeCycleEvent(LifeCycleEventArgs e);

		/// <summary>
		/// <a href="https://github.com/botuniverse/onebot-11/blob/master/event/meta.md#%E5%BF%83%E8%B7%B3">心跳</a>事件
		/// </summary>
		event EventHandler<HeartbeatEventArgs> OnHeartbeat;

		internal void SendHeartbeatEvent(HeartbeatEventArgs e);

		/// <summary>
		/// <a href="https://github.com/botuniverse/onebot-11/blob/master/event/message.md#%E7%BE%A4%E6%B6%88%E6%81%AF">群消息</a>事件
		/// </summary>
		event EventHandler<GroupMessageEventArgs> OnGroupMessage;

		internal void SendGroupMessageEvent(GroupMessageEventArgs e);

		/// <summary>
		/// <a href="https://github.com/botuniverse/onebot-11/blob/master/event/request.md#%E5%8A%A0%E5%A5%BD%E5%8F%8B%E8%AF%B7%E6%B1%82">加好友请求</a>事件
		/// </summary>
		event EventHandler<AddFriendRequestEventArgs> OnAddFriendRequest;

		internal void SendAddFriendRequestEvent(AddFriendRequestEventArgs e);

		/// <summary>
		/// <a href="https://github.com/botuniverse/onebot-11/blob/master/event/notice.md#%E7%BE%A4%E7%AE%A1%E7%90%86%E5%91%98%E5%8F%98%E5%8A%A8">群管理员变动</a>事件
		/// </summary>
		event EventHandler<GroupAdminChangedEventArgs> OnGroupAdminChanged;

		internal void SendGroupAdminChangedEvent(GroupAdminChangedEventArgs e);

		/// <summary>
		/// <a href="https://github.com/botuniverse/onebot-11/blob/master/event/notice.md#%E7%BE%A4%E6%88%90%E5%91%98%E5%87%8F%E5%B0%91">群成员减少</a>事件
		/// </summary>
		event EventHandler<GroupMemberDecreaseEventArgs> OnGroupMemberDecrease;

		internal void SendGroupMemberDecreaseEvent(GroupMemberDecreaseEventArgs e);

		/// <summary>
		/// <a href="https://github.com/botuniverse/onebot-11/blob/master/event/notice.md#%E7%BE%A4%E6%88%90%E5%91%98%E5%A2%9E%E5%8A%A0">群成员增加</a>事件
		/// </summary>
		event EventHandler<GroupMemberIncreaseEventArgs> OnGroupMemberIncrease;

		internal void SendGroupMemberIncreaseEvent(GroupMemberIncreaseEventArgs e);

		#endregion
	}
}
