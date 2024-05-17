using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Makabaka.Models.Messages
{
	public class MarketFaceSegment : Segment
	{
		[JsonIgnore]
		public string FaceId
		{
			get
			{
				return (string)RawData["face_id"];
			}
			set
			{
				RawData["face_id"] = value;
			}
		}

		[JsonIgnore]
		public string TabId
		{
			get
			{
				return (string)RawData["tab_id"];
			}
			set
			{
				RawData["tab_id"] = value;
			}
		}

		[JsonIgnore]
		public string Key
		{
			get
			{
				return (string)RawData["key"];
			}
			set
			{
				RawData["key"] = value;
			}
		}

		[JsonIgnore]
		public string Summary
		{
			get
			{
				return (string)RawData["summary"];
			}
			set
			{
				RawData["summary"] = value;
			}
		}

		/// <summary>
		/// Json序列化时使用，请勿在代码中调用
		/// </summary>
		public MarketFaceSegment()
		{
			Type = "marketface";
		}

		public MarketFaceSegment(string faceId, string tabId, string key, string summary) : this()
		{
			RawData = new JObject()
			{
				{ "face_id", faceId },
				{ "tab_id", tabId },
				{ "key", key },
				{ "summary", summary },
			};
		}
	}
}
