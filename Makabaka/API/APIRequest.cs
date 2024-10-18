using System;

namespace Makabaka.API
{
	/// <summary>
	/// API 请求
	/// </summary>
	/// <param name="Action">用于指定要调用的 API</param>
	internal record class APIRequest(
		string Action
		)
	{
		/// <summary>
		/// 用于唯一标识一次请求
		/// </summary>
		public Guid Echo { get; init; } = Guid.NewGuid();
	}

	/// <summary>
	/// API 请求
	/// </summary>
	/// <typeparam name="T">请求参数类型</typeparam>
	/// <param name="Action">用于指定要调用的 API</param>
	/// <param name="Params">用于传入参数</param>
	internal record class APIRequest<T>(
		string Action,
		T? Params
		) : APIRequest(Action);
}
