using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.EventArgs
{
    /// <summary>
    /// <a href="https://github.com/botuniverse/onebot-11/blob/master/event/meta.md">上报类型</a>事件参数
    /// </summary>
    public abstract class TypeEventArgs : SessionEventArgs
    {
        /// <summary>
        /// 上报类型
        /// </summary>
        [JsonProperty("post_type")]
        public string PostType { get; internal set; }
    }
}
