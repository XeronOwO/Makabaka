namespace Makabaka.Events
{
	/// <summary>
	/// 心跳状态
	/// </summary>
	public class HeartbeatStatus
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
