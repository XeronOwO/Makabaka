using Makabaka.Events;

namespace Makabaka.Test
{
	internal partial class Program
	{
		private static async Task OnFriendAddRequest(object sender, FriendAddRequestEventArgs e)
		{
			await e.AcceptAsync();
		}
	}
}
