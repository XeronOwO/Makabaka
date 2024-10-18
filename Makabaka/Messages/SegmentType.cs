namespace Makabaka.Messages
{
	/// <summary>
	/// 段消息类型
	/// </summary>
	public enum SegmentType
	{
		/// <summary>
		/// 不支持
		/// </summary>
		Unsupported,

		/// <summary>
		/// 文本
		/// </summary>
		Text,

		/// <summary>
		/// QQ 表情
		/// </summary>
		Face,

		/// <summary>
		/// 图片
		/// </summary>
		Image,

		/// <summary>
		/// 语音
		/// </summary>
		Record,

		/// <summary>
		/// 短视频
		/// </summary>
		Video,

		/// <summary>
		/// @某人
		/// </summary>
		At,

		/// <summary>
		/// 猜拳魔法表情
		/// </summary>
		Rps,

		/// <summary>
		/// 掷骰子魔法表情
		/// </summary>
		Dice,

		/// <summary>
		/// 窗口抖动（戳一戳）
		/// </summary>
		Shake,

		/// <summary>
		/// 戳一戳
		/// </summary>
		Poke,

		/// <summary>
		/// 匿名发消息
		/// </summary>
		Anonymous,

		/// <summary>
		/// 链接分享
		/// </summary>
		Share,

		/// <summary>
		/// 推荐好友/群
		/// </summary>
		Contact,

		/// <summary>
		/// 位置
		/// </summary>
		Location,

		/// <summary>
		/// 音乐分享
		/// </summary>
		Music,

		/// <summary>
		/// 回复
		/// </summary>
		Reply,

		/// <summary>
		/// 合并转发
		/// </summary>
		Forward,

		/// <summary>
		/// 合并转发节点
		/// </summary>
		Node,

		/// <summary>
		/// XML 消息
		/// </summary>
		Xml,

		/// <summary>
		/// JSON 消息
		/// </summary>
		Json,

		/// <summary>
		/// 商城表情
		/// </summary>
		Mface,
	}
}
