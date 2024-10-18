namespace Makabaka.Events
{
    /// <summary>
    /// 元事件信息
    /// </summary>
    public class MetaEventArgs : PostEventArgs
    {
        /// <summary>
        /// 元事件类型
        /// </summary>
        public MetaEventType MetaEventType { get; set; }
    }
}
