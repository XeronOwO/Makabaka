namespace Makabaka.Models
{
	/// <summary>
	/// 状态信息
	/// </summary>
	public class StatusInfo
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
		/// 插件是否已好
		/// </summary>
		public bool PluginsGood { get; set; }

		/// <summary>
		/// APP 是否已好
		/// </summary>
		public bool AppGood { get; set; }

		/// <summary>
		/// 当前 QQ 在线，null 表示无法查询到在线状态
		/// </summary>
		public bool Online { get; set; }

		/// <summary>
		/// 状态符合预期，意味着各模块正常运行、功能正常，且 QQ 在线
		/// </summary>
		public bool Good { get; set; }

		/// <summary>
		/// 内存
		/// </summary>
		public long Memory { get; set; }
	}
}
