using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.EventArgs
{
    /// <summary>
    /// <a href="https://github.com/botuniverse/onebot-11/blob/master/event/meta.md#%E5%BF%83%E8%B7%B3">心跳</a>事件参数
    /// </summary>
    public class HeartbeatEventArgs : MetaEventArgs
    {
        /// <summary>
        /// 状态信息
        /// </summary>
        [JsonProperty("status")]
        public object Status { get; internal set; }

        /// <summary>
        /// 到下次心跳的间隔，单位毫秒
        /// </summary>
        [JsonProperty("interval")]
        public long Interval { get; internal set; }
    }
}
