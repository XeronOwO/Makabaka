namespace Makabaka.Messages
{
	/// <summary>
	/// 回复数据
	/// </summary>
	public class ReplyData
	{
		/// <summary>
		/// 回复时引用的消息 ID<br/>
		/// ✔ 收<br/>
		/// ✔ 发
		/// </summary>
		public string Id { get; set; } = string.Empty;
	}
}
