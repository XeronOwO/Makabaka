using Makabaka.Utils;

namespace Makabaka.Messages
{
	/// <summary>
	/// 短视频段消息
	/// </summary>
	/// <param name="file">
	/// 视频文件名<br/>
	/// ✔ 收<br/>
	/// ✔ 发[1]<br/><br/>
	/// [1] 发送时，file 参数除了支持使用收到的视频文件名直接发送外，还支持其它形式，参考 <see cref="ImageData.File"/>。
	/// </param>
	/// <param name="cache">
	/// 只在通过网络 URL 发送时有效，表示是否使用已缓存的文件，默认 1<br/>
	/// 0：不使用已缓存的文件<br/>
	/// 1：使用已缓存的文件<br/>
	/// ✘ 收<br/>
	/// ✔ 发
	/// </param>
	/// <param name="proxy">
	/// 只在通过网络 URL 发送时有效，表示是否通过代理下载文件（需通过环境变量或配置文件配置代理），默认 1<br/>
	/// 0：不通过代理下载文件<br/>
	/// 1：通过代理下载文件<br/>
	/// ✘ 收<br/>
	/// ✔ 发
	/// </param>
	/// <param name="timeout">
	/// 只在通过网络 URL 发送时有效，单位秒，表示下载网络文件的超时时间，默认不超时<br/>
	/// ✘ 收<br/>
	/// ✔ 发
	/// </param>
	[Segment(SegmentType.Video)]
	public class VideoSegment(
		string file,
		int? cache = null,
		int? proxy = null,
		int? timeout = null
		) : Segment<VideoData>(
			SegmentType.Video.ToSerializedString(),
			new()
			{
				File = file,
				Cache = cache,
				Proxy = proxy,
				Timeout = timeout,
			})
	{
		/// <summary>
		/// 反序列化保留，请使用其它构造函数
		/// </summary>
		public VideoSegment() : this(string.Empty)
		{
		}

		/// <inheritdoc/>
		public override string ToString()
		{
			return $"[CQ:{Type},file={CqCode.Escape(Data.File)}]";
		}
	}
}
