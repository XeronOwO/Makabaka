using Makabaka.Configurations;
using Makabaka.Models.API.Responses;
using Makabaka.Models.EventArgs;
using Makabaka.Models.Messages;
using Makabaka.Services;
using Newtonsoft.Json;
using Serilog;
using System.Text;
using System.Web;

namespace Makabaka.Test
{
	internal class Program
	{
		private const string ConfigPath = "config.json";

		static async Task Main(string[] args)
		{
			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Verbose()
				.WriteTo.Console()
				.CreateLogger(); // 配置日志

			// 加载配置
			ForwardWebSocketServiceConfig? config = null;
			if (File.Exists(ConfigPath))
			{
				config = JsonConvert.DeserializeObject<ForwardWebSocketServiceConfig>(File.ReadAllText(ConfigPath));
			}
			config ??= new();
			File.WriteAllText(ConfigPath, JsonConvert.SerializeObject(config, Formatting.Indented));

			// 初始化服务
			var service = ServiceFactory.CreateForwardWebSocketService(config);
			service.OnGroupMessage += OnGroupMessage;
			service.OnPrivateMessage += OnPrivateMessage;
			service.OnGroupRequest += OnGroupRequest;
			service.OnGroupFileUpload += OnGroupFileUpload;

			// 启动服务
			await service.StartAsync();
			Console.ReadLine();
			await service.StopAsync();
		}

		private static async void OnGroupFileUpload(object? sender, GroupFileUploadEventArgs e)
		{
			await e.ReplyAsync(new TextSegment($"接收到文件事件：{e.File.Name}"));
		}

		private static async void OnGroupRequest(object? sender, GroupRequestEventArgs e)
		{
			await e.AcceptAsync(); // 有群请求，直接同意
		}

		private static async void OnPrivateMessage(object? sender, PrivateMessageEventArgs e)
		{
			if (e.Message == "测试")
			{
				await e.ReplyAsync(new TextSegment("耶！"));
			}
			else if (e.Message == "回复测试")
			{
				await e.ReplyAsync([new ReplySegment(e.MessageId), new TextSegment("回复测试！")]);
			}
			else if (e.Message == "获取好友历史消息记录测试")
			{
				GetFriendMsgHistoryRes res = await e.Context.GetFriendMsgHistoryAsync(e.UserId, e.MessageId, 5);
				var sb = new StringBuilder();
				foreach (var message in res.Messages)
				{
					sb.Append('[');
					sb.Append(message.Sender.UserId);
					sb.Append(']');
					sb.Append(message.Sender.NickName);
					sb.Append(": ");
					sb.Append(message.Message);
					sb.AppendLine();
				}
				await e.ReplyAsync(new TextSegment(sb.ToString()));
			}
		}

