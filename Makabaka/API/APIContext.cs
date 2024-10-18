using System;
using System.Threading.Tasks;

namespace Makabaka.API
{
	internal class APIContext(APIRequest request, Type responseType)
	{
		public APIRequest Request { get; } = request;

		public Type ResponseType { get; } = responseType;

		public TaskCompletionSource<APIResponse> ResponseTaskCompletionSource { get; } = new();
	}

	internal class APIContext<T>(APIRequest request)
		: APIContext(request, typeof(T))
		where T : APIResponse
	{
	}
}
