using System;

namespace Makabaka.Exceptions
{
	/// <summary>
	/// API 异常
	/// </summary>
	/// <param name="status">状态</param>
	/// <param name="retcode">返回值</param>
	/// <param name="echo">用于唯一标识一次请求</param>
	public class APIException(string status, long retcode, Guid echo)
		: Exception(string.Format(SR.APIResponseError, echo, status, retcode))
	{
	}
}
