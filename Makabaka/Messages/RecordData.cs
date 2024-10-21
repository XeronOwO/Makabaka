namespace Makabaka.Messages
{
	/// <summary>
	/// 语音数据
	/// </summary>
	public class RecordData
	{
		/// <summary>
		/// 语音文件<br/>
		/// ✔ 收<br/>
		/// ✔ 发[1]<br/><br/>
		/// [1] 发送时，file 参数除了支持使用收到的语音文件名直接发送外，还支持其它形式，参考 <see cref="ImageData.File"/>。
		/// </summary>
		public string File { get; set; } = string.Empty;

		/// <summary>
		/// 语音 URL<br/>
		/// ✔ 收<br/>
		/// ✘ 发
		/// </summary>
		public string Url { get; set; } = string.Empty;
	}
}
