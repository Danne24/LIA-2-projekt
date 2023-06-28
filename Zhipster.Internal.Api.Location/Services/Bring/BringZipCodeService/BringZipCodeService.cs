using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using Zhipster.Internal.Api.Data.Data;
using Zhipster.Internal.Api.Test.Models.Bring;
using System.Collections.Generic;
using Zhipster.Internal.Api.Data.Models;
using EFCore.BulkExtensions;
using Zhipster.Internal.Api.Location.Helpers;
using Zhipster.Internal.Api.Location.Models;
using Zhipster.Internal.Api.Location.Services.SourceService;

namespace Zhipster.Internal.Api.Location.Services.Bring.BringZipCodeService
{
	public class BringZipCodeService : IBringZipCodeService
	{
		private readonly ZhipsterLocationDbContext _zhipsterLocationDbContext;
		private readonly ICreateSourceService _createSourceService;

		public BringZipCodeService(ZhipsterLocationDbContext zhipsterLocationDbContext, ICreateSourceService createSourceService)
		{
			_zhipsterLocationDbContext = zhipsterLocationDbContext;
			_createSourceService = createSourceService;
		}

		public async Task<bool> InstallZipCodes()
		{
			await InstallSE();

			await InstallNO();

			await InstallDK();

			await InstallFI();

			await InstallNL();

			await InstallDE();

			await InstallUS();

			await InstallBE();

			await InstallFO();

			await InstallGL();

			await InstallIS();

			await InstallSJ();

			return false;
		}

		private async Task InstallFI()
		{
			await _createSourceService.CreateSource(ZipCodeSourceHelper.BringFISource);

			var databaseZipCodeListToInsertFI = new List<FIZipCode>();

			var boxZipCodesFI = await GetZipCodesFromApiAsync(true, ZipCodeSourceHelper.BringFISource);

			if (boxZipCodesFI.Any())
			{
				foreach (var postalCode in boxZipCodesFI)
				{
					var newZipCode = new FIZipCode
					{
						County = postalCode.County ?? string.Empty,
						Municipality = postalCode.Municipality ?? string.Empty,
						City = postalCode.City ?? string.Empty,
						LatitudeY = postalCode.Latitude ?? string.Empty,
						LongitudeX = postalCode.Longitude ?? string.Empty,
						IsTypeBox = postalCode.PoBox,
						ZipCodeSourceId = ZipCodeSourceHelper.BringFISource.SourceId,
						CreatedDate = DateTime.Now,
						ZipCode = postalCode.ZipCode.ToString(),
						FIZipCodeId = Guid.NewGuid(),
						RoutingCode = string.Empty,
						TerminalID = string.Empty,
						IsManuallyAddedZipCode = false,
					};

					databaseZipCodeListToInsertFI.Add(newZipCode);
				}
			}

			var zipCodesFI = await GetZipCodesFromApiAsync(false, ZipCodeSourceHelper.BringFISource);

			if (zipCodesFI.Any())
			{
				foreach (var postalCode in zipCodesFI)
				{
					var newZipCode = new FIZipCode
					{
						County = postalCode.County ?? string.Empty,
						Municipality = postalCode.Municipality ?? string.Empty,
						City = postalCode.City ?? string.Empty,
						LatitudeY = postalCode.Latitude ?? string.Empty,
						LongitudeX = postalCode.Longitude ?? string.Empty,
						IsTypeBox = postalCode.PoBox,
						ZipCodeSourceId = ZipCodeSourceHelper.BringFISource.SourceId,
						CreatedDate = DateTime.Now,
						ZipCode = postalCode.ZipCode.ToString(),
						FIZipCodeId = Guid.NewGuid(),
						RoutingCode = string.Empty,
						TerminalID = string.Empty,
						IsManuallyAddedZipCode = false,
					};

					databaseZipCodeListToInsertFI.Add(newZipCode);
				}
			}

			if (databaseZipCodeListToInsertFI.Any())
			{
				await _zhipsterLocationDbContext.FIZipCodes.Where(x => x.ZipCodeSourceId == ZipCodeSourceHelper.BringFISource.SourceId && x.IsManuallyAddedZipCode == false).BatchDeleteAsync();

				await _zhipsterLocationDbContext.BulkInsertAsync(databaseZipCodeListToInsertFI);

				await _zhipsterLocationDbContext.ZipCodeSources.Where(z => z.ZipCodeSourceId == ZipCodeSourceHelper.BringFISource.SourceId).BatchUpdateAsync(new ZipCodeSource
				{
					LastChangedDate = DateTime.Now,
					SourceRecordCount = databaseZipCodeListToInsertFI.Count
				});
			}
		}

