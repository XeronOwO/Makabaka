using Makabaka.Models.Messages;
using Newtonsoft.Json;

namespace Makabaka.Models.API.Responses
{
	/// <summary>
	/// 私聊消息
	/// </summary>
	public class PrivateMessage
	{
		/// <summary>
		/// 消息类型
		/// </summary>
		[JsonProperty("message_type")]
		public string MessageType { get; set; }

		/// <summary>
		/// 子类型
		/// </summary>
		[JsonProperty("sub_type")]
		public string SubType { get; set; }

		/// <summary>
		/// 消息Id
		/// </summary>
		[JsonProperty("message_id")]
		public long MessageId { get; set; }

		/// <summary>
		/// 用户ID
		/// </summary>
		[JsonProperty("user_id")]
		public long UserId { get; set; }

		/// <summary>
		/// 消息
		/// </summary>
		[JsonProperty("message")]
		public Message Message { get; set; }
	}
}
