namespace Makabaka.Messages
{
	/// <summary>
	/// 商城表情数据
	/// </summary>
	public class MarketFaceData
	{
		/// <summary>
		/// URL
		/// </summary>
		public string Url { get; set; } = string.Empty;

		/// <summary>
		/// 表情包 ID
		/// </summary>
		public ulong EmojiPackageId { get; set; }

		/// <summary>
		/// 表情 ID
		/// </summary>
		public string EmojiId { get; set; } = string.Empty;

		/// <summary>
		/// 密钥<br/>
		/// 请使用 <see cref="IBotContext.FetchMarketFaceKeyAsync(string[], System.Threading.CancellationToken)"/> 获取
		/// </summary>
		public string Key { get; set; } = string.Empty;

		/// <summary>
		/// 简介
		/// </summary>
		public string Summary { get; set; } = string.Empty;
	}
}
