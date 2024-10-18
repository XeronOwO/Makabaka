using Makabaka.Exceptions;
using System;
using System.Text.Json.Serialization;

namespace Makabaka.API
{
	/// <summary>
	/// API 响应
	/// </summary>
	public class APIResponse
	{
		/// <summary>
		/// 状态
		/// </summary>
		public string Status { get; set; } = string.Empty;

		/// <summary>
		/// 返回值
		/// </summary>
		public long Retcode { get; set; }

		/// <summary>
		/// 用于唯一标识一次请求
		/// </summary>
		public Guid Echo { get; set; } = Guid.Empty;

		/// <summary>
		/// 确保请求成功
		/// </summary>
		/// <exception cref="APIException"></exception>
		public virtual void EnsureSuccess()
		{
			if (Retcode != 0)
			{
				throw new APIException(Status, Retcode, Echo);
			}
		}
	}

	/// <summary>
	/// API 响应
	/// </summary>
	/// <typeparam name="T">响应参数类型</typeparam>
	public class APIResponse<T> : APIResponse
	{
		/// <summary>
		/// 响应数据
		/// </summary>
		public T? Data { get; set; }

		/// <summary>
		/// 获取响应结果，确保请求成功且不为空
		/// </summary>
		/// <exception cref="APIException"></exception>
		/// <exception cref="APIResponseDataNullException"></exception>
		[JsonIgnore]
		public T Result
		{
			get
			{
				EnsureSuccess();
				return Data ?? throw new APIResponseDataNullException(Echo);
			}
		}

		/// <inheritdoc/>
		/// <exception cref="APIResponseDataNullException"></exception>
		public override void EnsureSuccess()
		{
			base.EnsureSuccess();

			if (Data == null)
			{
				throw new APIResponseDataNullException(Echo);
			}
		}
	}
}
