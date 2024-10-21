namespace Makabaka.Messages
{
	/// <summary>
	/// 短视频数据
	/// </summary>
	public class VideoData
	{
		/// <summary>
		/// 视频文件名<br/>
		/// ✔ 收<br/>
		/// ✔ 发[1]<br/><br/>
		/// [1] 发送时，file 参数除了支持使用收到的视频文件名直接发送外，还支持其它形式，参考 <see cref="ImageData.File"/>。
		/// </summary>
		public string File { get; set; } = string.Empty;

		/// <summary>
		/// 视频 URL<br/>
		/// ✔ 收<br/>
		/// ✘ 发
		/// </summary>
		public string Url { get; set; } = string.Empty;
	}
}