		private async Task InstallDK()
		{
			await _createSourceService.CreateSource(ZipCodeSourceHelper.BringDKSource);

			var databaseZipCodeListToInsertDK = new List<DKZipCode>();

			var boxZipCodesDK = await GetZipCodesFromApiAsync(true, ZipCodeSourceHelper.BringDKSource);

			if (boxZipCodesDK.Any())
			{
				foreach (var postalCode in boxZipCodesDK)
				{
					var newZipCode = new DKZipCode
					{
						County = postalCode.County ?? string.Empty,
						Municipality = postalCode.Municipality ?? string.Empty,
						City = postalCode.City ?? string.Empty,
						LatitudeY = postalCode.Latitude ?? string.Empty,
						LongitudeX = postalCode.Longitude ?? string.Empty,
						IsTypeBox = postalCode.PoBox,
						ZipCodeSourceId = ZipCodeSourceHelper.BringDKSource.SourceId,
						CreatedDate = DateTime.Now,
						ZipCode = postalCode.ZipCode.ToString(),
						DKZipCodeId = Guid.NewGuid(),
						RoutingCode = string.Empty,
						TerminalID = string.Empty,
						IsManuallyAddedZipCode = false,
					};

					databaseZipCodeListToInsertDK.Add(newZipCode);
				}
			}

			var zipCodesDK = await GetZipCodesFromApiAsync(false, ZipCodeSourceHelper.BringDKSource);

			if (zipCodesDK.Any())
			{
				foreach (var postalCode in zipCodesDK)
				{
					var newZipCode = new DKZipCode
					{
						County = postalCode.County ?? string.Empty,
						Municipality = postalCode.Municipality ?? string.Empty,
						City = postalCode.City ?? string.Empty,
						LatitudeY = postalCode.Latitude ?? string.Empty,
						LongitudeX = postalCode.Longitude ?? string.Empty,
						IsTypeBox = postalCode.PoBox,
						ZipCodeSourceId = ZipCodeSourceHelper.BringDKSource.SourceId,
						CreatedDate = DateTime.Now,
						ZipCode = postalCode.ZipCode.ToString(),
						DKZipCodeId = Guid.NewGuid(),
						RoutingCode = string.Empty,
						TerminalID = string.Empty,
						IsManuallyAddedZipCode = false,
					};

					databaseZipCodeListToInsertDK.Add(newZipCode);
				}
			}

			if (databaseZipCodeListToInsertDK.Any())
			{
				await _zhipsterLocationDbContext.DKZipCodes.Where(x => x.ZipCodeSourceId == ZipCodeSourceHelper.BringDKSource.SourceId && x.IsManuallyAddedZipCode == false).BatchDeleteAsync();

				await _zhipsterLocationDbContext.BulkInsertAsync(databaseZipCodeListToInsertDK);

				await _zhipsterLocationDbContext.ZipCodeSources.Where(z => z.ZipCodeSourceId == ZipCodeSourceHelper.BringDKSource.SourceId).BatchUpdateAsync(new ZipCodeSource
				{
					LastChangedDate = DateTime.Now,
					SourceRecordCount = databaseZipCodeListToInsertDK.Count
				});
			}
		}

		private async Task InstallNO()
		{
			await _createSourceService.CreateSource(ZipCodeSourceHelper.BringNOSource);

			var databaseZipCodeListToInsertNO = new List<NOZipCode>();

			var boxZipCodesNO = await GetZipCodesFromApiAsync(true, ZipCodeSourceHelper.BringNOSource);

			if (boxZipCodesNO.Any())
			{
				foreach (var postalCode in boxZipCodesNO)
				{
					var newZipCode = new NOZipCode
					{
						County = postalCode.County ?? string.Empty,
						Municipality = postalCode.Municipality ?? string.Empty,
						City = postalCode.City ?? string.Empty,
						LatitudeY = postalCode.Latitude ?? string.Empty,
						LongitudeX = postalCode.Longitude ?? string.Empty,
						IsTypeBox = postalCode.PoBox,
						ZipCodeSourceId = ZipCodeSourceHelper.BringNOSource.SourceId,
						CreatedDate = DateTime.Now,
						ZipCode = postalCode.ZipCode.ToString(),
						NOZipCodeId = Guid.NewGuid(),
						RoutingCode = string.Empty,
						TerminalID = string.Empty,
						IsManuallyAddedZipCode = false,
					};

					databaseZipCodeListToInsertNO.Add(newZipCode);
				}
			}

			var zipCodesNO = await GetZipCodesFromApiAsync(false, ZipCodeSourceHelper.BringNOSource);

			if (zipCodesNO.Any())
			{
				foreach (var postalCode in zipCodesNO)
				{
					var newZipCode = new NOZipCode
					{
						County = postalCode.County ?? string.Empty,
						Municipality = postalCode.Municipality ?? string.Empty,
						City = postalCode.City ?? string.Empty,
						LatitudeY = postalCode.Latitude ?? string.Empty,
						LongitudeX = postalCode.Longitude ?? string.Empty,
						IsTypeBox = postalCode.PoBox,
						ZipCodeSourceId = ZipCodeSourceHelper.BringNOSource.SourceId,
						CreatedDate = DateTime.Now,
						ZipCode = postalCode.ZipCode.ToString(),
						NOZipCodeId = Guid.NewGuid(),
						RoutingCode = string.Empty,
						TerminalID = string.Empty,
						IsManuallyAddedZipCode = false,
					};

					databaseZipCodeListToInsertNO.Add(newZipCode);
				}
			}

			if (databaseZipCodeListToInsertNO.Any())
			{
				await _zhipsterLocationDbContext.NOZipCodes.Where(x => x.ZipCodeSourceId == ZipCodeSourceHelper.BringNOSource.SourceId && x.IsManuallyAddedZipCode == false).BatchDeleteAsync();

				await _zhipsterLocationDbContext.BulkInsertAsync(databaseZipCodeListToInsertNO);

				await _zhipsterLocationDbContext.ZipCodeSources.Where(z => z.ZipCodeSourceId == ZipCodeSourceHelper.BringNOSource.SourceId).BatchUpdateAsync(new ZipCodeSource
				{
					LastChangedDate = DateTime.Now,
					SourceRecordCount = databaseZipCodeListToInsertNO.Count
				});
			}
		}

