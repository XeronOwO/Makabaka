using Makabaka.Events;

namespace Makabaka.Models
{
	/// <summary>
	/// 群聊消息信息
	/// </summary>
	public class GroupMessagesInfo
	{
		/// <summary>
		/// 消息列表
		/// </summary>
		public GroupMessageEventArgs[] Messages { get; set; } = [];
	}
}
