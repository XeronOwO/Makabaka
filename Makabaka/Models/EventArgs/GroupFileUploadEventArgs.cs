using Makabaka.Models.API.Responses;
using Makabaka.Models.Messages;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Makabaka.Models.EventArgs
{
	/// <summary>
	/// <a href="https://github.com/botuniverse/onebot-11/blob/master/event/notice.md#%E7%BE%A4%E6%96%87%E4%BB%B6%E4%B8%8A%E4%BC%A0">群文件上传</a>事件参数
	/// </summary>
	public class GroupFileUploadEventArgs : NoticeEventArgs, IReply
	{
		/// <summary>
		/// 群号
		/// </summary>
		[JsonProperty("group_id")]
		public long GroupId { get; internal set; }

		/// <summary>
		/// 发送者 QQ 号
		/// </summary>
		[JsonProperty("user_id")]
		public long UserId { get; internal set; }

		/// <summary>
		/// 文件信息
		/// </summary>
		[JsonProperty("file")]
		public FileInfo File { get; internal set; }

		/// <inheritdoc/>
		public Task<APIResponse<MessageIdRes>> ReplyAsync(Message message)
		{
			return Context.SendGroupMessageAsync(GroupId, message);
		}
	}
}
