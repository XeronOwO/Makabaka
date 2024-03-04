using Makabaka.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Makabaka.Models.Messages
{
	/// <summary>
	/// 消息按钮段消息
	/// </summary>
	public class KeyboardSegment : Segment
	{
		/// <summary>
		/// Json序列化时使用，请勿在代码中调用
		/// </summary>
		public KeyboardSegment()
		{
			Type = "keyboard";
		}

		/// <summary>
		/// 创建消息按钮段消息
		/// </summary>
		/// <param name="content">内容</param>
		public KeyboardSegment(JObject content) : this()
		{
			RawData = content;
		}

		/// <summary>
		/// 创建消息按钮段消息
		/// </summary>
		/// <param name="content">内容</param>
		public KeyboardSegment(KeyboardData content) : this()
		{
			RawData = JObject.FromObject(content);
		}
	}

	/// <summary>
	/// 消息按钮数据
	/// </summary>
	public class KeyboardData
	{
		/// <summary>
		/// 内容
		/// </summary>
		[JsonProperty("content")]
		public KeyboardContent Content { get; set; }
	}

	/// <summary>
	/// 消息按钮内容
	/// </summary>
	public class KeyboardContent
	{
		/// <summary>
		/// 行
		/// </summary>
		[JsonProperty("rows")]
		public List<KeyboardRow> Rows { get; set; }
	}

	/// <summary>
	/// 消息按钮行
	/// </summary>
	public class KeyboardRow
	{
		/// <summary>
		/// 按钮
		/// </summary>
		[JsonProperty("buttons")]
		public List<KeyboardButton> Buttons { get; set; }
	}

	/// <summary>
	/// 消息按钮按钮
	/// </summary>
	public class KeyboardButton
	{
		/// <summary>
		/// （非必填）按钮ID：在一个keyboard消息内设置唯一
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// 渲染数据
		/// </summary>
		[JsonProperty("render_data")]
		public KeyboardRenderData RenderData { get; set; }

		/// <summary>
		/// 行为
		/// </summary>
		[JsonProperty("action")]
		public KeyboardAction Action { get; set; }
	}

	/// <summary>
	/// 消息按钮渲染数据
	/// </summary>
	public class KeyboardRenderData
	{
		/// <summary>
		/// （必填）按钮上的文字
		/// </summary>
		[JsonProperty]
		public string Label { get; set; }

		/// <summary>
		/// （必填）点击后按钮的上文字
		/// </summary>
		[JsonProperty("visited_label")]
		public string VisitedLabel { get; set; }

		/// <summary>
		/// （必填）按钮样式：0 灰色线框，1 蓝色线框
		/// </summary>
		[JsonProperty("style")]
		public int Style { get; set; }
	}

	/// <summary>
	/// 消息按钮操作
	/// </summary>
	public class KeyboardAction
	{
		/// <summary>
		/// （必填）设置 0 跳转按钮：http 或 小程序 客户端识别 scheme，设置 1 回调按钮：回调后台接口, data 传给后台，设置 2 指令按钮：自动在输入框插入 @bot data
		/// </summary>
		[JsonProperty("type")]
		public int Type { get; set; }

		/// <summary>
		/// （必填）操作权限
		/// </summary>
		[JsonProperty("permission")]
		public KeyboardActionPermission Permission { get; set; }

		/// <summary>
		/// （必填）操作相关的数据
		/// </summary>
		[JsonProperty("data")]
		public string Data { get; set; }

		/// <summary>
		/// 指令按钮可用，指令是否带引用回复本消息，默认 false。支持版本 8983
		/// </summary>
		[JsonProperty("reply")]
		public bool Reply { get; set; }

		/// <summary>
		/// 指令按钮可用，点击按钮后直接自动发送 data，默认 false。支持版本 8983
		/// </summary>
		[JsonProperty("enter")]
		public bool Enter { get; set; }

		/// <summary>
		/// 本字段仅在指令按钮下有效，设置后后会忽略 action.enter 配置。
		/// 设置为 1 时 ，点击按钮自动唤起启手Q选图器，其他值暂无效果。
		/// （仅支持手机端版本 8983+ 的单聊场景，桌面端不支持）
		/// </summary>
		[JsonProperty("anchor")]
		public int Anchor { get; set; }

		/// <summary>
		/// 客户端不支持本action的时候，弹出的toast文案
		/// </summary>
		[JsonProperty("unsupport_tips")]
		public string UnsupportTips { get; set; }
	}

	/// <summary>
	/// 消息按钮操作权限
	/// </summary>
	public class KeyboardActionPermission
	{
		/// <summary>
		/// （必填）0 指定用户可操作，1 仅管理者可操作，2 所有人可操作，3 指定身份组可操作（仅频道可用）
		/// </summary>
		[JsonProperty("type")]
		public int Type { get; set; }

		/// <summary>
		/// （非必填）有权限的用户 id 的列表
		/// </summary>
		[JsonProperty("specify_user_ids")]
		public List<string> SpecifyUserIds { get; set; }

		/// <summary>
		/// （非必填）有权限的身份组 id 的列表（仅频道可用）
		/// </summary>
		[JsonProperty("specify_role_ids")]
		public List<string> SpecifyRoleIds { get; set; }
	}
}
