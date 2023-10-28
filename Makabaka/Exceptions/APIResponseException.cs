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
		public APIResponseException(string status, int retcode, string echo) : base($"[{echo}]API响应异常：[{retcode}]{status}")
		{

		}
	}
}
