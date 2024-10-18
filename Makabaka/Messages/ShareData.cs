namespace Makabaka.Messages
{
	/// <summary>
	/// 链接分享数据
	/// </summary>
	public class ShareData
	{
		/// <summary>
		/// URL<br/>
		/// ✔ 收<br/>
		/// ✔ 发
		/// </summary>
		public string Url { get; set; } = string.Empty;

		/// <summary>
		/// 标题<br/>
		/// ✔ 收<br/>
		/// ✔ 发
		/// </summary>
		public string Title { get; set; } = string.Empty;

		/// <summary>
		/// 发送时可选，内容描述<br/>
		/// ✔ 收<br/>
		/// ✔ 发
		/// </summary>
		public string? Content { get; set; }

		/// <summary>
		/// 发送时可选，图片 URL<br/>
		/// ✔ 收<br/>
		/// ✔ 发
		/// </summary>
		public string? Image { get; set; }
	}
}