		private async Task InstallSE()
		{
			await _createSourceService.CreateSource(ZipCodeSourceHelper.BringSESource);

			var databaseZipCodeListToInsertSE = new List<SEZipCode>();

			var boxZipCodesSE = await GetZipCodesFromApiAsync(true, ZipCodeSourceHelper.BringSESource);

			if (boxZipCodesSE.Any())
			{
				foreach (var postalCode in boxZipCodesSE)
				{
					var newZipCode = new SEZipCode
					{
						County = postalCode.County ?? string.Empty,
						Municipality = postalCode.Municipality ?? string.Empty,
						City = postalCode.City ?? string.Empty,
						LatitudeY = postalCode.Latitude ?? string.Empty,
						LongitudeX = postalCode.Longitude ?? string.Empty,
						IsTypeBox = postalCode.PoBox,
						ZipCodeSourceId = ZipCodeSourceHelper.BringSESource.SourceId,
						CreatedDate = DateTime.Now,
						ZipCode = postalCode.ZipCode.ToString(),
						SEZipCodeId = Guid.NewGuid(),
						RoutingCode = string.Empty,
						TerminalID = string.Empty,
						IsManuallyAddedZipCode = false,
					};

					databaseZipCodeListToInsertSE.Add(newZipCode);
				}
			}

			var zipCodesSE = await GetZipCodesFromApiAsync(false, ZipCodeSourceHelper.BringSESource);

			if (zipCodesSE.Any())
			{
				foreach (var postalCode in zipCodesSE)
				{
					var newZipCode = new SEZipCode
					{
						County = postalCode.County ?? string.Empty,
						Municipality = postalCode.Municipality ?? string.Empty,
						City = postalCode.City ?? string.Empty,
						LatitudeY = postalCode.Latitude ?? string.Empty,
						LongitudeX = postalCode.Longitude ?? string.Empty,
						IsTypeBox = postalCode.PoBox,
						ZipCodeSourceId = ZipCodeSourceHelper.BringSESource.SourceId,
						CreatedDate = DateTime.Now,
						ZipCode = postalCode.ZipCode.ToString(),
						SEZipCodeId = Guid.NewGuid(),
						RoutingCode = string.Empty,
						TerminalID = string.Empty,
						IsManuallyAddedZipCode = false,
					};

					databaseZipCodeListToInsertSE.Add(newZipCode);
				}
			}

			if (databaseZipCodeListToInsertSE.Any())
			{
				await _zhipsterLocationDbContext.SEZipCodes.Where(x => x.ZipCodeSourceId == ZipCodeSourceHelper.BringSESource.SourceId && x.IsManuallyAddedZipCode == false).BatchDeleteAsync();

				await _zhipsterLocationDbContext.BulkInsertAsync(databaseZipCodeListToInsertSE);

				await _zhipsterLocationDbContext.ZipCodeSources.Where(z => z.ZipCodeSourceId == ZipCodeSourceHelper.BringSESource.SourceId).BatchUpdateAsync(new ZipCodeSource
				{
					LastChangedDate = DateTime.Now,
					SourceRecordCount = databaseZipCodeListToInsertSE.Count
				});
			}
		}

		private async Task InstallNL()
		{
			await _createSourceService.CreateSource(ZipCodeSourceHelper.BringNLSource);

			var databaseZipCodeListToInsertNL = new List<NLZipCode>();

			var boxZipCodesNL = await GetZipCodesFromApiAsync(true, ZipCodeSourceHelper.BringNLSource);

			if (boxZipCodesNL.Any())
			{
				foreach (var postalCode in boxZipCodesNL)
				{
					var newZipCode = new NLZipCode
					{
						County = postalCode.County ?? string.Empty,
						Municipality = postalCode.Municipality ?? string.Empty,
						City = postalCode.City ?? string.Empty,
						LatitudeY = postalCode.Latitude ?? string.Empty,
						LongitudeX = postalCode.Longitude ?? string.Empty,
						IsTypeBox = postalCode.PoBox,
						ZipCodeSourceId = ZipCodeSourceHelper.BringNLSource.SourceId,
						CreatedDate = DateTime.Now,
						ZipCode = postalCode.ZipCode.ToString(),
						NLZipCodeId = Guid.NewGuid(),
						RoutingCode = string.Empty,
						TerminalID = string.Empty,
						IsManuallyAddedZipCode = false,
					};

					databaseZipCodeListToInsertNL.Add(newZipCode);
				}
			}

			var zipCodesNL = await GetZipCodesFromApiAsync(false, ZipCodeSourceHelper.BringNLSource);

			if (zipCodesNL.Any())
			{
				foreach (var postalCode in zipCodesNL)
				{
					var newZipCode = new NLZipCode
					{
						County = postalCode.County ?? string.Empty,
						Municipality = postalCode.Municipality ?? string.Empty,
						City = postalCode.City ?? string.Empty,
						LatitudeY = postalCode.Latitude ?? string.Empty,
						LongitudeX = postalCode.Longitude ?? string.Empty,
						IsTypeBox = postalCode.PoBox,
						ZipCodeSourceId = ZipCodeSourceHelper.BringNLSource.SourceId,
						CreatedDate = DateTime.Now,
						ZipCode = postalCode.ZipCode.ToString(),
						NLZipCodeId = Guid.NewGuid(),
						RoutingCode = string.Empty,
						TerminalID = string.Empty,
						IsManuallyAddedZipCode = false,
					};

					databaseZipCodeListToInsertNL.Add(newZipCode);
				}
			}

			if (databaseZipCodeListToInsertNL.Any())
			{
				await _zhipsterLocationDbContext.NLZipCodes.Where(x => x.ZipCodeSourceId == ZipCodeSourceHelper.BringNLSource.SourceId && x.IsManuallyAddedZipCode == false).BatchDeleteAsync();

				await _zhipsterLocationDbContext.BulkInsertAsync(databaseZipCodeListToInsertNL);

				await _zhipsterLocationDbContext.ZipCodeSources.Where(z => z.ZipCodeSourceId == ZipCodeSourceHelper.BringNLSource.SourceId).BatchUpdateAsync(new ZipCodeSource
				{
					LastChangedDate = DateTime.Now,
					SourceRecordCount = databaseZipCodeListToInsertNL.Count
				});
			}
		}

