namespace Makabaka.Events
{
    /// <summary>
    /// 生命周期事件信息
    /// </summary>
    public class LifecycleEventArgs : MetaEventArgs
    {
        /// <summary>
        /// 事件子类型<br/>
        /// enable：OneBot 启用<br/>
        /// disable：OneBot 禁用<br/>
        /// connect：WebSocket 连接成功
        /// </summary>
        public string SubType { get; set; } = string.Empty;
    }
}
