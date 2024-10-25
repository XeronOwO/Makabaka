using Makabaka.Events;

namespace Makabaka.Models
{
	/// <summary>
	/// 私聊消息信息
	/// </summary>
	public class PrivateMessagesInfo
	{
		/// <summary>
		/// 消息列表
		/// </summary>
		public PrivateMessageEventArgs[] Messages { get; set; } = [];
	}
}
