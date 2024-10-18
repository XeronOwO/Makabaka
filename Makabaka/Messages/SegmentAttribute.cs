using System;

namespace Makabaka.Messages
{
	/// <summary>
	/// 段消息类型特性
	/// </summary>
	/// <param name="type">类型</param>
	[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
	public class SegmentAttribute(SegmentType type) : Attribute
	{
		/// <summary>
		/// 类型
		/// </summary>
		public SegmentType Type { get; } = type;
	}
}
