using EFCore.BulkExtensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Zhipster.Internal.Api.Data.Data;
using Zhipster.Internal.Api.Data.Models;
using Zhipster.Internal.Api.Location.Helpers;
using Sylvan.Data.Csv;
using Zhipster.Internal.Api.Location.Services.SourceService;
using Zhipster.Internal.Api.Location.Models;
using Microsoft.EntityFrameworkCore;

namespace Zhipster.Internal.Api.Location.Services.DSVRoadSwedenZipCodeService
{
	public class DSVRoadSwedenZipCodeService : IDSVRoadSwedenZipCodeService
	{
		private readonly ZhipsterLocationDbContext _zhipsterLocationDbContext;
		private readonly ICreateSourceService _createSourceService;

		public DSVRoadSwedenZipCodeService(ZhipsterLocationDbContext zhipsterLocationDbContext, ICreateSourceService createSourceService)
		{
			_zhipsterLocationDbContext = zhipsterLocationDbContext;
			_createSourceService = createSourceService;
		}

		public async Task<bool> InstallZipCodes()
		{
			await InstallSE();

			return false;
		}

		private async Task<List<SEZipCode>> GetZipCodesFromFileAsync(SourceInformation source)
		{
			var listOfZipCodes = new List<SEZipCode>();

			try
			{
				var csv = CsvDataReader.Create("d:\\DSV_STE_Dver20220325.csv");

				while (await csv.ReadAsync())
				{
					var zipCode = csv.GetString(0);
					//	var isDangerousGoodsCompatible = csv.GetString(1);
					var routingCode = "SE-" + csv.GetString(2) + csv.GetString(3);

					var localZipCode = new SEZipCode
					{
						City = "",
						County = "",
						CreatedDate = DateTime.Now,
						IsTypeBox = false,
						LatitudeY = "",
						LongitudeX = "",
						Municipality = "",
						TerminalID = "",
						RoutingCode = routingCode,
						ZipCode = zipCode,
						SEZipCodeId = Guid.NewGuid(),
						ZipCodeSourceId = source.SourceId,
						IsManuallyAddedZipCode = false,
					};

					listOfZipCodes.Add(localZipCode);
				}
			}
			catch (Exception ex)
			{
				await Console.Out.WriteLineAsync(ex.Message);
			}

			return listOfZipCodes;
		}

		private async Task InstallSE()
		{
			await this._createSourceService.CreateSource(ZipCodeSourceHelper.DSVRoadSESource);

			var databaseZipCodeListToInsertSE = await GetZipCodesFromFileAsync(ZipCodeSourceHelper.DSVRoadSESource);

			if (databaseZipCodeListToInsertSE.Any())
			{
				await _zhipsterLocationDbContext.SEZipCodes.Where(x => x.ZipCodeSourceId == ZipCodeSourceHelper.DSVRoadSESource.SourceId && x.IsManuallyAddedZipCode == false).BatchDeleteAsync();

				var cities = await _zhipsterLocationDbContext.SEZipCodes.Where(x => x.City != "").Select(x => new { x.ZipCode, x.City }).Distinct().ToListAsync();

				foreach (var zipCode in databaseZipCodeListToInsertSE)
				{
					var cityName = cities.Where(x => x.ZipCode == zipCode.ZipCode).Select(x => x.City).FirstOrDefault();

					if (!string.IsNullOrWhiteSpace(cityName))
					{
						zipCode.City = cityName;
					}
				}

				var municipalities = await _zhipsterLocationDbContext.SEZipCodes.Where(x => x.Municipality != "").Select(x => new { x.ZipCode, x.Municipality }).Distinct().ToListAsync();

				foreach (var zipCode in databaseZipCodeListToInsertSE)
				{
					var municipalityName = municipalities.Where(x => x.ZipCode == zipCode.ZipCode).Select(x => x.Municipality).FirstOrDefault();

					if (!string.IsNullOrWhiteSpace(municipalityName))
					{
						zipCode.Municipality = municipalityName;
					}
				}

				var counties = await _zhipsterLocationDbContext.SEZipCodes.Where(x => x.County != "").Select(x => new { x.ZipCode, x.County }).Distinct().ToListAsync();

				foreach (var zipCode in databaseZipCodeListToInsertSE)
				{
					var countyName = counties.Where(x => x.ZipCode == zipCode.ZipCode).Select(x => x.County).FirstOrDefault();

					if (!string.IsNullOrWhiteSpace(countyName))
					{
						zipCode.County = countyName;
					}
				}

				var latitudes = await _zhipsterLocationDbContext.SEZipCodes.Where(x => x.LatitudeY != "").Select(x => new { x.ZipCode, x.LatitudeY }).Distinct().ToListAsync();

				foreach (var zipCode in databaseZipCodeListToInsertSE)
				{
					var latitudeCoordinates = latitudes.Where(x => x.ZipCode == zipCode.ZipCode).Select(x => x.LatitudeY).FirstOrDefault();

					if (!string.IsNullOrWhiteSpace(latitudeCoordinates))
					{
						zipCode.LatitudeY = latitudeCoordinates;
					}
				}

				var longitudes = await _zhipsterLocationDbContext.SEZipCodes.Where(x => x.LongitudeX != "").Select(x => new { x.ZipCode, x.LongitudeX }).Distinct().ToListAsync();

				foreach (var zipCode in databaseZipCodeListToInsertSE)
				{
					var longitudeCoordinates = longitudes.Where(x => x.ZipCode == zipCode.ZipCode).Select(x => x.LongitudeX).FirstOrDefault();

					if (!string.IsNullOrWhiteSpace(longitudeCoordinates))
					{
						zipCode.LongitudeX = longitudeCoordinates;
					}
				}

				await _zhipsterLocationDbContext.BulkInsertAsync(databaseZipCodeListToInsertSE);

				await _zhipsterLocationDbContext.ZipCodeSources.Where(z => z.ZipCodeSourceId == ZipCodeSourceHelper.DSVRoadSESource.SourceId).BatchUpdateAsync(new ZipCodeSource
				{
					LastChangedDate = DateTime.Now,
					SourceRecordCount = databaseZipCodeListToInsertSE.Count
				});
			}
		}
	}
}