		private static async void OnGroupMessage(object? sender, GroupMessageEventArgs e)
		{
			if (e.Message == "测试")
			{
				await e.ReplyAsync(new TextSegment("耶！"));
			}
			else if (e.Message == "私聊测试")
			{
				await e.Context.SendPrivateMessageAsync(e.UserId, new TextSegment("私聊测试！"));
			}
			else if (e.Message == "表情测试")
			{
				await e.ReplyAsync(new FaceSegment(0));
			}
			else if (e.Message == "At测试")
			{
				await e.ReplyAsync([new AtSegment(e.Sender.UserId), new TextSegment(" 测试！")]);
			}
			else if (e.Message == "图片测试")
			{
				//await e.Reply(new ImageSegment("base64://iVBORw0KGgoAAAANSUhEUgAAABQAAAAVCAIAAADJt1n/AAAAKElEQVQ4EWPk5+RmIBcwkasRpG9UM4mhNxpgowFGMARGEwnBIEJVAAAdBgBNAZf+QAAAAABJRU5ErkJggg=="));
				await e.ReplyAsync(ImageSegment.FromLocalFile("test.png"));
			}
			else if (e.Message == "转发测试")
			{
				string resid = await e.Context.SendForwardMessageAsync([new NodeSegment(e.SelfId, string.Empty, new TextSegment("转发测试！"))]);
				await e.ReplyAsync(new ForwardSegment(resid));
			}
			else if (e.Message == "回复测试")
			{
				await e.ReplyAsync([new ReplySegment(e.MessageId), new TextSegment("回复测试！")]);
			}
			else if (e.Message == "MarkDown测试")
			{
				var md = new MarkDownSegment(JsonConvert.SerializeObject(new
				{
					#region 内容太长，折叠
					content =
$@"# 一号标题
## 二号标题
正文
**加粗**
__下划线加粗__
_斜体_
*星号斜体*
***加粗斜体***
~~删除线~~
欢迎来到：[🔗腾讯网](https://www.qq.com)
文档可以访问<https://doc.qq.com>

![text #208px #320px](https://resource5-1255303497.cos.ap-guangzhou.myqcloud.com/abcmouse_word_watch/markdown/building.png)

# 有序列表
1. 新人降落桃源岛的欢迎仪式
2. 阳光准则助力建设有温度的频道
3. 岛民分享吹水纳凉

# 无序列表
- 新人降落桃源岛的欢迎仪式
- 阳光准则助力建设有温度的频道
- 岛民分享吹水纳凉

# 有序列表标题
1. 嵌套一层
	- 列表前是普通文本，则需要在列表前用空行隔开，否则无法识别
	- 如果是段落标签比如标题，则无需用空行隔开
2. 嵌套二层
	1. 我是有序列表，二级列表前面需要空4个空格
	2. 无序列表和有序列表可以相互嵌套，但是不建议无限制嵌套。

> 青青子衿，悠悠我心，但为君故，沉吟至今
> 四月维夏，六月徂暑。先祖匪人，胡宁忍予
> 秋日凄凄，百卉具腓。乱离瘼矣，爰其适归？
诗经《小雅》

这是段落1
***
这是段落2

第一行

第二行

\u200B
\u200B
第三行

[/回车指令](mqqapi://aio/inlinecmd?command={HttpUtility.UrlEncode("/回车指令")}&reply=false&enter=true)"
					#endregion
				}));

				string resid = await e.Context.SendForwardMessageAsync([new NodeSegment(e.SelfId, string.Empty, md)]);
				await e.ReplyAsync(new LongMsgSegment(resid));
			}
			else if (e.Message == "按钮测试")
			{
				var md = new MarkDownSegment(JsonConvert.SerializeObject(new
				{
					content = "按钮测试！",
				}));
				var kb = new KeyboardSegment(new KeyboardData
				{
					#region 内容太长，折叠
					Content = new KeyboardContent
					{
						Rows =
						[
							new KeyboardRow
							{
								Buttons =
								[
									new KeyboardButton
									{
										Id = "1",
										RenderData = new KeyboardRenderData
										{
											Label = "⬅️上一页",
											VisitedLabel = "⬅️上一页",
										},
										Action = new KeyboardAction
										{
											Type = 1,
											Permission = new KeyboardActionPermission
											{
												Type = 2,
											},
											Data = "data",
											UnsupportTips = "兼容文本",
										},
									},
									new KeyboardButton
									{
										Id = "2",
										RenderData = new KeyboardRenderData
										{
											Label = "➡️下一页",
											VisitedLabel = "➡️下一页",
										},
										Action = new KeyboardAction
										{
											Type = 1,
											Permission = new KeyboardActionPermission
											{
												Type = 2,
											},
											Data = "data",
											UnsupportTips = "兼容文本",
										},
									},
								]
							},
							new KeyboardRow
							{
								Buttons =
								[
									new KeyboardButton
									{
										Id = "3",
										RenderData = new KeyboardRenderData
										{
											Label = "📅 打卡（5）",
											VisitedLabel = "📅 打卡（5）",
										},
										Action = new KeyboardAction
										{
											Type = 1,
											Permission = new KeyboardActionPermission
											{
												Type = 2,
											},
											Data = "data",
											UnsupportTips = "兼容文本",
										},
									},
								]
							},
						]
					}
					#endregion
				});

				string resid = await e.Context.SendForwardMessageAsync([new NodeSegment(e.SelfId, string.Empty, [md, kb])]);
				await e.ReplyAsync(new LongMsgSegment(resid));
			}
			else if (e.Message == "获取收藏表情测试")
			{
				List<string> faces = await e.Context.FetchCustomFaceAsync();
				await e.ReplyAsync(new TextSegment(string.Join("\n", faces)));
			}
			else if (e.Message == "获取群组历史消息记录测试")
			{
				GetGroupMsgHistoryRes res = await e.Context.GetGroupMsgHistoryAsync(e.GroupId, e.MessageId, 5);
				var sb = new StringBuilder();
				foreach (var message in res.Messages)
				{
					sb.Append('[');
					sb.Append(message.UserId);
					sb.Append("]: ");
					sb.Append(message.Message);
					sb.AppendLine();
				}
				await e.ReplyAsync(new TextSegment(sb.ToString()));
			}
			else if(e.Message == "上传群文件测试")
			{
				await e.Context.UploadGroupFileAsync(e.GroupId, "Fleck.dll", "Fleck.dll");
			}
		}
	}
}
