using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Zhipster.Internal.Api.Data.Data;
using Zhipster.Internal.Api.Data.Models;
using Zhipster.Internal.Api.Location.Models;

namespace Zhipster.Internal.Api.Location.Services.SourceService
{
	public class CreateSourceService : ICreateSourceService
	{
		private readonly ZhipsterLocationDbContext _zhipsterLocationDbContext;

		public CreateSourceService(ZhipsterLocationDbContext _zhipsterLocationDbContext)
		{
			this._zhipsterLocationDbContext = _zhipsterLocationDbContext;
		}

		public async Task CreateSource(SourceInformation source)
		{
			var localSource = await _zhipsterLocationDbContext.ZipCodeSources.Where(x => x.ZipCodeSourceId == source.SourceId).FirstOrDefaultAsync();
			if (localSource == null)
			{
				localSource = new ZipCodeSource
				{
					ZipCodeSourceId = source.SourceId,
					APILink = source.APILink,
					CountryCode = source.CountryCode,
					CreatedDate = DateTime.Now,
					LastChangedDate = DateTime.Now,
					SourceName = source.SourceName
				};
				await _zhipsterLocationDbContext.ZipCodeSources.AddAsync(localSource);
				await _zhipsterLocationDbContext.SaveChangesAsync();
			}
		}
	}
}