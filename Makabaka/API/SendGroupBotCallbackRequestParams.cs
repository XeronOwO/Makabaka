namespace Makabaka.API
{
	/// <summary>
	/// 发送群聊机器人回调请求参数
	/// </summary>
	/// <param name="GroupId">群号</param>
	/// <param name="BotId">机器人 ID</param>
	/// <param name="Data_1">参数1</param>
	/// <param name="Data_2">参数2</param>
	public record class SendGroupBotCallbackRequestParams(
		long GroupId,
		long BotId,
		string? Data_1 = null,
		string? Data_2 = null
		)
	{
	}
}
