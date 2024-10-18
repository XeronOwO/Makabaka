namespace Makabaka.API
{
	/// <summary>
	/// 消息 ID 请求参数
	/// </summary>
	/// <param name="messageId">消息 ID</param>
	public class MessageIdRequestParams(long messageId)
	{
		/// <summary>
		/// 消息 ID
		/// </summary>
		public long MessageId { get; set; } = messageId;
	}
}
