using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.EventArgs
{
    /// <summary>
    /// <a href="https://github.com/botuniverse/onebot-11/blob/master/event/request.md#%E5%8A%A0%E5%A5%BD%E5%8F%8B%E8%AF%B7%E6%B1%82">加好友请求</a>事件参数
    /// </summary>
    public class AddFriendRequestEventArgs : CommonEventArgs
    {
        /// <summary>
        /// 请求类型
        /// </summary>
        [JsonProperty("request_type")]
        public string RequestType { get; set; }

        /// <summary>
        /// 发送请求的 QQ 号
        /// </summary>
        [JsonProperty("user_id")]
        public long UserId { get; set; }

        /// <summary>
        /// 验证信息
        /// </summary>
        [JsonProperty("comment")]
        public string Comment { get; set; }

        /// <summary>
        /// 请求 flag，在调用处理请求的 API 时需要传入
        /// </summary>
        [JsonProperty("flag")]
        public string Flag { get; set; }
    }
}
