namespace Makabaka.API
{
	/// <summary>
	/// 设置群聊机器人请求参数
	/// </summary>
	/// <param name="GroupId">群聊 ID</param>
	/// <param name="BotId">机器人 ID</param>
	/// <param name="Enable">是否启用</param>
	public record class SetGroupBotRequestParams(
		long GroupId,
		long BotId,
		uint Enable
		)
	{
	}
}
