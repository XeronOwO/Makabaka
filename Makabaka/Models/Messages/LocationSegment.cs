using Makabaka.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Makabaka.Models.Messages
{
	/// <summary>
	/// <a href="https://github.com/botuniverse/onebot-11/blob/master/message/segment.md#%E4%BD%8D%E7%BD%AE">位置段消息</a>
	/// </summary>
	public class LocationSegment : Segment
	{
		/// <summary>
		/// 纬度
		/// </summary>
		[JsonIgnore]
		public double Latitude
		{
			get
			{
				if (!RawData.TryGetValue("lat", out var value))
				{
					return 0;
				}
				return double.Parse((string)value);
			}
			set
			{
				RawData["lat"] = value.ToString();
			}
		}

		/// <summary>
		/// 经度
		/// </summary>
		[JsonIgnore]
		public double Longitude
		{
			get
			{
				if (!RawData.TryGetValue("lon", out var value))
				{
					return 0;
				}
				return double.Parse((string)value);
			}
			set
			{
				RawData["lon"] = value.ToString();
			}
		}

		/// <summary>
		/// 发送时可选，标题
		/// </summary>
		[JsonIgnore]
		public string Title
		{
			get
			{
				return (string)RawData["title"];
			}
			set
			{
				RawData["title"] = value;
			}
		}

		/// <summary>
		/// 发送时可选，内容描述
		/// </summary>
		[JsonIgnore]
		public string Content
		{
			get
			{
				return (string)RawData["content"];
			}
			set
			{
				RawData["content"] = value;
			}
		}

		/// <summary>
		/// Json序列化时使用，请勿在代码中调用
		/// </summary>
		public LocationSegment()
		{
			Type = "location";
		}

		internal LocationSegment(string latitude, string longitude, string title, string content) : this()
		{
			RawData = new()
			{
				{ "lat", latitude.ToString() },
				{ "lon", longitude.ToString() },
				{ "title", title },
				{ "content", content },
			};
		}

		/// <summary>
		/// 创建<a href="https://github.com/botuniverse/onebot-11/blob/master/message/segment.md#%E4%BD%8D%E7%BD%AE">位置段消息</a>
		/// </summary>
		/// <param name="latitude">纬度</param>
		/// <param name="longitude">经度</param>
		/// <param name="title">发送时可选，标题</param>
		/// <param name="content">发送时可选，内容描述</param>
		public LocationSegment(double latitude, double longitude, string title = "", string content = "")
			: this(latitude.ToString(), longitude.ToString(), title, content)
		{
		}

		/// <inheritdoc/>
		public override string ToString()
		{
			return $"[CQ:{Type},lat={Latitude},lon={Longitude}]";
		}
	}
}
