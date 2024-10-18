using System;

namespace Makabaka.Utils
{
	internal static class TimestampExt
	{
		private static readonly DateTime _startTime = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1) + TimeZoneInfo.Local.GetUtcOffset(DateTime.Now), TimeZoneInfo.FindSystemTimeZoneById(TimeZoneInfo.Local.Id));

		public static DateTime ToDateTime(this long timestamp)
		{
			return _startTime.AddSeconds(timestamp);
		}
	}
}
