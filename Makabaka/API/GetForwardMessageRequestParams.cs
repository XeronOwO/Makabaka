namespace Makabaka.API
{
	/// <summary>
	/// 获取转发消息请求参数
	/// </summary>
	/// <param name="id">合并转发 ID</param>
	public class GetForwardMessageRequestParams(string id)
	{
		/// <summary>
		/// 合并转发 ID
		/// </summary>
		public string Id { get; set; } = id;
	}
}
