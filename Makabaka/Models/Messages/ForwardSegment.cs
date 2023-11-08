﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Makabaka.Models.Messages
{
	/// <summary>
	/// <a href="https://github.com/botuniverse/onebot-11/blob/master/message/segment.md#%E5%90%88%E5%B9%B6%E8%BD%AC%E5%8F%91-">合并转发段消息</a>
	/// </summary>
	public class ForwardSegment : Segment
	{
		[JsonIgnore]
		private string _id;

		/// <summary>
		/// 合并转发 ID，需通过 GetForwardMsg API 获取具体内容
		/// </summary>
		[JsonIgnore]
		public string Id
		{
			get
			{
				return _id;
			}
			set
			{
				RawData["id"] = _id = value;
			}
		}

		/// <summary>
		/// 创建<a href="https://github.com/botuniverse/onebot-11/blob/master/message/segment.md#%E5%90%88%E5%B9%B6%E8%BD%AC%E5%8F%91-">合并转发段消息</a>
		/// </summary>
		/// <param name="id">消息ID</param>
		public ForwardSegment(string id)
		{
			Type = "forward";
			RawData = new JObject()
			{
				{ "id", id },
			};
			_id = id;
		}

		/// <summary>
		/// 创建<a href="https://github.com/botuniverse/onebot-11/blob/master/message/segment.md#%E5%90%88%E5%B9%B6%E8%BD%AC%E5%8F%91-">合并转发段消息</a>
		/// </summary>
		/// <param name="id">消息ID</param>
		public ForwardSegment(long id) : this(id.ToString())
		{

		}

		/// <inheritdoc/>
		public override string ToString()
		{
			return $"[CQ:forward,id={_id}]";
		}
	}
}
