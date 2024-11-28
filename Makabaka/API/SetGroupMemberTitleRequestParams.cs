namespace Makabaka.API
{
	/// <summary>
	/// 设置群组专属头衔
	/// </summary>
	/// <param name="GroupId">群号</param>
	/// <param name="UserId">要设置的 QQ 号</param>
	/// <param name="SpecialTitle">专属头衔，不填或空字符串表示删除专属头衔</param>
	/// <param name="Duration">专属头衔有效期，单位秒，-1 表示永久，不过此项似乎没有效果，可能是只有某些特殊的时间长度有效，有待测试</param>
	public record class SetGroupMemberTitleRequestParams(
		ulong GroupId,
		ulong UserId,
		string? SpecialTitle = null,
		int Duration = -1
		)
	{
	}
}
