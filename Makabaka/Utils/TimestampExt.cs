using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Utils
{
	internal static class TimestampExt
	{
		private static readonly DateTime UnixTime = new(1970, 1, 1, 0, 0, 0);

		public static DateTime ToDateTime(this long timestamp)
		{
			return UnixTime.AddMilliseconds(timestamp);
		}
	}
}
