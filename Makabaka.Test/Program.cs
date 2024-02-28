using Makabaka.Configurations;
using Makabaka.Models.EventArgs;
using Makabaka.Models.Messages;
using Makabaka.Services;
using Newtonsoft.Json;
using Serilog;

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
			service.OnGroupRequest += OnGroupRequest;

			// 启动服务
			await service.StartAsync();
			Console.ReadLine();
			await service.StopAsync();
		}

		private static async void OnGroupRequest(object? sender, GroupRequestEventArgs e)
		{
			await e.AcceptAsync();
		}

		private static async void OnGroupMessage(object? sender, GroupMessageEventArgs e)
		{
			if (e.Message == "测试")
			{
				await e.ReplyAsync(new TextSegment("耶！"));
			}
			if (e.Message == "私聊测试")
			{
				await e.Session.SendPrivateMessageAsync(e.UserId, new TextSegment("私聊测试！"));
			}
			if (e.Message == "表情测试")
			{
				await e.ReplyAsync(new FaceSegment(0));
			}
			if (e.Message == "At测试")
			{
				await e.ReplyAsync([new AtSegment(e.Sender.UserId), new TextSegment("测试！")]);
			}
			if (e.Message == "图片测试")
			{
				//await e.Reply(new ImageSegment("base64://iVBORw0KGgoAAAANSUhEUgAAABQAAAAVCAIAAADJt1n/AAAAKElEQVQ4EWPk5+RmIBcwkasRpG9UM4mhNxpgowFGMARGEwnBIEJVAAAdBgBNAZf+QAAAAABJRU5ErkJggg=="));
				await e.ReplyAsync(ImageSegment.FromLocalFile("test.png"));
			}
		}
	}
}
