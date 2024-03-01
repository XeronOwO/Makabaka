using Makabaka.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Makabaka.Models.Messages
{
	/// <summary>
	/// <a href="https://github.com/botuniverse/onebot-11/blob/master/message/segment.md#%E6%88%B3%E4%B8%80%E6%88%B3">戳一戳段消息</a>
	/// </summary>
	public class PokeSegment : Segment
	{
		/// <summary>
		/// 戳一戳类型
		/// </summary>
		[JsonIgnore]
		public int PokeType
		{
			get
			{
				if (!RawData.TryGetValue("type", out var value))
				{
					return -1;
				}
				return int.Parse((string)value);
			}
			set
			{
				RawData["type"] = value.ToString();
			}
		}

		/// <summary>
		/// ID
		/// </summary>
		[JsonIgnore]
		public int Id
		{
			get
			{
				if (!RawData.TryGetValue("id", out var value))
				{
					return -1;
				}
				return int.Parse((string)value);
			}
			set
			{
				RawData["id"] = value.ToString();
			}
		}

		/// <summary>
		/// 名称
		/// </summary>
		[JsonIgnore]
		public string Name
		{
			get
			{
				return (string)RawData["name"];
			}
			set
			{
				RawData["name"] = value;
			}
		}

		/// <summary>
		/// Json序列化时使用，请勿在代码中调用
		/// </summary>
		public PokeSegment()
		{
			Type = "poke";
		}

		internal PokeSegment(string type, string id, string name) : this()
		{
			RawData = new()
			{
				{ "type", type },
				{ "id", id },
				{ "name", name },
			};
		}

		/// <summary>
		/// 创建可发送的<a href="https://github.com/botuniverse/onebot-11/blob/master/message/segment.md#%E6%88%B3%E4%B8%80%E6%88%B3">戳一戳段消息</a>
		/// </summary>
		/// <param name="type">类型</param>
		/// <param name="id">ID</param>
		public PokeSegment(int type, int id) : this(type.ToString(), id.ToString(), null)
		{
		}

		/// <inheritdoc/>
		public override string ToString()
		{
			return $"[CQ:{Type},type={PokeType},id={Id}]";
		}

		/// <summary>
		/// 戳一戳
		/// </summary>
		public static PokeSegment Poke
			=> new(1, -1);

		/// <summary>
		/// 比心
		/// </summary>
		public static PokeSegment ShowLove
			=> new(2, -1);

		/// <summary>
		/// 点赞
		/// </summary>
		public static PokeSegment Like
			=> new(3, -1);

		/// <summary>
		/// 心碎
		/// </summary>
		public static PokeSegment HeartBroken
			=> new(4, -1);

		/// <summary>
		/// 666
		/// </summary>
		public static PokeSegment SixSixSix
			=> new(5, -1);

		/// <summary>
		/// 放大招
		/// </summary>
		public static PokeSegment FangDaZhao
			=> new(6, -1);

		/// <summary>
		/// 宝贝球（SVIP）
		/// </summary>
		public static PokeSegment BaoBeiQiu
			=> new(126, 2011);

		/// <summary>
		/// 玫瑰花（SVIP）
		/// </summary>
		public static PokeSegment Rose
			=> new(126, 2007);

		/// <summary>
		/// 召唤术（SVIP）
		/// </summary>
		public static PokeSegment ZhaoHuanShu
			=> new(126, 2006);

		/// <summary>
		/// 让你皮（SVIP）
		/// </summary>
		public static PokeSegment RangNiPi
			=> new(126, 2009);

		/// <summary>
		/// 结印（SVIP）
		/// </summary>
		public static PokeSegment JieYin
			=> new(126, 2005);

		/// <summary>
		/// 手雷（SVIP）
		/// </summary>
		public static PokeSegment ShouLei
			=> new(126, 2004);

		/// <summary>
		/// 勾引（SVIP）
		/// </summary>
		public static PokeSegment GouYin
			=> new(126, 2003);

		/// <summary>
		/// 抓一下（SVIP）
		/// </summary>
		public static PokeSegment ZhuaYiXia
			=> new(126, 2001);

		/// <summary>
		/// 碎屏（SVIP）
		/// </summary>
		public static PokeSegment SuiPing
			=> new(126, 2002);

		/// <summary>
		/// 敲门（SVIP）
		/// </summary>
		public static PokeSegment QiaoMen
			=> new(126, 2000);
	}
}
