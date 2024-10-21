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
	[Segment(SegmentType.Record)]
	public class RecordSegment(
		string file
		) : Segment<RecordData>(
			SegmentType.Record.ToSerializedString(),
			new()
			{
				File = file,
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
