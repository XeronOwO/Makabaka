using Makabaka.Utils;

namespace Makabaka.Messages
{
	/// <summary>
	/// 戳一戳段消息
	/// </summary>
	/// <param name="type">
	/// 类型<br/>
	/// 见 <a href="https://github.com/mamoe/mirai/blob/f5eefae7ecee84d18a66afce3f89b89fe1584b78/mirai-core/src/commonMain/kotlin/net.mamoe.mirai/message/data/HummerMessage.kt#L49">Mirai 的 PokeMessage 类</a><br/>
	/// ✔ 收<br/>
	/// ✔ 发
	/// </param>
	/// <param name="id">
	/// ID<br/>
	/// 见 <a href="https://github.com/mamoe/mirai/blob/f5eefae7ecee84d18a66afce3f89b89fe1584b78/mirai-core/src/commonMain/kotlin/net.mamoe.mirai/message/data/HummerMessage.kt#L49">Mirai 的 PokeMessage 类</a><br/>
	/// ✔ 收<br/>
	/// ✔ 发
	/// </param>
	[Segment(SegmentType.Poke)]
	public class PokeSegment(string type, string id)
		: Segment<PokeData>(
			SegmentType.Poke.ToSerializedString(),
			new()
			{
				Type = type,
				Id = id
			})
	{
		/// <summary>
		/// 反序列化保留，请使用其它构造函数
		/// </summary>
		public PokeSegment() : this(string.Empty, string.Empty)
		{
		}

		/// <inheritdoc/>
		public override string ToString()
		{
			return $"[CQ:{Type},type={CqCode.Escape(Data.Type)},id={CqCode.Escape(Data.Id)}]";
		}
	}
}
