namespace Makabaka.Events
{
	/// <summary>
	/// 请求事件参数
	/// </summary>
	public class RequestEventArgs : PostEventArgs
	{
		/// <summary>
		/// 请求类型
		/// </summary>
		public RequestEventType RequestType { get; set; }
	}
}
