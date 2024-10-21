using Makabaka.Utils;

namespace Makabaka.Messages
{
	/// <summary>
	/// 合并转发段消息
	/// </summary>
	/// <param name="id">
	/// 合并转发 ID，需通过 <a href="https://github.com/botuniverse/onebot-11/blob/master/api/public.md#get_forward_msg-%E8%8E%B7%E5%8F%96%E5%90%88%E5%B9%B6%E8%BD%AC%E5%8F%91%E6%B6%88%E6%81%AF">get_forward_msg API</a> 获取具体内容<br/>
	/// ✔ 收<br/>
	/// ✔ 发
	/// </param>
	[Segment(SegmentType.Forward)]
	public class ForwardSegment(
		string id
		) : Segment<ForwardData>(
			SegmentType.Forward.ToSerializedString(),
			new ForwardData
			{
				Id = id
			})
	{
		/// <summary>
		/// 反序列化保留，请使用其它构造函数
		/// </summary>
		public ForwardSegment() : this(string.Empty)
		{
		}
	}
}
