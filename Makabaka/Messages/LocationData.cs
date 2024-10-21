namespace Makabaka.Messages
{
	/// <summary>
	/// 位置数据
	/// </summary>
	public class LocationData
	{
		/// <summary>
		/// 纬度<br/>
		/// ✔ 收<br/>
		/// ✔ 发
		/// </summary>
		public double Lat { get; set; }

		/// <summary>
		/// 经度<br/>
		/// ✔ 收<br/>
		/// ✔ 发
		/// </summary>
		public double Lon { get; set; }

		/// <summary>
		/// 发送时可选，标题<br/>
		/// ✔ 收<br/>
		/// ✔ 发
		/// </summary>
		public string Title { get; set; } = string.Empty;

		/// <summary>
		/// 发送时可选，内容描述<br/>
		/// ✔ 收<br/>
		/// ✔ 发
		/// </summary>
		public string Content { get; set; } = string.Empty;
	}
}
