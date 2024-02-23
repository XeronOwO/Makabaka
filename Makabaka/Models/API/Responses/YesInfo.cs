using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.API.Responses
{
	/// <summary>
	/// 是否信息
	/// </summary>
	public class YesInfo
	{
		[JsonProperty("yes")]
		public bool Yes { get; set; }
	}
}