		private async Task InstallDE()
		{
			await _createSourceService.CreateSource(ZipCodeSourceHelper.BringDESource);

			var databaseZipCodeListToInsertDE = new List<DEZipCode>();

			var boxZipCodesDE = await GetZipCodesFromApiAsync(true, ZipCodeSourceHelper.BringDESource);

			if (boxZipCodesDE.Any())
			{
				foreach (var postalCode in boxZipCodesDE)
				{
					var newZipCode = new DEZipCode
					{
						County = postalCode.County ?? string.Empty,
						Municipality = postalCode.Municipality ?? string.Empty,
						City = postalCode.City ?? string.Empty,
						LatitudeY = postalCode.Latitude ?? string.Empty,
						LongitudeX = postalCode.Longitude ?? string.Empty,
						IsTypeBox = postalCode.PoBox,
						ZipCodeSourceId = ZipCodeSourceHelper.BringDESource.SourceId,
						CreatedDate = DateTime.Now,
						ZipCode = postalCode.ZipCode.ToString(),
						DEZipCodeId = Guid.NewGuid(),
						RoutingCode = string.Empty,
						TerminalID = string.Empty,
						IsManuallyAddedZipCode = false,
					};

					databaseZipCodeListToInsertDE.Add(newZipCode);
				}
			}

			var zipCodesDE = await GetZipCodesFromApiAsync(false, ZipCodeSourceHelper.BringDESource);

			if (zipCodesDE.Any())
			{
				foreach (var postalCode in zipCodesDE)
				{
					var newZipCode = new DEZipCode
					{
						County = postalCode.County ?? string.Empty,
						Municipality = postalCode.Municipality ?? string.Empty,
						City = postalCode.City ?? string.Empty,
						LatitudeY = postalCode.Latitude ?? string.Empty,
						LongitudeX = postalCode.Longitude ?? string.Empty,
						IsTypeBox = postalCode.PoBox,
						ZipCodeSourceId = ZipCodeSourceHelper.BringDESource.SourceId,
						CreatedDate = DateTime.Now,
						ZipCode = postalCode.ZipCode.ToString(),
						DEZipCodeId = Guid.NewGuid(),
						RoutingCode = string.Empty,
						TerminalID = string.Empty,
						IsManuallyAddedZipCode = false,
					};

					databaseZipCodeListToInsertDE.Add(newZipCode);
				}
			}

			if (databaseZipCodeListToInsertDE.Any())
			{
				await _zhipsterLocationDbContext.DEZipCodes.Where(x => x.ZipCodeSourceId == ZipCodeSourceHelper.BringDESource.SourceId && x.IsManuallyAddedZipCode == false).BatchDeleteAsync();

				await _zhipsterLocationDbContext.BulkInsertAsync(databaseZipCodeListToInsertDE);

				await _zhipsterLocationDbContext.ZipCodeSources.Where(z => z.ZipCodeSourceId == ZipCodeSourceHelper.BringDESource.SourceId).BatchUpdateAsync(new ZipCodeSource
				{
					LastChangedDate = DateTime.Now,
					SourceRecordCount = databaseZipCodeListToInsertDE.Count
				});
			}
		}

		private async Task InstallUS()
		{
			await _createSourceService.CreateSource(ZipCodeSourceHelper.BringUSSource);

			var databaseZipCodeListToInsertUS = new List<USZipCode>();

			var boxZipCodesUS = await GetZipCodesFromApiAsync(true, ZipCodeSourceHelper.BringUSSource);

			if (boxZipCodesUS.Any())
			{
				foreach (var postalCode in boxZipCodesUS)
				{
					var newZipCode = new USZipCode
					{
						County = postalCode.County ?? string.Empty,
						StateCode = USStateCodeHelper.USStateCode(postalCode.County),
						Municipality = postalCode.Municipality ?? string.Empty,
						City = postalCode.City ?? string.Empty,
						LatitudeY = postalCode.Latitude ?? string.Empty,
						LongitudeX = postalCode.Longitude ?? string.Empty,
						IsTypeBox = postalCode.PoBox,
						ZipCodeSourceId = ZipCodeSourceHelper.BringUSSource.SourceId,
						CreatedDate = DateTime.Now,
						ZipCode = postalCode.ZipCode.ToString(),
						USZipCodeId = Guid.NewGuid(),
						RoutingCode = string.Empty,
						TerminalID = string.Empty,
						IsManuallyAddedZipCode = false,
					};

					databaseZipCodeListToInsertUS.Add(newZipCode);
				}
			}

			var zipCodesUS = await GetZipCodesFromApiAsync(false, ZipCodeSourceHelper.BringUSSource);

			if (zipCodesUS.Any())
			{
				foreach (var postalCode in zipCodesUS)
				{
					var newZipCode = new USZipCode
					{
						County = postalCode.County ?? string.Empty,
						StateCode = USStateCodeHelper.USStateCode(postalCode.County),
						Municipality = postalCode.Municipality ?? string.Empty,
						City = postalCode.City ?? string.Empty,
						LatitudeY = postalCode.Latitude ?? string.Empty,
						LongitudeX = postalCode.Longitude ?? string.Empty,
						IsTypeBox = postalCode.PoBox,
						ZipCodeSourceId = ZipCodeSourceHelper.BringUSSource.SourceId,
						CreatedDate = DateTime.Now,
						ZipCode = postalCode.ZipCode.ToString(),
						USZipCodeId = Guid.NewGuid(),
						RoutingCode = string.Empty,
						TerminalID = string.Empty,
						IsManuallyAddedZipCode = false,
					};

					databaseZipCodeListToInsertUS.Add(newZipCode);
				}
			}

			if (databaseZipCodeListToInsertUS.Any())
			{
				await _zhipsterLocationDbContext.USZipCodes.Where(x => x.ZipCodeSourceId == ZipCodeSourceHelper.BringUSSource.SourceId && x.IsManuallyAddedZipCode == false).BatchDeleteAsync();

				await _zhipsterLocationDbContext.BulkInsertAsync(databaseZipCodeListToInsertUS);

				await _zhipsterLocationDbContext.ZipCodeSources.Where(z => z.ZipCodeSourceId == ZipCodeSourceHelper.BringUSSource.SourceId).BatchUpdateAsync(new ZipCodeSource
				{
					LastChangedDate = DateTime.Now,
					SourceRecordCount = databaseZipCodeListToInsertUS.Count
				});
			}
		}

