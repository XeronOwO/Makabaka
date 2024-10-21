namespace Makabaka.API
{
	/// <summary>
	/// 重启 OneBot 实现请求参数
	/// </summary>
	/// <param name="Delay">要延迟的毫秒数，如果默认情况下无法重启，可以尝试设置延迟为 2000 左右</param>
	public record class RestartRequestParams(
		long Delay = 0
		)
	{
	}
}
