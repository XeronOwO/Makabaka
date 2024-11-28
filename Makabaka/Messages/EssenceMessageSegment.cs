using System;

namespace Makabaka.Messages
{
	/// <summary>
	/// 精华消息片段
	/// </summary>
	public class EssenceMessageSegment
	{
		/// <summary>
		/// 发送者 ID
		/// </summary>
		public ulong SenderId { get; set; }

		/// <summary>
		/// 发送者昵称
		/// </summary>
		public string SenderNick { get; set; } = string.Empty;

		/// <summary>
		/// 发送时间
		/// </summary>
		public DateTime SenderTime { get; set; }

		/// <summary>
		/// 操作者 ID
		/// </summary>
		public ulong OperatorId { get; set; }

		/// <summary>
		/// 操作者昵称
		/// </summary>
		public string OperatorNick { get; set; } = string.Empty;

		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime OperatorTime { get; set; }

		/// <summary>
		/// 消息 ID
		/// </summary>
		public ulong MessageId { get; set; }

		/// <summary>
		/// 内容
		/// </summary>
		public Message Content { get; set; } = [];
	}
}
