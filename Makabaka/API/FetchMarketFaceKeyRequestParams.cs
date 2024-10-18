namespace Makabaka.API
{
	/// <summary>
	/// 获取商城表情密钥请求参数
	/// </summary>
	/// <param name="EmojiIds">表情 ID</param>
	public record class FetchMarketFaceKeyRequestParams(string[] EmojiIds)
	{
	}
}
