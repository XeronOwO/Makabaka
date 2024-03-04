using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Makabaka.Models.Messages
{
	/// <summary>
	/// 长消息段消息
	/// </summary>
	public class LongMsgSegment : Segment
	{
		/// <summary>
		/// ResId
		/// </summary>
		[JsonIgnore]
		public string Id
		{
			get
			{
				return (string)RawData["id"];
			}
			set
			{
				RawData["id"] = value;
			}
		}

		/// <summary>
		/// Json序列化时使用，请勿在代码中调用
		/// </summary>
		public LongMsgSegment()
		{
			Type = "longmsg";
		}

		/// <summary>
		/// 创建长消息段消息
		/// </summary>
		/// <param name="resid">ResId</param>
		public LongMsgSegment(string resid) : this()
		{
			RawData = new JObject()
			{
				{ "id", resid },
			};
		}

		/// <inheritdoc/>
		public override string ToString()
		{
			return $"[CQ:{Type},id={Id}]";
		}
	}
}
