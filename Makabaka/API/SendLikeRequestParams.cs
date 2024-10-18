namespace Makabaka.API
{
	/// <summary>
	/// 发送好友赞请求参数
	/// </summary>
	/// <param name="userId">对方 QQ 号</param>
	/// <param name="times">赞的次数，每个好友每天最多 10 次</param>
	public class SendLikeRequestParams(long userId, int times = 1)
	{
		/// <summary>
		/// 对方 QQ 号
		/// </summary>
		public long UserId { get; set; } = userId;

		/// <summary>
		/// 赞的次数，每个好友每天最多 10 次
		/// </summary>
		public int Times { get; set; } = times;
	}
}