		private async Task InstallBE()
		{
			await _createSourceService.CreateSource(ZipCodeSourceHelper.BringBESource);

			var databaseZipCodeListToInsertBE = new List<BEZipCode>();

			var boxZipCodesBE = await GetZipCodesFromApiAsync(true, ZipCodeSourceHelper.BringBESource);

			if (boxZipCodesBE.Any())
			{
				foreach (var postalCode in boxZipCodesBE)
				{
					var newZipCode = new BEZipCode
					{
						County = postalCode.County ?? string.Empty,
						Municipality = postalCode.Municipality ?? string.Empty,
						City = postalCode.City ?? string.Empty,
						LatitudeY = postalCode.Latitude ?? string.Empty,
						LongitudeX = postalCode.Longitude ?? string.Empty,
						IsTypeBox = postalCode.PoBox,
						ZipCodeSourceId = ZipCodeSourceHelper.BringBESource.SourceId,
						CreatedDate = DateTime.Now,
						ZipCode = postalCode.ZipCode.ToString(),
						BEZipCodeId = Guid.NewGuid(),
						RoutingCode = string.Empty,
						TerminalID = string.Empty,
						IsManuallyAddedZipCode = false,
					};

					databaseZipCodeListToInsertBE.Add(newZipCode);
				}
			}

			var zipCodesBE = await GetZipCodesFromApiAsync(false, ZipCodeSourceHelper.BringBESource);

			if (zipCodesBE.Any())
			{
				foreach (var postalCode in zipCodesBE)
				{
					var newZipCode = new BEZipCode
					{
						County = postalCode.County ?? string.Empty,
						Municipality = postalCode.Municipality ?? string.Empty,
						City = postalCode.City ?? string.Empty,
						LatitudeY = postalCode.Latitude ?? string.Empty,
						LongitudeX = postalCode.Longitude ?? string.Empty,
						IsTypeBox = postalCode.PoBox,
						ZipCodeSourceId = ZipCodeSourceHelper.BringBESource.SourceId,
						CreatedDate = DateTime.Now,
						ZipCode = postalCode.ZipCode.ToString(),
						BEZipCodeId = Guid.NewGuid(),
						RoutingCode = string.Empty,
						TerminalID = string.Empty,
						IsManuallyAddedZipCode = false,
					};

					databaseZipCodeListToInsertBE.Add(newZipCode);
				}
			}

			if (databaseZipCodeListToInsertBE.Any())
			{
				await _zhipsterLocationDbContext.BEZipCodes.Where(x => x.ZipCodeSourceId == ZipCodeSourceHelper.BringBESource.SourceId && x.IsManuallyAddedZipCode == false).BatchDeleteAsync();

				await _zhipsterLocationDbContext.BulkInsertAsync(databaseZipCodeListToInsertBE);

				await _zhipsterLocationDbContext.ZipCodeSources.Where(z => z.ZipCodeSourceId == ZipCodeSourceHelper.BringBESource.SourceId).BatchUpdateAsync(new ZipCodeSource
				{
					LastChangedDate = DateTime.Now,
					SourceRecordCount = databaseZipCodeListToInsertBE.Count
				});
			}
		}

		private async Task InstallFO()
		{
			await _createSourceService.CreateSource(ZipCodeSourceHelper.BringFOSource);

			var databaseZipCodeListToInsertFO = new List<FOZipCode>();

			var boxZipCodesFO = await GetZipCodesFromApiAsync(true, ZipCodeSourceHelper.BringFOSource);

			if (boxZipCodesFO.Any())
			{
				foreach (var postalCode in boxZipCodesFO)
				{
					var newZipCode = new FOZipCode
					{
						County = postalCode.County ?? string.Empty,
						Municipality = postalCode.Municipality ?? string.Empty,
						City = postalCode.City ?? string.Empty,
						LatitudeY = postalCode.Latitude ?? string.Empty,
						LongitudeX = postalCode.Longitude ?? string.Empty,
						IsTypeBox = postalCode.PoBox,
						ZipCodeSourceId = ZipCodeSourceHelper.BringFOSource.SourceId,
						CreatedDate = DateTime.Now,
						ZipCode = postalCode.ZipCode.ToString(),
						FOZipCodeId = Guid.NewGuid(),
						RoutingCode = string.Empty,
						TerminalID = string.Empty,
						IsManuallyAddedZipCode = false,
					};

					databaseZipCodeListToInsertFO.Add(newZipCode);
				}
			}

			var zipCodesFO = await GetZipCodesFromApiAsync(false, ZipCodeSourceHelper.BringFOSource);

			if (zipCodesFO.Any())
			{
				foreach (var postalCode in zipCodesFO)
				{
					var newZipCode = new FOZipCode
					{
						County = postalCode.County ?? string.Empty,
						Municipality = postalCode.Municipality ?? string.Empty,
						City = postalCode.City ?? string.Empty,
						LatitudeY = postalCode.Latitude ?? string.Empty,
						LongitudeX = postalCode.Longitude ?? string.Empty,
						IsTypeBox = postalCode.PoBox,
						ZipCodeSourceId = ZipCodeSourceHelper.BringFOSource.SourceId,
						CreatedDate = DateTime.Now,
						ZipCode = postalCode.ZipCode.ToString(),
						FOZipCodeId = Guid.NewGuid(),
						RoutingCode = string.Empty,
						TerminalID = string.Empty,
						IsManuallyAddedZipCode = false,
					};

					databaseZipCodeListToInsertFO.Add(newZipCode);
				}
			}

			if (databaseZipCodeListToInsertFO.Any())
			{
				await _zhipsterLocationDbContext.FOZipCodes.Where(x => x.ZipCodeSourceId == ZipCodeSourceHelper.BringFOSource.SourceId && x.IsManuallyAddedZipCode == false).BatchDeleteAsync();

				await _zhipsterLocationDbContext.BulkInsertAsync(databaseZipCodeListToInsertFO);

				await _zhipsterLocationDbContext.ZipCodeSources.Where(z => z.ZipCodeSourceId == ZipCodeSourceHelper.BringFOSource.SourceId).BatchUpdateAsync(new ZipCodeSource
				{
					LastChangedDate = DateTime.Now,
					SourceRecordCount = databaseZipCodeListToInsertFO.Count
				});
			}
		}

