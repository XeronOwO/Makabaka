using Makabaka.Utils;

namespace Makabaka.Messages
{
	/// <summary>
	/// 位置段消息
	/// </summary>
	/// <param name="lat">
	/// 纬度<br/>
	/// ✔ 收<br/>
	/// ✔ 发
	/// </param>
	/// <param name="lon">
	/// 经度<br/>
	/// ✔ 收<br/>
	/// ✔ 发
	/// </param>
	[Segment(SegmentType.Location)]
	public class LocationSegment(double lat, double lon) : Segment<LocationData>(
		SegmentType.Location.ToSerializedString(),
		new()
		{
			Lat = lat,
			Lon = lon,
		})
	{
		/// <summary>
		/// 反序列化保留，请使用其它构造函数
		/// </summary>
		public LocationSegment() : this(0, 0)
		{
		}

		/// <inheritdoc/>
		public override string ToString()
		{
			return $"[CQ:{Type},lat={CqCode.Escape(Data.Lat.ToString())},lon={CqCode.Escape(Data.Lon.ToString())}]";
		}
	}
}
