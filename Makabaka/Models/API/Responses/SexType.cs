using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.API.Responses
{
	/// <summary>
	/// 性别类型
	/// </summary>
	[JsonConverter(typeof(StringEnumConverter))]
	public enum SexType
	{
		/// <summary>
		/// 男
		/// </summary>
		Male,
		/// <summary>
		/// 女
		/// </summary>
		Female,
		/// <summary>
		/// 未知
		/// </summary>
		Unknown,
	}
}
