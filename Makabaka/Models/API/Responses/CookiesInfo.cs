using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.API.Responses
{
	/// <summary>
	/// Cookies信息
	/// </summary>
	public class CookiesInfo
	{
		/// <summary>
		/// Cookies
		/// </summary>
		[JsonProperty("cookies")]
		public string Cookies { get; set; }
	}
}
