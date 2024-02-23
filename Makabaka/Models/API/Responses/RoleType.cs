using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Makabaka.Models.API.Responses
{
	/// <summary>
	/// 角色类型
	/// </summary>
	[JsonConverter(typeof(StringEnumConverter))]
	public enum RoleType
	{
		/// <summary>
		/// 群主
		/// </summary>
		Owner,
		/// <summary>
		/// 管理员
		/// </summary>
		Admin,
		/// <summary>
		/// 群员
		/// </summary>
		Member,
	}
}
