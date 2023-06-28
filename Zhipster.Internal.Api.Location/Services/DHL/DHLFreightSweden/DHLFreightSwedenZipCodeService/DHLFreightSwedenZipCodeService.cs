using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using Zhipster.Internal.Api.Data.Data;
using Zhipster.Internal.Api.Location.Models.DHLFreightSweden;
using Zhipster.Internal.Api.Location.Services.SourceService;
using Newtonsoft.Json;
using System.Linq;
using Zhipster.Internal.Api.Location.Helpers;
using EFCore.BulkExtensions;
using Zhipster.Internal.Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Zhipster.Internal.Api.Location.Services.DHL.DHLFreightSweden.DHLFreightSwedenZipCodeService
{
	public class DHLFreightSwedenZipCodeService : IDHLFreightSwedenZipCodeService
	{
		private readonly ZhipsterLocationDbContext _zhipsterLocationDbContext;
		private readonly ICreateSourceService _createSourceService;

		public DHLFreightSwedenZipCodeService(ZhipsterLocationDbContext zhipsterLocationDbContext, ICreateSourceService createSourceService)
		{
			_zhipsterLocationDbContext = zhipsterLocationDbContext;
			_createSourceService = createSourceService;
		}

		public async Task<bool> InstallZipCodes()
		{
			await InstallDHLFreightSweden();

			return false;
		}

		private async Task InstallDHLFreightSweden()
		{
			await _createSourceService.CreateSource(ZipCodeSourceHelper.DHLFreightSESource);

			var databaseZipCodeListToInsertDHL = new List<SEZipCode>();

			var boxZipCodesDHL = await GetZipCodesFromApiAsyncDHL();

			if (boxZipCodesDHL.Any())
			{
				foreach (var postalCode in boxZipCodesDHL)
				{
					var newZipCode = new SEZipCode
					{
						County = string.Empty,
						Municipality = string.Empty,
						City = FirstLetterIsCapitalHelper.MakeFirstLetterBig(postalCode.City) ?? string.Empty,
						LatitudeY = string.Empty,
						LongitudeX = string.Empty,
						IsTypeBox = false,
						ZipCodeSourceId = ZipCodeSourceHelper.DHLFreightSESource.SourceId,
						CreatedDate = DateTime.Now,
						ZipCode = postalCode.PostalCode,
						SEZipCodeId = Guid.NewGuid(),
						RoutingCode = postalCode.LineHaul,
						TerminalID = postalCode.TerminalId,
						IsManuallyAddedZipCode = false,
					};

					databaseZipCodeListToInsertDHL.Add(newZipCode);
				}
			}

			if (databaseZipCodeListToInsertDHL.Any())
			{
				await _zhipsterLocationDbContext.SEZipCodes.Where(x => x.ZipCodeSourceId == ZipCodeSourceHelper.DHLFreightSESource.SourceId && x.IsManuallyAddedZipCode == false).BatchDeleteAsync();

				var municipalities = await _zhipsterLocationDbContext.SEZipCodes.Where(x => x.Municipality != "").Select(x => new { x.ZipCode, x.Municipality }).Distinct().ToListAsync();

				foreach (var zipCode in databaseZipCodeListToInsertDHL)
				{
					var municipalityName = municipalities.Where(x => x.ZipCode == zipCode.ZipCode).Select(x => x.Municipality).FirstOrDefault();

					if (!string.IsNullOrWhiteSpace(municipalityName))
					{
						zipCode.Municipality = municipalityName;
					}
				}

				var counties = await _zhipsterLocationDbContext.SEZipCodes.Where(x => x.County != "").Select(x => new { x.ZipCode, x.County }).Distinct().ToListAsync();

				foreach (var zipCode in databaseZipCodeListToInsertDHL)
				{
					var countyName = counties.Where(x => x.ZipCode == zipCode.ZipCode).Select(x => x.County).FirstOrDefault();

					if (!string.IsNullOrWhiteSpace(countyName))
					{
						zipCode.County = countyName;
					}
				}

				await _zhipsterLocationDbContext.BulkInsertAsync(databaseZipCodeListToInsertDHL);

				await _zhipsterLocationDbContext.ZipCodeSources.Where(z => z.ZipCodeSourceId == ZipCodeSourceHelper.DHLFreightSESource.SourceId).BatchUpdateAsync(new ZipCodeSource
				{
					LastChangedDate = DateTime.Now,
					SourceRecordCount = databaseZipCodeListToInsertDHL.Count
				});
			}
		}

		private async Task<List<ZipCode>> GetZipCodesFromApiAsyncDHL()
		{
			var dhlFreightPostalCodes = new List<ZipCode>();

			try
			{
				var username = "client-key";
				var password = "";
				var baseUrl = "https://api.freight-logistics.dhl.com/postalcodeapi/v1/postalcodes/se/updated";

				var client = new HttpClient
				{
					BaseAddress = new Uri(baseUrl)
				};
				client.DefaultRequestHeaders.Add(username, password);
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
				var cutOffDate = DateTime.Parse("1900-01-01");
				var apiHttpResult = await client.GetAsync(client.BaseAddress + "?fromDate=" + cutOffDate.ToString("yyyy-MM-dd"));

				if (apiHttpResult.IsSuccessStatusCode)
				{
					var json = await apiHttpResult.Content.ReadAsStringAsync();
					var zipCodes = JsonConvert.DeserializeObject<DHLFreightSwedenPostalCodesResponseJSON>(json);

					if (zipCodes != null && zipCodes.Data != null && zipCodes.Data.Any())
					{
						dhlFreightPostalCodes.AddRange(zipCodes.Data);
					}
				}
			}

			catch (Exception ex)
			{
				await Console.Out.WriteLineAsync(ex.Message);
			}

			return dhlFreightPostalCodes;
		}
	}
}