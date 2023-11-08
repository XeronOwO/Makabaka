using Makabaka.Models.EventArgs;
using Makabaka.Models.FastActions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Makabaka.Services
{
	/// <summary>
	/// 被动服务接口，提供纯被动的服务，例如事件回调
	/// </summary>
	public interface IPassiveService
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

		#region 事件

		/// <summary>
		/// <a href="https://github.com/botuniverse/onebot-11/blob/master/event/meta.md#%E7%94%9F%E5%91%BD%E5%91%A8%E6%9C%9F">生命周期</a>事件
		/// </summary>
		event FastActionEventHandler<LifeCycleEventArgs> OnLifeCycle;

		internal Task<IFastAction> SendLifeCycleEvent(LifeCycleEventArgs e);

		/// <summary>
		/// <a href="https://github.com/botuniverse/onebot-11/blob/master/event/meta.md#%E5%BF%83%E8%B7%B3">心跳</a>事件
		/// </summary>
		event FastActionEventHandler<HeartbeatEventArgs> OnHeartbeat;

		internal Task<IFastAction> SendHeartbeatEvent(HeartbeatEventArgs e);

		/// <summary>
		/// <a href="https://github.com/botuniverse/onebot-11/blob/master/event/message.md#%E7%BE%A4%E6%B6%88%E6%81%AF">群消息</a>事件
		/// </summary>
		event FastActionEventHandler<GroupMessageEventArgs> OnGroupMessage;

		internal Task<IFastAction> SendGroupMessageEvent(GroupMessageEventArgs e);

		/// <summary>
		/// <a href="https://github.com/botuniverse/onebot-11/blob/master/event/request.md#%E5%8A%A0%E5%A5%BD%E5%8F%8B%E8%AF%B7%E6%B1%82">加好友请求</a>事件
		/// </summary>
		event FastActionEventHandler<AddFriendRequestEventArgs> OnAddFriendRequest;

		internal Task<IFastAction> SendAddFriendRequestEvent(AddFriendRequestEventArgs e);

		#endregion
	}
}
