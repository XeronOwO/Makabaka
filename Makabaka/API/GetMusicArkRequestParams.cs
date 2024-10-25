using System.Text.Json.Serialization;

namespace Makabaka.API
{
	/// <summary>
	/// 获取音乐 Ark 请求参数
	/// </summary>
	/// <param name="Title">标题</param>
	/// <param name="Desc">简介</param>
	/// <param name="JumpUrl">跳转链接</param>
	/// <param name="MusicUrl">音乐链接</param>
	/// <param name="SourceIcon">图标源</param>
	/// <param name="Tag">标签</param>
	/// <param name="Preview">预览</param>
	/// <param name="SourceMsgId">源消息 ID</param>
	public record class GetMusicArkRequestParams(
		string Title = "",
		string Desc = "",
		[property: JsonPropertyName("jumpUrl")] string JumpUrl = "",
		[property: JsonPropertyName("musicUrl")] string MusicUrl = "",
		string SourceIcon = "",
		string Tag = "",
		string Preview = "",
		[property: JsonPropertyName("sourceMsgId")] string SourceMsgId = ""
		)
	{
	}
}