		private async Task InstallGL()
		{
			await _createSourceService.CreateSource(ZipCodeSourceHelper.BringGLSource);

			var databaseZipCodeListToInsertGL = new List<GLZipCode>();

			var boxZipCodesGL = await GetZipCodesFromApiAsync(true, ZipCodeSourceHelper.BringGLSource);

			if (boxZipCodesGL.Any())
			{
				foreach (var postalCode in boxZipCodesGL)
				{
					var newZipCode = new GLZipCode
					{
						County = postalCode.County ?? string.Empty,
						Municipality = postalCode.Municipality ?? string.Empty,
						City = postalCode.City ?? string.Empty,
						LatitudeY = postalCode.Latitude ?? string.Empty,
						LongitudeX = postalCode.Longitude ?? string.Empty,
						IsTypeBox = postalCode.PoBox,
						ZipCodeSourceId = ZipCodeSourceHelper.BringGLSource.SourceId,
						CreatedDate = DateTime.Now,
						ZipCode = postalCode.ZipCode.ToString(),
						GLZipCodeId = Guid.NewGuid(),
						RoutingCode = string.Empty,
						TerminalID = string.Empty,
						IsManuallyAddedZipCode = false,
					};

					databaseZipCodeListToInsertGL.Add(newZipCode);
				}
			}

			var zipCodesGL = await GetZipCodesFromApiAsync(false, ZipCodeSourceHelper.BringGLSource);

			if (zipCodesGL.Any())
			{
				foreach (var postalCode in zipCodesGL)
				{
					var newZipCode = new GLZipCode
					{
						County = postalCode.County ?? string.Empty,
						Municipality = postalCode.Municipality ?? string.Empty,
						City = postalCode.City ?? string.Empty,
						LatitudeY = postalCode.Latitude ?? string.Empty,
						LongitudeX = postalCode.Longitude ?? string.Empty,
						IsTypeBox = postalCode.PoBox,
						ZipCodeSourceId = ZipCodeSourceHelper.BringGLSource.SourceId,
						CreatedDate = DateTime.Now,
						ZipCode = postalCode.ZipCode.ToString(),
						GLZipCodeId = Guid.NewGuid(),
						RoutingCode = string.Empty,
						TerminalID = string.Empty,
						IsManuallyAddedZipCode = false,
					};

					databaseZipCodeListToInsertGL.Add(newZipCode);
				}
			}

			if (databaseZipCodeListToInsertGL.Any())
			{
				await _zhipsterLocationDbContext.GLZipCodes.Where(x => x.ZipCodeSourceId == ZipCodeSourceHelper.BringGLSource.SourceId && x.IsManuallyAddedZipCode == false).BatchDeleteAsync();

				await _zhipsterLocationDbContext.BulkInsertAsync(databaseZipCodeListToInsertGL);

				await _zhipsterLocationDbContext.ZipCodeSources.Where(z => z.ZipCodeSourceId == ZipCodeSourceHelper.BringGLSource.SourceId).BatchUpdateAsync(new ZipCodeSource
				{
					LastChangedDate = DateTime.Now,
					SourceRecordCount = databaseZipCodeListToInsertGL.Count
				});
			}
		}

		private async Task InstallIS()
		{
			await _createSourceService.CreateSource(ZipCodeSourceHelper.BringISSource);

			var databaseZipCodeListToInsertIS = new List<ISZipCode>();

			var boxZipCodesIS = await GetZipCodesFromApiAsync(true, ZipCodeSourceHelper.BringISSource);

			if (boxZipCodesIS.Any())
			{
				foreach (var postalCode in boxZipCodesIS)
				{
					var newZipCode = new ISZipCode
					{
						County = postalCode.County ?? string.Empty,
						Municipality = postalCode.Municipality ?? string.Empty,
						City = postalCode.City ?? string.Empty,
						LatitudeY = postalCode.Latitude ?? string.Empty,
						LongitudeX = postalCode.Longitude ?? string.Empty,
						IsTypeBox = postalCode.PoBox,
						ZipCodeSourceId = ZipCodeSourceHelper.BringISSource.SourceId,
						CreatedDate = DateTime.Now,
						ZipCode = postalCode.ZipCode.ToString(),
						ISZipCodeId = Guid.NewGuid(),
						RoutingCode = string.Empty,
						TerminalID = string.Empty,
						IsManuallyAddedZipCode = false,
					};

					databaseZipCodeListToInsertIS.Add(newZipCode);
				}
			}

			var zipCodesIS = await GetZipCodesFromApiAsync(false, ZipCodeSourceHelper.BringISSource);

			if (zipCodesIS.Any())
			{
				foreach (var postalCode in zipCodesIS)
				{
					var newZipCode = new ISZipCode
					{
						County = postalCode.County ?? string.Empty,
						Municipality = postalCode.Municipality ?? string.Empty,
						City = postalCode.City ?? string.Empty,
						LatitudeY = postalCode.Latitude ?? string.Empty,
						LongitudeX = postalCode.Longitude ?? string.Empty,
						IsTypeBox = postalCode.PoBox,
						ZipCodeSourceId = ZipCodeSourceHelper.BringISSource.SourceId,
						CreatedDate = DateTime.Now,
						ZipCode = postalCode.ZipCode.ToString(),
						ISZipCodeId = Guid.NewGuid(),
						RoutingCode = string.Empty,
						TerminalID = string.Empty,
						IsManuallyAddedZipCode = false,
					};

					databaseZipCodeListToInsertIS.Add(newZipCode);
				}
			}

			if (databaseZipCodeListToInsertIS.Any())
			{
				await _zhipsterLocationDbContext.ISZipCodes.Where(x => x.ZipCodeSourceId == ZipCodeSourceHelper.BringISSource.SourceId && x.IsManuallyAddedZipCode == false).BatchDeleteAsync();

				await _zhipsterLocationDbContext.BulkInsertAsync(databaseZipCodeListToInsertIS);

				await _zhipsterLocationDbContext.ZipCodeSources.Where(z => z.ZipCodeSourceId == ZipCodeSourceHelper.BringISSource.SourceId).BatchUpdateAsync(new ZipCodeSource
				{
					LastChangedDate = DateTime.Now,
					SourceRecordCount = databaseZipCodeListToInsertIS.Count
				});
			}
		}

