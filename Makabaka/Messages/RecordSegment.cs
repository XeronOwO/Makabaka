using Makabaka.Utils;

namespace Makabaka.Messages
{
	/// <summary>
	/// 语音片消息
	/// </summary>
	/// <param name="file">
	/// 语音文件<br/>
	/// ✔ 收<br/>
	/// ✔ 发[1]<br/><br/>
	/// [1] 发送时，file 参数除了支持使用收到的语音文件名直接发送外，还支持其它形式，参考 <see cref="ImageData.File"/>。
	/// </param>
	/// <param name="magic">
	/// 发送时可选，默认 0，设置为 1 表示变声<br/>
	/// 0：正常<br/>
	/// 1：变声<br/>
	/// ✔ 收<br/>
	/// ✔ 发
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
	/// 只在通过网络 URL 发送时有效，表示是否通过代理下载文件（需通过环境变量或配置文件配置代理），默认 1<br/>
	/// 0：不通过代理下载文件<br/>
	/// 1：通过代理下载文件<br/>
	/// ✘ 收<br/>
	/// ✔ 发
	/// </param>
	[Segment(SegmentType.Record)]
	public class RecordSegment(
		string file,
		int? magic = null,
		int? cache = null,
		int? proxy = null,
		int? timeout = null
		) : Segment<RecordData>(
			SegmentType.Record.ToSerializedString(),
			new()
			{
				File = file,
				Magic = magic,
				Cache = cache,
				Proxy = proxy,
				Timeout = timeout,
			})
	{
		/// <summary>
		/// 反序列化保留，请使用其它构造函数
		/// </summary>
		public RecordSegment() : this(string.Empty)
		{
		}

		/// <inheritdoc/>
		public override string ToString()
		{
			return $"[CQ:{Type},file={CqCode.Escape(Data.File)}]";
		}
	}
}
