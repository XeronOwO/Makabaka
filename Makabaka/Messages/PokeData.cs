namespace Makabaka.Messages
{
	/// <summary>
	/// 戳一戳数据
	/// </summary>
	public class PokeData
	{
		/// <summary>
		/// 类型<br/>
		/// 见 <a href="https://github.com/mamoe/mirai/blob/f5eefae7ecee84d18a66afce3f89b89fe1584b78/mirai-core/src/commonMain/kotlin/net.mamoe.mirai/message/data/HummerMessage.kt#L49">Mirai 的 PokeMessage 类</a><br/>
		/// ✔ 收<br/>
		/// ✔ 发
		/// </summary>
		public string Type { get; set; } = string.Empty;

		/// <summary>
		/// ID<br/>
		/// 见 <a href="https://github.com/mamoe/mirai/blob/f5eefae7ecee84d18a66afce3f89b89fe1584b78/mirai-core/src/commonMain/kotlin/net.mamoe.mirai/message/data/HummerMessage.kt#L49">Mirai 的 PokeMessage 类</a><br/>
		/// ✔ 收<br/>
		/// ✔ 发
		/// </summary>
		public string Id { get; set; } = string.Empty;

		/// <summary>
		/// 表情名<br/>
		/// 见 <a href="https://github.com/mamoe/mirai/blob/f5eefae7ecee84d18a66afce3f89b89fe1584b78/mirai-core/src/commonMain/kotlin/net.mamoe.mirai/message/data/HummerMessage.kt#L49">Mirai 的 PokeMessage 类</a><br/>
		/// ✔ 收<br/>
		/// ✘ 发
		/// </summary>
		public string Name { get; set; } = string.Empty;
	}
}
