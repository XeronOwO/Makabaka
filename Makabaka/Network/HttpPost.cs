using Makabaka.Configurations;
using Makabaka.Services;
using Makabaka.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using WatsonWebserver;

namespace Makabaka.Network
{
	internal class HttpPost : ISession
	{
		#region 构造函数与参数

		private readonly HttpPostServiceConfig _config;

		private readonly HttpContext _context;

		private readonly Guid _guid;

		public Guid Guid => _guid;

		private readonly DataProcessor _dataProcessor;

		public HttpPost(HttpPostService service, HttpContext context, Guid guid, HttpPostServiceConfig config)
		{
			_context = context;
			_guid = guid;
			_dataProcessor = new(service, this);
			_config = config;
		}

		#endregion
	}
}
