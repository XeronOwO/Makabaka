using Makabaka.Utils;

namespace Makabaka.Messages
{
	/// <summary>
	/// 商城表情段消息
	/// </summary>
	/// <param name="url">URL</param>
	/// <param name="emojiPackageId">表情包 ID</param>
	/// <param name="emojiId">表情 ID</param>
	/// <param name="key">
	/// 密钥<br/>
	/// 请使用 <see cref="IBotContext.FetchMarketFaceKeyAsync(string[], System.Threading.CancellationToken)"/> 获取
	/// </param>
	/// <param name="summary">简介</param>
	[Segment(SegmentType.MarketFace)]
	public class MarketFaceSegment(
		string url,
		ulong emojiPackageId,
		string emojiId,
		string key,
		string summary = "[动画表情]"
		) : Segment<MarketFaceData>(
			SegmentType.MarketFace.ToSerializedString(),
			new()
			{
				Url = url,
				EmojiPackageId = emojiPackageId,
				EmojiId = emojiId,
				Key = key,
				Summary = summary,
			})
	{
		/// <summary>
		/// 反序列化保留，请使用其它构造函数
		/// </summary>
		public MarketFaceSegment() : this(string.Empty, 0, string.Empty, string.Empty)
		{
		}
	}
}
