using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;
using Zhipster.Internal.Api.Data.Data;

namespace Zhipster.Internal.Api.Location.Controllers
{
	[ApiExplorerSettings(IgnoreApi = true)]
	[ApiController]
	[Route("[controller]")]
	public class AdminController
	{
		private readonly IConfiguration _configuration;
		private readonly ZhipsterLocationDbContext _zhipsterLocationDbContext;

		public AdminController(IConfiguration configuration, ZhipsterLocationDbContext zhipsterLocationDbContext)
		{
			_configuration = configuration;
			_zhipsterLocationDbContext = zhipsterLocationDbContext;
		}

		[HttpGet("")]
		public async Task<string> Get()
		{
			var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
			var comittIdAndDate = GetCommittIdAndPublishDate();

			var apiInformation = $"{environment} - {comittIdAndDate}";

			return apiInformation;
		}

		private string GetCommittIdAndPublishDate()
		{
			var comittIdAndDate = string.Empty;

			try
			{
				var gitInfoFilePath = AppDomain.CurrentDomain.BaseDirectory + "/git-info.user";

				comittIdAndDate = File.ReadAllText(gitInfoFilePath).Replace("\n", "");
				var file2Info = new FileInfo(gitInfoFilePath);
				comittIdAndDate += " - " + file2Info.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
			}
			catch
			{
			}

			return comittIdAndDate;
		}
	}
}
