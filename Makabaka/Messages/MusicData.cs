namespace Makabaka.Messages
{
	/// <summary>
	/// 音乐分享
	/// </summary>
	public class MusicData
	{
		/// <summary>
		/// 音乐类型<br/>
		/// ✔ 收<br/>
		/// ✔ 发
		/// </summary>
		public MusicType Type { get; set; }

		/// <summary>
		/// (<see cref="Type"/> != "custom") 歌曲 ID<br/>
		/// ✔ 收<br/>
		/// ✔ 发
		/// </summary>
		public string Id { get; set; } = string.Empty;

		/// <summary>
		/// (<see cref="Type"/> == "custom") 点击后跳转目标 URL<br/>
		/// ✘ 收<br/>
		/// ✔ 发
		/// </summary>
		public string Url { get; set; } = string.Empty;

		/// <summary>
		/// (<see cref="Type"/> == "custom") 音乐 URL<br/>
		/// ✘ 收<br/>
		/// ✔ 发
		/// </summary>
		public string Audio { get; set; } = string.Empty;

		/// <summary>
		/// (<see cref="Type"/> == "custom") 标题<br/>
		/// ✘ 收<br/>
		/// ✔ 发
		/// </summary>
		public string Title { get; set; } = string.Empty;

		/// <summary>
		/// (<see cref="Type"/> == "custom") 发送时可选，内容描述<br/>
		/// ✘ 收<br/>
		/// ✔ 发
		/// </summary>
		public string? Content { get; set; }

		/// <summary>
		/// (<see cref="Type"/> == "custom") 发送时可选，图片 URL<br/>
		/// ✘ 收<br/>
		/// ✔ 发
		/// </summary>
		public string? Image { get; set; }
	}
}
