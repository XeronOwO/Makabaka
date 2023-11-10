using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Utils
{
	/// <summary>
	/// CqCode处理工具
	/// </summary>
	public static class CqCode
	{
		private static readonly Dictionary<string, string> _replacement = new()
		{
			{ "&", "&amp;" },
			{ "[", "&#91;" },
			{ "]", "&#93;" },
			{ ",", "&#44;" },
		};

		/// <summary>
		/// 对字符串内容进行CqCode转义
		/// </summary>
		/// <param name="data">字符串内容</param>
		/// <returns>转义结果</returns>
		public static string Encode(string data)
		{
			var result = data;

			foreach (var rep in _replacement)
			{
				result = result.Replace(rep.Key, rep.Value);
			}

			return result;
		}

		/// <summary>
		/// 对字符串内容进行CqCode逆转义
		/// </summary>
		/// <param name="data">字符串内容</param>
		/// <returns>逆转义结果</returns>
		public static string Decode(string data)
		{
			var result = data;

			foreach (var rep in _replacement)
			{
				result = result.Replace(rep.Value, rep.Key);
			}

			return result;
		}
	}
}
