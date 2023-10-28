using Makabaka.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.EventArgs.Meta
{
    /// <summary>
    /// <a href="https://github.com/botuniverse/onebot-11/blob/master/event/meta.md">元事件</a>事件参数
    /// </summary>
    public abstract class MetaEventArgs : CommonEventArgs
    {
        /// <summary>
        /// 元事件类型
        /// </summary>
        [JsonProperty("meta_event_type")]
        public string MetaEventType { get; internal set; }
    }
}
