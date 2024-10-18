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

		/// <summary>
		/// 只在通过网络 URL 发送时有效，表示是否使用已缓存的文件，默认 1<br/>
		/// 0：不使用已缓存的文件<br/>
		/// 1：使用已缓存的文件<br/>
		/// ✘ 收<br/>
		/// ✔ 发
		/// </summary>
		public int? Cache { get; set; }

		/// <summary>
		/// 只在通过网络 URL 发送时有效，表示是否通过代理下载文件（需通过环境变量或配置文件配置代理），默认 1<br/>
		/// 0：不通过代理下载文件<br/>
		/// 1：通过代理下载文件<br/>
		/// ✘ 收<br/>
		/// ✔ 发
		/// </summary>
		public int? Proxy { get; set; }

		/// <summary>
		/// 只在通过网络 URL 发送时有效，单位秒，表示下载网络文件的超时时间，默认不超时<br/>
		/// ✘ 收<br/>
		/// ✔ 发
		/// </summary>
		public int? Timeout { get; set; }
	}
}
