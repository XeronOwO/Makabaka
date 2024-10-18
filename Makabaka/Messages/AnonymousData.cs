namespace Makabaka.Messages
{
	/// <summary>
	/// 匿名发消息数据
	/// </summary>
	public class AnonymousData
	{
		/// <summary>
		/// 可选，表示无法匿名时是否继续发送<br/>
		/// 0：不继续发送<br/>
		/// 1：继续发送<br/>
		/// ✘ 收<br/>
		/// ✔ 发<br/><br/>
		/// 当收到匿名消息时，需要通过 <see cref="Events.GroupMessageEventArgs.Anonymous"/> 字段判断。
		/// </summary>
		public int? Ignore { get; set; }
	}
}
