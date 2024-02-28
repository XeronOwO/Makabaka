using Makabaka.Models.API.Responses;
using Makabaka.Models.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Makabaka.Models.EventArgs
{
	/// <summary>
	/// 回复消息接口
	/// </summary>
	public interface IReply
	{
		/// <summary>
		/// 回复消息
		/// </summary>
		/// <param name="message">要发送的消息</param>
		/// <returns>消息ID信息响应</returns>
		Task<APIResponse<MessageIdRes>> ReplyAsync(Message message);
	}
}
