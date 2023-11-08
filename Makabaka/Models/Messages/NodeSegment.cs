using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makabaka.Models.Messages
{
	/// <summary>
	/// <a href="https://github.com/botuniverse/onebot-11/blob/master/message/segment.md#%E5%90%88%E5%B9%B6%E8%BD%AC%E5%8F%91%E8%87%AA%E5%AE%9A%E4%B9%89%E8%8A%82%E7%82%B9">合并转发自定义节点段消息</a>
	/// </summary>
	public class NodeSegment : Segment
	{
		/// <summary>
		/// 发送者 QQ 号
		/// </summary>
		[JsonIgnore]
		public string UserId
		{
			get
			{
				return (string)RawData["user_id"];
			}
			set
			{
				RawData["user_id"] = value;
			}
		}

		/// <summary>
		/// 发送者昵称
		/// </summary>
		[JsonIgnore]
		public string Nickname
		{
			get
			{
				return (string)RawData["nickname"];
			}
			set
			{
				RawData["nickname"] = value;
			}
		}

		[JsonIgnore]
		private Message _content;

		/// <summary>
		/// 消息内容，支持发送消息时的 message 数据类型，见 <a href="https://github.com/botuniverse/onebot-11/tree/master/api#%E5%8F%82%E6%95%B0">API 的参数</a>
		/// </summary>
		[JsonIgnore]
		public Message Content
		{
			get
			{
				return _content;
			}
			set
			{
				_content = value;
				RawData["content"] = JObject.Parse(JsonConvert.SerializeObject(_content));
			}
		}

		/// <summary>
		/// 创建<a href="https://github.com/botuniverse/onebot-11/blob/master/message/segment.md#%E5%90%88%E5%B9%B6%E8%BD%AC%E5%8F%91%E8%87%AA%E5%AE%9A%E4%B9%89%E8%8A%82%E7%82%B9">合并转发自定义节点段消息</a>
		/// </summary>
		/// <param name="userId">发送者 QQ 号</param>
		/// <param name="nickname">发送者昵称</param>
		/// <param name="content">消息内容，支持发送消息时的 message 数据类型，见 <a href="https://github.com/botuniverse/onebot-11/tree/master/api#%E5%8F%82%E6%95%B0">API 的参数</a></param>
		public NodeSegment(string userId, string nickname, JArray content)
		{
			Type = "node";
			RawData = new JObject()
			{
				{ "user_id", userId },
				{ "nickname", nickname },
				{ "content", content },
			};
			_content = JsonConvert.DeserializeObject<Message>(content.ToString(Formatting.None));
			_content.PostProcessMessage();
		}

		/// <summary>
		/// 创建<a href="https://github.com/botuniverse/onebot-11/blob/master/message/segment.md#%E5%90%88%E5%B9%B6%E8%BD%AC%E5%8F%91%E8%87%AA%E5%AE%9A%E4%B9%89%E8%8A%82%E7%82%B9">合并转发自定义节点段消息</a>
		/// </summary>
		/// <param name="userId">发送者 QQ 号</param>
		/// <param name="nickname">发送者昵称</param>
		/// <param name="content">消息内容，支持发送消息时的 message 数据类型，见 <a href="https://github.com/botuniverse/onebot-11/tree/master/api#%E5%8F%82%E6%95%B0">API 的参数</a></param>
		public NodeSegment(long userId, string nickname, JArray content)
			: this(userId.ToString(), nickname, content)
		{

		}

		/// <inheritdoc/>
		public override string ToString()
		{
			return $"[CQ:node,user_id={UserId},nickname={Nickname},content={Content}]";
		}
	}
}
