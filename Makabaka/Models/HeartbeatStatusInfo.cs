namespace Makabaka.Models
{
	/// <summary>
	/// 心跳状态信息
	/// </summary>
	public class HeartbeatStatusInfo
	{
		/// <summary>
		/// APP 是否已初始化
		/// </summary>
		public bool AppInitialized { get; set; }

		/// <summary>
		/// APP 是否已启用
		/// </summary>
		public bool AppEnabled { get; set; }

		/// <summary>
		/// APP 是否已好
		/// </summary>
		public bool AppGood { get; set; }

		/// <summary>
		/// 是否在线
		/// </summary>
		public bool Online { get; set; }

		/// <summary>
		/// 是否已好
		/// </summary>
		public bool Good { get; set; }
	}
}
