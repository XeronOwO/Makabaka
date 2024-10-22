namespace Makabaka.Models
{
	/// <summary>
	/// 群公告图片信息
	/// </summary>
	public class GroupNoticeImageInfo
	{
		/// <summary>
		/// 图片 ID
		/// </summary>
		public string Id { get; set; } = string.Empty;

		/// <summary>
		/// 图片高度
		/// </summary>
		public string Height { get; set; } = string.Empty;

		/// <summary>
		/// 图片宽度
		/// </summary>
		public string Width { get; set; } = string.Empty;

		/// <summary>
		/// 获取图片 URL（第一种）
		/// </summary>
		/// <param name="scale">图片尺寸</param>
		/// <returns>图片 URL</returns>
		public string GetUrl1(int scale = 0)
			=> $"https://gdynamic.qpic.cn/gdynamic/{Id}/{scale}/";

		/// <summary>
		/// 获取图片 URL（第二种）
		/// </summary>
		/// <param name="scale">图片尺寸</param>
		/// <returns>图片 URL</returns>
		public string GetUrl2(int scale = 0)
			=> $"https://p.qlogo.cn/gdynamic/{Id}/{scale}/";
	}
}