		private async Task InstallSJ()
		{
			await _createSourceService.CreateSource(ZipCodeSourceHelper.BringSJSource);

			var databaseZipCodeListToInsertSJ = new List<SJZipCode>();

			var boxZipCodesSJ = await GetZipCodesFromApiAsync(true, ZipCodeSourceHelper.BringSJSource);

			if (boxZipCodesSJ.Any())
			{
				foreach (var postalCode in boxZipCodesSJ)
				{
					var newZipCode = new SJZipCode
					{
						County = postalCode.County ?? string.Empty,
						Municipality = postalCode.Municipality ?? string.Empty,
						City = postalCode.City ?? string.Empty,
						LatitudeY = postalCode.Latitude ?? string.Empty,
						LongitudeX = postalCode.Longitude ?? string.Empty,
						IsTypeBox = postalCode.PoBox,
						ZipCodeSourceId = ZipCodeSourceHelper.BringSJSource.SourceId,
						CreatedDate = DateTime.Now,
						ZipCode = postalCode.ZipCode.ToString(),
						SJZipCodeId = Guid.NewGuid(),
						RoutingCode = string.Empty,
						TerminalID = string.Empty,
						IsManuallyAddedZipCode = false,
					};

					databaseZipCodeListToInsertSJ.Add(newZipCode);
				}
			}

			var zipCodesSJ = await GetZipCodesFromApiAsync(false, ZipCodeSourceHelper.BringSJSource);

			if (zipCodesSJ.Any())
			{
				foreach (var postalCode in zipCodesSJ)
				{
					var newZipCode = new SJZipCode
					{
						County = postalCode.County ?? string.Empty,
						Municipality = postalCode.Municipality ?? string.Empty,
						City = postalCode.City ?? string.Empty,
						LatitudeY = postalCode.Latitude ?? string.Empty,
						LongitudeX = postalCode.Longitude ?? string.Empty,
						IsTypeBox = postalCode.PoBox,
						ZipCodeSourceId = ZipCodeSourceHelper.BringSJSource.SourceId,
						CreatedDate = DateTime.Now,
						ZipCode = postalCode.ZipCode.ToString(),
						SJZipCodeId = Guid.NewGuid(),
						RoutingCode = string.Empty,
						TerminalID = string.Empty,
						IsManuallyAddedZipCode = false,
					};

					databaseZipCodeListToInsertSJ.Add(newZipCode);
				}
			}

			if (databaseZipCodeListToInsertSJ.Any())
			{
				await _zhipsterLocationDbContext.SJZipCodes.Where(x => x.ZipCodeSourceId == ZipCodeSourceHelper.BringSJSource.SourceId && x.IsManuallyAddedZipCode == false).BatchDeleteAsync();

				await _zhipsterLocationDbContext.BulkInsertAsync(databaseZipCodeListToInsertSJ);

				await _zhipsterLocationDbContext.ZipCodeSources.Where(z => z.ZipCodeSourceId == ZipCodeSourceHelper.BringSJSource.SourceId).BatchUpdateAsync(new ZipCodeSource
				{
					LastChangedDate = DateTime.Now,
					SourceRecordCount = databaseZipCodeListToInsertSJ.Count
				});
			}
		}

		//private async Task CreateSourceIfNotAlreadyExist(SourceInformation source)
		//{
		//	var localSource = await _zhipsterLocationDbContext.ZipCodeSources.Where(x => x.ZipCodeSourceId == source.SourceId).FirstOrDefaultAsync();
		//	if (localSource == null)
		//	{
		//		localSource = new ZipCodeSource
		//		{
		//			ZipCodeSourceId = source.SourceId,
		//			APILink = source.APILink,
		//			CountryCode = source.CountryCode,
		//			CreatedDate = DateTime.Now,
		//			LastChangedDate = DateTime.Now,
		//			SourceName = source.SourceName
		//		};
		//		await _zhipsterLocationDbContext.ZipCodeSources.AddAsync(localSource);
		//		await _zhipsterLocationDbContext.SaveChangesAsync();
		//	}
		//}

		private async Task<List<PostalCode>> GetZipCodesFromApiAsync(bool isTypeBox, SourceInformation source)
		{
			var bringPostalCodes = new List<PostalCode>();

			try
			{
				var endpoint = $"https://api.bring.com/address/api/{source.CountryCode}/postal-codes";

				if (isTypeBox)
				{
					endpoint = $"https://api.bring.com/address/api/{source.CountryCode}/postal-codes?po_box_only=true";
				}

				var client = new HttpClient
				{
					BaseAddress = new Uri(endpoint),
					Timeout = TimeSpan.FromSeconds(60),
				};
				var serializerSettings = new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore,
					DefaultValueHandling = DefaultValueHandling.Include,
				};
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				client.DefaultRequestHeaders.Add("X-Mybring-API-Uid", "");
				client.DefaultRequestHeaders.Add("X-Mybring-API-Key", "");
				client.DefaultRequestHeaders.Add("X-Bring-Client-URL", "");
				var apiHttpResult = await client.GetAsync(endpoint);

				if (apiHttpResult.IsSuccessStatusCode)
				{
					var json = await apiHttpResult.Content.ReadAsStringAsync();
					var postalCodes = JsonConvert.DeserializeObject<BringPostalCodesResponseJSON>(json);

					if (postalCodes != null && postalCodes.PostalCodes != null && postalCodes.PostalCodes.Any())
					{
						bringPostalCodes.AddRange(postalCodes.PostalCodes);
					}
				}
			}
			catch (Exception ex)
			{
				await Console.Out.WriteLineAsync(ex.Message);
			}

			return bringPostalCodes;
		}

		//private async Task InstallZipCodeNorway(bool isTypeBox, SourceInformation source)
		//{
		//	try
		//	{
		//		var endpoint = "https://api.bring.com/address/api/NO/postal-codes";

		//		if (isTypeBox)
		//		{
		//			endpoint = $"https://api.bring.com/address/api/NO/postal-codes?po_box_only=true";
		//		}

		//		var client = new HttpClient
		//		{
		//			BaseAddress = new Uri(endpoint),
		//			Timeout = TimeSpan.FromSeconds(60),
		//		};
		//		var serializerSettings = new JsonSerializerSettings
		//		{
		//			NullValueHandling = NullValueHandling.Ignore,
		//			DefaultValueHandling = DefaultValueHandling.Include,
		//		};
		//		client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		//		client.DefaultRequestHeaders.Add("X-Mybring-API-Uid", "developer@zhipster.se");
		//		client.DefaultRequestHeaders.Add("X-Mybring-API-Key", "6ac118e3-70be-4db1-a2c5-8237aff378e2");
		//		client.DefaultRequestHeaders.Add("X-Bring-Client-URL", "http://exant.se/");
		//		var apiHttpResult = await client.GetAsync(endpoint);
		//		if (apiHttpResult.IsSuccessStatusCode)
		//		{
		//			var json = await apiHttpResult.Content.ReadAsStringAsync();
		//			var postalCodes = JsonConvert.DeserializeObject<BringPostalCodesResponseJSON>(json);

