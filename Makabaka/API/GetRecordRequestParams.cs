namespace Makabaka.API
{
	/// <summary>
	/// 获取语音
	/// </summary>
	/// <param name="File">收到的语音文件名（消息段的 file 参数），如 0B38145AA44505000B38145AA4450500.silk</param>
	/// <param name="OutFormat">要转换到的格式</param>
	public record class GetRecordRequestParams(
		string File,
		GetRecordFormatType OutFormat
		)
	{
	}
}
