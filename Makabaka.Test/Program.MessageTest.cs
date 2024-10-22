using Makabaka.Events;
using Makabaka.Messages;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Makabaka.Test
{
	internal partial class Program
	{
		private static async Task OnPrivateMessage(object sender, PrivateMessageEventArgs e)
		{
			try
			{
				await OnPrivateMessageInternal(sender, e);
			}
			catch (Exception ex)
			{
				await e.ReplyAsync([new TextSegment(ex.Message)]);
			}
		}
		
		private static Task OnPrivateMessageInternal(object sender, PrivateMessageEventArgs e)
		{
			return e.Message.ToString() switch
			{
				"联系人测试" => e.ReplyAsync([new ContactSegment(ContactType.QQ, e.Sender.UserId)]),
				_ => HandleMessageAsync(e.Message, e.MessageId, e.Context, e),
			};
		}

		private static async Task OnGroupMessage(object sender, GroupMessageEventArgs e)
		{
			try
			{
				await OnGroupMessageInternal(sender, e);
			}
			catch (Exception ex)
			{
				await e.ReplyAsync([new TextSegment(ex.Message)]);
			}
		}

		private static async Task OnGroupMessageInternal(object sender, GroupMessageEventArgs e)
		{
			switch (e.Message.ToString())
			{
				case "At测试":
					await e.ReplyAsync([new AtSegment(e.Sender!.UserId)]);
					return;
				case "联系人测试":
					await e.ReplyAsync([new ContactSegment(ContactType.Group, e.GroupId)]);
					return;
				case "群禁言测试":
					await e.Context.MuteGroupAsync(e.GroupId, true);
					await Task.Delay(3000);
					await e.Context.MuteGroupAsync(e.GroupId, false);
					return;
				case "设置群名测试":
					await e.Context.SetGroupNameAsync(e.GroupId, "测试群名");
					return;
				case "退群测试":
					await e.Context.LeaveGroupAsync(e.GroupId);
					return;
				case "获取群成员列表测试":
					{
						var members = (await e.Context.GetGroupMemberListAsync(e.GroupId)).Result;
						var sb = new StringBuilder();
						foreach (var member in members)
						{
							sb.Append('[')
								.Append(member.UserId)
								.Append("] ")
								.AppendLine(member.Nickname);
						}
						await e.ReplyAsync([new TextSegment(sb.ToString())]);
					}
					return;
				case "获取群荣誉信息测试":
					{
						var data = (await e.Context.GetGroupHonorInfoAsync(e.GroupId)).Result;
						await e.ReplyAsync([new TextSegment(JsonSerializer.Serialize(data, _jsonSerializerDisplayOptions))]);
					}
					return;
				case "上传群文件测试":
					{
						var fileInfo = new FileInfo("test.png");
						var response = await e.Context.UploadGroupFileAsync(e.GroupId, fileInfo.FullName);
						await e.ReplyAsync([new TextSegment(JsonSerializer.Serialize(response, _jsonSerializerDisplayOptions))]);
					}
					return;
				default:
					break;
			}

			var match = GetGroupFilesTestRegex().Match(e.Message.ToString());
			if (match.Success)
			{
				string? folder = null;
				var folderGroup = match.Groups["folder"];
				if (folderGroup.Success)
				{
					folder = folderGroup.Value;
				}
				var data = (await e.Context.GetGroupFilesByFolderAsync(e.GroupId, folder)).Result;
				await e.ReplyAsync([new TextSegment(JsonSerializer.Serialize(data, _jsonSerializerDisplayOptions))]);
				return;
			}

			match = GetGroupFileUrlTestRegex().Match(e.Message.ToString());
			if (match.Success)
			{
				var file = match.Groups["file"].Value;
				var bus = uint.Parse(match.Groups["bus"].Value);
				var data = (await e.Context.GetGroupFileUrlAsync(e.GroupId, file, bus)).Result;
				await e.ReplyAsync([new TextSegment(JsonSerializer.Serialize(data, _jsonSerializerDisplayOptions))]);
				return;
			}

			match = MoveGroupFileTestRegex().Match(e.Message.ToString());
			if (match.Success)
			{
				var file = match.Groups["file"].Value;
				var src = match.Groups["src"].Value;
				var dst = match.Groups["dst"].Value;
				var data = (await e.Context.MoveGroupFileAsync(e.GroupId, file, src, dst)).Result;
				await e.ReplyAsync([new TextSegment(JsonSerializer.Serialize(data, _jsonSerializerDisplayOptions))]);
				return;
			}

			match = DeleteGroupFileTestRegex().Match(e.Message.ToString());
			if (match.Success)
			{
				var file = match.Groups["file"].Value;
				var data = (await e.Context.DeleteGroupFileAsync(e.GroupId, file)).Result;
				await e.ReplyAsync([new TextSegment(JsonSerializer.Serialize(data, _jsonSerializerDisplayOptions))]);
				return;
			}

			match = CreateGroupFolderTestRegex().Match(e.Message.ToString());
			if (match.Success)
			{
				var file = match.Groups["name"].Value;
				var parent = match.Groups["parent"].Value;
				var data = (await e.Context.CreateGroupFolderAsync(e.GroupId, file, parent)).Result;
				await e.ReplyAsync([new TextSegment(JsonSerializer.Serialize(data, _jsonSerializerDisplayOptions))]);
				return;
			}

			await HandleMessageAsync(e.Message, e.MessageId, e.Context, e);
		}

		[GeneratedRegex(@"^获取群文件测试( (?<folder>[\S]+))?$", RegexOptions.Compiled)]
		private static partial Regex GetGroupFilesTestRegex();

		[GeneratedRegex(@"^获取群文件URL测试 (?<file>[\S]+) (?<bus>[\S]+)$", RegexOptions.Compiled)]
		private static partial Regex GetGroupFileUrlTestRegex();

		[GeneratedRegex(@"^移动群文件测试 (?<file>[\S]+) (?<src>[\S]+) (?<dst>[\S]+)$", RegexOptions.Compiled)]
		private static partial Regex MoveGroupFileTestRegex();

		[GeneratedRegex(@"^删除群文件测试 (?<file>[\S]+)$", RegexOptions.Compiled)]
		private static partial Regex DeleteGroupFileTestRegex();

		[GeneratedRegex(@"^创建群文件夹测试 (?<name>[\S]+) (?<parent>[\S]+)$", RegexOptions.Compiled)]
		private static partial Regex CreateGroupFolderTestRegex();

		private static readonly JsonSerializerOptions _jsonSerializerDisplayOptions = new()
		{
			WriteIndented = true,
			PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
			Converters =
			{
				new JsonStringEnumConverter(JsonNamingPolicy.SnakeCaseLower)
			},
			Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
		};

		private static async Task HandleMessageAsync(Message message, long messageId, IBotContext botContext, IMessageHandler reply)
		{
			switch (message.ToString())
			{
				/* ===== 段消息测试 ===== */

				case "骰子测试":
					await reply.ReplyAsync([new DiceSegment()]);
					return;
				case "表情测试":
					await reply.ReplyAsync([new FaceSegment("14")]);
					return;
				case "文本测试":
					await reply.ReplyAsync([new TextSegment("测试")]);
					return;
				case "转发测试":

					return;
				case "商城表情测试":
					var emojiId = "f9af2410431e5ee59d7087ada014cdb3";
					var keys = await botContext.FetchMarketFaceKeyAsync([emojiId]);
					if (keys.Data == null)
					{
						await reply.ReplyAsync([new TextSegment("获取商城表情密钥失败")]);
						return;
					}
					if (keys.Data.Length == 0)
					{
						await reply.ReplyAsync([new TextSegment("获取的商城表情密钥为空")]);
						return;
					}
					await reply.ReplyAsync([new MarketFaceSegment(
						"https://gxh.vip.qq.com/club/item/parcel/item/f9/f9af2410431e5ee59d7087ada014cdb3/raw300.gif",
						235308,
						emojiId,
						keys.Data.First(),
						"[测试]"
						)]);
					return;
				case "戳一戳测试":
					await reply.ReplyAsync([new PokeSegment("1", "-1")]);
					return;
				case "回复测试":
					await reply.ReplyAsync([new ReplySegment(messageId), new TextSegment("回复测试")]);
					return;
				case "图片测试":
					await reply.ReplyAsync([ImageSegment.FromFile("test.png")]);
					return;

				/* ===== API 测试 ===== */

				case "撤回消息测试":
					{
						var data = (await reply.ReplyAsync([new TextSegment("撤回测试")])).Result;
						await Task.Delay(3000);
						await botContext.RevokeMessageAsync(data.MessageId);
					}
					return;
				case "获取消息测试":
					{
						var data = (await botContext.GetMessageAsync(messageId)).Result;
						await reply.ReplyAsync([new TextSegment(JsonSerializer.Serialize(data, _jsonSerializerDisplayOptions))]);
					}
					return;
				case "获取登录信息测试":
					{
						var data = (await botContext.GetLoginInfoAsync()).Result;
						await reply.ReplyAsync([new TextSegment(JsonSerializer.Serialize(data, _jsonSerializerDisplayOptions))]);
					}
					return;
				case "获取好友列表测试":
					{
						var friends = (await botContext.GetFriendListAsync()).Result;
						var sb = new StringBuilder();
						foreach (var friend in friends)
						{
							sb.Append('[')
								.Append(friend.UserId)
								.Append("] ");
							if (string.IsNullOrEmpty(friend.Remark))
							{
								sb.AppendLine(friend.Nickname);
							}
							else
							{
								sb.AppendLine(friend.Remark);
							}
						}
						await reply.ReplyAsync([new TextSegment(sb.ToString())]);
					}
					return;
				case "获取群列表测试":
					{
						var groups = (await botContext.GetGroupListAsync()).Result;
						var sb = new StringBuilder();
						foreach (var group in groups)
						{
							sb.Append('[')
								.Append(group.GroupId)
								.Append("] ")
								.AppendLine(group.GroupName);
						}
						await reply.ReplyAsync([new TextSegment(sb.ToString())]);
					}
					return;
				case "获取CSRFToken测试":
					{
						var data = (await botContext.GetCsrfTokenAsync()).Result;
						await reply.ReplyAsync([new TextSegment(JsonSerializer.Serialize(data, _jsonSerializerDisplayOptions))]);
					}
					return;
				case "检查是否可以发送图片测试":
					{
						var data = (await botContext.CanSendImageAsync()).Result;
						await reply.ReplyAsync([new TextSegment(JsonSerializer.Serialize(data, _jsonSerializerDisplayOptions))]);
					}
					return;
				case "检查是否可以发送语音测试":
					{
						var data = (await botContext.CanSendRecordAsync()).Result;
						await reply.ReplyAsync([new TextSegment(JsonSerializer.Serialize(data, _jsonSerializerDisplayOptions))]);
					}
					return;
				case "获取运行状态测试":
					{
						var data = (await botContext.GetStatusAsync()).Result;
						await reply.ReplyAsync([new TextSegment(JsonSerializer.Serialize(data, _jsonSerializerDisplayOptions))]);
					}
					return;
				case "获取版本信息测试":
					{
						var data = (await botContext.GetVersionInfoAsync()).Result;
						await reply.ReplyAsync([new TextSegment(JsonSerializer.Serialize(data, _jsonSerializerDisplayOptions))]);
					}
					return;
				case "重启测试":
					{
						var response = await botContext.RestartAsync();
						await reply.ReplyAsync([new TextSegment(JsonSerializer.Serialize(response, _jsonSerializerDisplayOptions))]);
					}
					return;
				case "上传图片测试":
					{
						var url = (await botContext.UploadImageAsync(ImageSegment.FromFile("test.png").Data.File)).Result;
						await reply.ReplyAsync([new TextSegment(url)]);
					}
					return;

				default:
					break;
			}

			var match = GetStrangerInfoTestRegex().Match(message.ToString());
			if (match.Success)
			{
				var user = long.Parse(match.Groups["user"].Value);
				var data = (await botContext.GetStrangerInfoAsync(user)).Result;
				await reply.ReplyAsync([new TextSegment(JsonSerializer.Serialize(data, _jsonSerializerDisplayOptions))]);
				return;
			}

			match = GetGroupInfoTestRegex().Match(message.ToString());
			if (match.Success)
			{
				var group = long.Parse(match.Groups["group"].Value);
				var data = (await botContext.GetGroupInfoAsync(group)).Result;
				await reply.ReplyAsync([new TextSegment(JsonSerializer.Serialize(data, _jsonSerializerDisplayOptions))]);
				return;
			}

			match = GetGroupMemberInfoTestRegex().Match(message.ToString());
			if (match.Success)
			{
				var group = long.Parse(match.Groups["group"].Value);
				var user = long.Parse(match.Groups["user"].Value);
				var data = (await botContext.GetGroupMemberInfoAsync(group, user, true)).Result;
				await reply.ReplyAsync([new TextSegment(JsonSerializer.Serialize(data, _jsonSerializerDisplayOptions))]);
				return;
			}
		}

		[GeneratedRegex(@"^获取陌生人信息测试 (?<user>[0-9]+)$", RegexOptions.Compiled)]
		private static partial Regex GetStrangerInfoTestRegex();

		[GeneratedRegex(@"^获取群信息测试 (?<group>[0-9]+)$", RegexOptions.Compiled)]
		private static partial Regex GetGroupInfoTestRegex();

		[GeneratedRegex(@"^获取群成员信息测试 (?<group>[0-9]+) (?<user>[0-9]+)$", RegexOptions.Compiled)]
		private static partial Regex GetGroupMemberInfoTestRegex();
	}
}
