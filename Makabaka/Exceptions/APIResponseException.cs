using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Exceptions
{
	/// <summary>
	/// API响应异常
	/// </summary>
	public class APIResponseException : Exception
	{
		internal APIResponseException(string status, int retcode, string echo) : base($"[{echo}]API响应异常：[{retcode}]{status}")
		{

		}
	}
}
