using Newtonsoft.Json;
using System.Collections.Generic;

namespace Makabaka.Models.API.Responses
{
	/// <summary>
	/// 获取好友历史消息记录结果
	/// </summary>
	public class GetFriendMsgHistoryRes
	{
		/// <summary>
		/// 私聊消息列表
		/// </summary>
		[JsonProperty("messages")]
		public List<PrivateMessage> Messages { get; set; }
	}
}
