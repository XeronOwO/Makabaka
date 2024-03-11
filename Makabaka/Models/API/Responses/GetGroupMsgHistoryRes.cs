using Newtonsoft.Json;
using System.Collections.Generic;

namespace Makabaka.Models.API.Responses
{
	/// <summary>
	/// 获取群组历史消息记录结果
	/// </summary>
	public class GetGroupMsgHistoryRes
	{
		/// <summary>
		/// 群组消息列表
		/// </summary>
		[JsonProperty("messages")]
		public List<GroupMessage> Messages { get; set; }
	}
}