		//			var databaseZipCodeListToInsert = new List<NOZipCode>();

		//			foreach (var postalCode in postalCodes.PostalCodes)
		//			{
		//				var newZipCode = new NOZipCode
		//				{
		//					County = postalCode.County ?? string.Empty,
		//					Municipality = postalCode.Municipality ?? string.Empty,
		//					City = postalCode.City ?? string.Empty,
		//					LatitudeY = postalCode.Latitude ?? string.Empty,
		//					LongitudeX = postalCode.Longitude ?? string.Empty,
		//					IsTypeBox = postalCode.PoBox,
		//					ZipCodeSourceId = source.SourceId,
		//					CreatedDate = DateTime.Now,
		//					ZipCode = postalCode.ZipCode.ToString(),
		//					NOZipCodeId = Guid.NewGuid()
		//				};

		//				databaseZipCodeListToInsert.Add(newZipCode);
		//			}

		//			await _zhipsterLocationDbContext.BulkInsertAsync(databaseZipCodeListToInsert);
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		await Console.Out.WriteLineAsync(ex.Message);
		//	}
		//}

		//private async Task InstallZipCodeDenmark(bool isTypeBox, SourceInformation source)
		//{
		//	try
		//	{
		//		var endpoint = "https://api.bring.com/address/api/DK/postal-codes";

		//		if (isTypeBox)
		//		{
		//			endpoint = $"https://api.bring.com/address/api/DK/postal-codes?po_box_only=true";
		//		}

		//		var client = new HttpClient
		//		{
		//			BaseAddress = new Uri(endpoint),
		//			Timeout = TimeSpan.FromSeconds(60),
		//		};
		//		var serializerSettings = new JsonSerializerSettings
		//		{
		//			NullValueHandling = NullValueHandling.Ignore,
		//			DefaultValueHandling = DefaultValueHandling.Include,
		//		};
		//		client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		//		client.DefaultRequestHeaders.Add("X-Mybring-API-Uid", "developer@zhipster.se");
		//		client.DefaultRequestHeaders.Add("X-Mybring-API-Key", "6ac118e3-70be-4db1-a2c5-8237aff378e2");
		//		client.DefaultRequestHeaders.Add("X-Bring-Client-URL", "http://exant.se/");
		//		var apiHttpResult = await client.GetAsync(endpoint);
		//		if (apiHttpResult.IsSuccessStatusCode)
		//		{
		//			var json = await apiHttpResult.Content.ReadAsStringAsync();
		//			var postalCodes = JsonConvert.DeserializeObject<BringPostalCodesResponseJSON>(json);

		//			var databaseZipCodeListToInsert = new List<DKZipCode>();

		//			foreach (var postalCode in postalCodes.PostalCodes)
		//			{
		//				var newZipCode = new DKZipCode
		//				{
		//					County = postalCode.County ?? string.Empty,
		//					Municipality = postalCode.Municipality ?? string.Empty,
		//					City = postalCode.City ?? string.Empty,
		//					LatitudeY = postalCode.Latitude ?? string.Empty,
		//					LongitudeX = postalCode.Longitude ?? string.Empty,
		//					IsTypeBox = postalCode.PoBox,
		//					ZipCodeSourceId = source.SourceId,
		//					CreatedDate = DateTime.Now,
		//					ZipCode = postalCode.ZipCode.ToString(),
		//					DKZipCodeId = Guid.NewGuid()
		//				};

		//				databaseZipCodeListToInsert.Add(newZipCode);
		//			}

		//			await _zhipsterLocationDbContext.BulkInsertAsync(databaseZipCodeListToInsert);
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		await Console.Out.WriteLineAsync(ex.Message);
		//	}
		//}

		//private async Task InstallZipCodeFinland(bool isTypeBox, SourceInformation source)
		//{
		//	try
		//	{
		//		var endpoint = "https://api.bring.com/address/api/FI/postal-codes";

		//		if (isTypeBox)
		//		{
		//			endpoint = $"https://api.bring.com/address/api/FI/postal-codes?po_box_only=true";
		//		}

		//		var client = new HttpClient
		//		{
		//			BaseAddress = new Uri(endpoint),
		//			Timeout = TimeSpan.FromSeconds(60),
		//		};
		//		var serializerSettings = new JsonSerializerSettings
		//		{
		//			NullValueHandling = NullValueHandling.Ignore,
		//			DefaultValueHandling = DefaultValueHandling.Include,
		//		};
		//		client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		//		client.DefaultRequestHeaders.Add("X-Mybring-API-Uid", "developer@zhipster.se");
		//		client.DefaultRequestHeaders.Add("X-Mybring-API-Key", "6ac118e3-70be-4db1-a2c5-8237aff378e2");
		//		client.DefaultRequestHeaders.Add("X-Bring-Client-URL", "http://exant.se/");
		//		var apiHttpResult = await client.GetAsync(endpoint);
		//		if (apiHttpResult.IsSuccessStatusCode)
		//		{
		//			var json = await apiHttpResult.Content.ReadAsStringAsync();
		//			var postalCodes = JsonConvert.DeserializeObject<BringPostalCodesResponseJSON>(json);

		//			var databaseZipCodeListToInsert = new List<FIZipCode>();

		//			foreach (var postalCode in postalCodes.PostalCodes)
		//			{
		//				var newZipCode = new FIZipCode
		//				{
		//					County = postalCode.County ?? string.Empty,
		//					Municipality = postalCode.Municipality ?? string.Empty,
		//					City = postalCode.City ?? string.Empty,
		//					LatitudeY = postalCode.Latitude ?? string.Empty,
		//					LongitudeX = postalCode.Longitude ?? string.Empty,
		//					IsTypeBox = postalCode.PoBox,
		//					ZipCodeSourceId = source.SourceId,
		//					CreatedDate = DateTime.Now,
		//					ZipCode = postalCode.ZipCode.ToString(),
		//					FIZipCodeId = Guid.NewGuid()
		//				};

		//				databaseZipCodeListToInsert.Add(newZipCode);
		//			}

		//			await _zhipsterLocationDbContext.BulkInsertAsync(databaseZipCodeListToInsert);
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		await Console.Out.WriteLineAsync(ex.Message);
		//	}
		//}
	}
}
