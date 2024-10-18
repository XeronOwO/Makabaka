using System.Collections.Generic;

namespace Makabaka.Utils
{
	/// <summary>
	/// CqCode处理工具
	/// </summary>
	public static class CqCode
	{
		private static readonly Dictionary<string, string> _escapeMap = new()
		{
			{ "&", "&amp;" },
			{ "[", "&#91;" },
			{ "]", "&#93;" },
			{ ",", "&#44;" },
		};

		/// <summary>
		/// 对字符串内容进行CqCode转义
		/// </summary>
		/// <param name="text">字符串内容</param>
		/// <returns>转义结果</returns>
		public static string Escape(string text)
		{
			var result = text;

			foreach (var rep in _escapeMap)
			{
				result = result.Replace(rep.Key, rep.Value);
			}

			return result;
		}

		/// <summary>
		/// 对字符串内容进行CqCode逆转义
		/// </summary>
		/// <param name="text">字符串内容</param>
		/// <returns>逆转义结果</returns>
		public static string Unescape(string text)
		{
			var result = text;

			foreach (var rep in _escapeMap)
			{
				result = result.Replace(rep.Value, rep.Key);
			}

			return result;
		}
	}
}
