using Makabaka.Events;
using Makabaka.Messages;
using System.Text;
using System.Text.Json;

namespace Makabaka.Test
{
	internal partial class Program
	{
		private static Task OnPrivateMessage(object sender, PrivateMessageEventArgs e)
		{
			return e.Message.ToString() switch
			{
				"联系人测试" => e.ReplyAsync([new ContactSegment(ContactType.Qq, e.Sender.UserId)]),
				_ => HandleMessage(e.Message, e.MessageId, e.Context, e),
			};
		}

		private static Task OnGroupMessage(object sender, GroupMessageEventArgs e)
		{
			return e.Message.ToString() switch
			{
				"At测试" => e.ReplyAsync([new AtSegment(e.Sender!.UserId)]),
				"联系人测试" => e.ReplyAsync([new ContactSegment(ContactType.Group, e.GroupId)]),
				_ => HandleMessage(e.Message, e.MessageId, e.Context, e),
			};
		}

		private static readonly JsonSerializerOptions _jsonSerializerDisplayOptions = new()
		{
			WriteIndented = true,
		};

		private static async Task HandleMessage(Message message, long messageId, IBotContext botContext, IReply reply)
		{
			switch (message.ToString())
			{
				/* ===== 段消息测试 ===== */

				case "骰子测试":
					await reply.ReplyAsync([new DiceSegment()]);
					break;
				case "表情测试":
					await reply.ReplyAsync([new FaceSegment("14")]);
					break;
				case "文本测试":
					await reply.ReplyAsync([new TextSegment("测试")]);
					break;
				case "转发测试":
					
					break;
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
					break;
				case "戳一戳测试":
					await reply.ReplyAsync([new PokeSegment("1", "-1")]);
					break;
				case "回复测试":
					await reply.ReplyAsync([new ReplySegment(messageId), new TextSegment("回复测试")]);
					break;
				case "图片测试":
					await reply.ReplyAsync([ImageSegment.FromFile("test.png")]);
					break;

				/* ===== API 测试 ===== */

				case "撤回消息测试":
					{
						var data = (await reply.ReplyAsync([new TextSegment("撤回测试")])).Result;
						await Task.Delay(3000);
						await botContext.RevokeMessageAsync(data.MessageId);
					}
					break;
				case "获取消息测试":
					{
						var data = (await botContext.GetMessageAsync(messageId)).Result;
						await reply.ReplyAsync([new TextSegment(JsonSerializer.Serialize(data, _jsonSerializerDisplayOptions))]);
					}
					break;

				default:
					break;
			}
		}
	}
}
