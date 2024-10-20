using System.Text.Json.Nodes;
using Makabaka.Models;

namespace Makabaka.Events
{
	/// <summary>
	/// 心跳事件参数
	/// </summary>
	public class HeartbeatEventArgs : MetaEventArgs
	{
		/// <summary>
		/// 状态信息
		/// </summary>
		public HeartbeatStatusInfo Status { get; set; } = new();

		/// <summary>
		/// 到下次心跳的间隔，单位毫秒
		/// </summary>
		public long Interval { get; set; }
	}
}
