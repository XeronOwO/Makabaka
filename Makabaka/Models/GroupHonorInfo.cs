namespace Makabaka.Models
{
	/// <summary>
	/// 群荣誉信息
	/// </summary>
	public class GroupHonorInfo
	{
		/// <summary>
		/// 当前龙王，仅 type 为 talkative 或 all 时有数据
		/// </summary>
		public TalkativeInfo CurrentTalkative { get; set; } = new();

		/// <summary>
		/// 历史龙王，仅 type 为 talkative 或 all 时有数据
		/// </summary>
		public GroupMemberHonorInfo[] TalkativeList { get; set; } = [];

		/// <summary>
		/// 群聊之火，仅 type 为 performer 或 all 时有数据
		/// </summary>
		public GroupMemberHonorInfo[]? PerformerList { get; set; } = [];

		/// <summary>
		/// 群聊炽焰，仅 type 为 legend 或 all 时有数据
		/// </summary>
		public GroupMemberHonorInfo[] LegendList { get; set; } = [];

		/// <summary>
		/// 冒尖小春笋，仅 type 为 strong_newbie 或 all 时有数据
		/// </summary>
		public GroupMemberHonorInfo[] StrongNewbieList { get; set; } = [];

		/// <summary>
		/// 快乐之源，仅 type 为 emotion 或 all 时有数据
		/// </summary>
		public GroupMemberHonorInfo[] EmotionList { get; set; } = [];
	}
}
