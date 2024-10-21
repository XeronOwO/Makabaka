using Makabaka.Utils;
using System.Text;

namespace Makabaka.Messages
{
	/// <summary>
	/// 合并转发节点段消息
	/// </summary>
	[Segment(SegmentType.Node)]
	public class NodeSegment : Segment<NodeData>
	{
		/// <summary>
		/// 合并转发节点
		/// </summary>
		/// <param name="id">
		/// (合并转发节点) 转发的消息 ID<br/>
		/// ✘ 收<br/>
		/// ✔ 发
		/// </param>
		public NodeSegment(string id) : base(
			SegmentType.Node.ToSerializedString(),
			new()
			{
				Id = id,
			})
		{
		}

		/// <summary>
		/// 合并转发自定义节点
		/// </summary>
		/// <param name="userId">
		/// (合并转发自定义节点) 发送者 QQ 号<br/>
		/// ✔ 收<br/>
		/// ✔ 发
		/// </param>
		/// <param name="nickname">
		/// (合并转发自定义节点) 发送者昵称<br/>
		/// ✔ 收<br/>
		/// ✔ 发
		/// </param>
		/// <param name="content">
		/// (合并转发自定义节点) 消息内容，支持发送消息时的 message 数据类型，见 <a href="https://github.com/botuniverse/onebot-11/blob/master/api/#%E5%8F%82%E6%95%B0">API 的参数</a><br/>
		/// ✔ 收<br/>
		/// ✔ 发
		/// </param>
		public NodeSegment(
			string userId,
			string nickname,
			Message content
			) : base(
				SegmentType.Node.ToSerializedString(),
				new()
				{
					UserId = userId,
					Nickname = nickname,
					Content = content,
				})
		{
		}

		/// <summary>
		/// 反序列化保留，请使用其它构造函数
		/// </summary>
		public NodeSegment() : this(string.Empty)
		{
		}
	}
}
