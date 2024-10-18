namespace Makabaka.Messages
{
	/// <summary>
	/// 合并转发节点数据
	/// </summary>
	public class NodeData
	{
		/// <summary>
		/// (合并转发节点) 转发的消息 ID<br/>
		/// ✘ 收<br/>
		/// ✔ 发
		/// </summary>
		public string? Id { get; set; }

		/// <summary>
		/// (合并转发自定义节点) 发送者 QQ 号<br/>
		/// ✔ 收<br/>
		/// ✔ 发
		/// </summary>
		public string? UserId { get; set; }

		/// <summary>
		/// (合并转发自定义节点) 发送者昵称<br/>
		/// ✔ 收<br/>
		/// ✔ 发
		/// </summary>
		public string? Nickname { get; set; }

		/// <summary>
		/// (合并转发自定义节点) 消息内容，支持发送消息时的 message 数据类型，见 <a href="https://github.com/botuniverse/onebot-11/blob/master/api/#%E5%8F%82%E6%95%B0">API 的参数</a><br/>
		/// ✔ 收<br/>
		/// ✔ 发
		/// </summary>
		public Message? Content { get; set; }
	}
}
