using System;

namespace Makabaka.Exceptions
{
	/// <summary>
	/// API 响应数据为空异常
	/// </summary>
	/// <param name="echo">用于唯一标识一次请求</param>
	public class APIResponseDataNullException(Guid echo)
		: Exception(string.Format(SR.APIResponseDataNull, echo))
	{
	}
}
