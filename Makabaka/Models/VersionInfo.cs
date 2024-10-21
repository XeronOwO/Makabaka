using System;

namespace Makabaka.Models
{
	/// <summary>
	/// 版本信息
	/// </summary>
	public class VersionInfo
	{
		/// <summary>
		/// 应用标识，如 mirai-native
		/// </summary>
		public string AppName { get; set; } = string.Empty;

		/// <summary>
		/// 应用版本，如 1.2.3
		/// </summary>
		public Version AppVersion { get; set; } = new();

		/// <summary>
		/// OneBot 标准版本，如 v11
		/// </summary>
		public string ProtocolVersion { get; set; } = string.Empty;

		/// <summary>
		/// NTQQ 协议信息
		/// </summary>
		public string NtProtocol { get; set; } = string.Empty;
	}
}
