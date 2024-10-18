using System;

namespace Makabaka.Exceptions
{
	/// <summary>
	/// API 超时异常
	/// </summary>
	/// <param name="echo">唯一标识符</param>
	public class APITimeoutException(Guid echo) : Exception(string.Format(SR.APITimeout, echo))
	{
	}
}
