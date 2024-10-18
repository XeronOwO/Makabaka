namespace Makabaka.API
{
	/// <summary>
	/// 获取商城表情密钥请求参数
	/// </summary>
	/// <param name="emojiIds">表情 ID</param>
	public class FetchMarketFaceKeyRequestParams(string[] emojiIds)
	{
		/// <summary>
		/// 表情 ID
		/// </summary>
		public string[] EmojiIds { get; set; } = emojiIds;
	}
}
