using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Zhipster.Internal.Api.Data.Data;
using Zhipster.Internal.Api.Data.Models;
using Zhipster.Internal.Api.Location.Helpers;
using Zhipster.Internal.Api.Location.Models;
using Zhipster.Internal.Api.Location.Models.DHLFreightSweden;
using Zhipster.Internal.Api.Location.Services.DHL.DHLFreightSweden.DHLFreightSwedenZipCodeService;
using Zhipster.Internal.Api.Location.Services.DSVRoadSwedenZipCodeService;

namespace Zhipster.Internal.Api.Location.Services
{
	public class ZipCodeService : IZipCodeService
	{
		private readonly ZhipsterLocationDbContext _zhipsterLocationDbContext;
		private readonly IBringZipCodeService _bringZipCodeService;
		private readonly IDHLFreightSwedenZipCodeService _iDHLZipCodeService;
		private readonly IDSVRoadSwedenZipCodeService _dSVRoadSwedenZipCodeService;

		public ZipCodeService(ZhipsterLocationDbContext zhipsterLocationDbContext, IBringZipCodeService bringZipCodeService, IDHLFreightSwedenZipCodeService iDHLZipCodeService, IDSVRoadSwedenZipCodeService dSVRoadSwedenZipCodeService)
		{
			_zhipsterLocationDbContext = zhipsterLocationDbContext;
			_bringZipCodeService = bringZipCodeService;
			_iDHLZipCodeService = iDHLZipCodeService;
			_dSVRoadSwedenZipCodeService = dSVRoadSwedenZipCodeService;
		}

		//public async Task<bool> ValidateZipCodeAsync(ValidateZipCodeRequest validateZipCodeRequest)
		//{
		//	var zipCodeIsValid = false;
		//	if (validateZipCodeRequest != null)
		//	{
		//		//var zipCodeInteger = 0;
		//		//int.TryParse(validateZipCodeRequest.ZipCode, out zipCodeInteger);

		//		//zipCodeIsValid = await _zhipsterLocationDbContext.SEZipCodes
		//		//	.Where(x => x.ZipCode == zipCodeInteger).AnyAsync();
		//	}

		//	return zipCodeIsValid;
		//}

		public async Task<ValidateZipCodeResponse> ValidateZipCode(string zipCode, string countryCode)
		{
			ValidateZipCodeResponse returnZipCode = null;

			switch (countryCode)
			{
				case "SE":
					returnZipCode = await _zhipsterLocationDbContext.SEZipCodes.Where(x => x.ZipCodeSourceId == ZipCodeSourceHelper.BringSESource.SourceId && x.ZipCode == zipCode).Select(x => new ValidateZipCodeResponse
					{
						City = x.City,
						Municipality = x.Municipality,
						County = x.County,
						CountryCode = countryCode,
						ZipCode = zipCode,
						Latitude = x.LatitudeY,
						Longitude = x.LongitudeX,
						PoBox = x.IsTypeBox,
					}).FirstOrDefaultAsync();
					break;

				case "NO":
					returnZipCode = await _zhipsterLocationDbContext.NOZipCodes.Where(x => x.ZipCodeSourceId == ZipCodeSourceHelper.BringNOSource.SourceId && x.ZipCode == zipCode).Select(x => new ValidateZipCodeResponse
					{
						City = x.City,
						Municipality = x.Municipality,
						County = x.County,
						CountryCode = countryCode,
						ZipCode = zipCode,
						Latitude = x.LatitudeY,
						Longitude = x.LongitudeX,
						PoBox = x.IsTypeBox,
					}).FirstOrDefaultAsync();
					break;

				case "DK":
					returnZipCode = await _zhipsterLocationDbContext.DKZipCodes.Where(x => x.ZipCodeSourceId == ZipCodeSourceHelper.BringDKSource.SourceId && x.ZipCode == zipCode).Select(x => new ValidateZipCodeResponse
					{
						City = x.City,
						Municipality = x.Municipality,
						County = x.County,
						CountryCode = countryCode,
						ZipCode = zipCode,
						Latitude = x.LatitudeY,
						Longitude = x.LongitudeX,
						PoBox = x.IsTypeBox,
					}).FirstOrDefaultAsync();
					break;

				case "FI":
					returnZipCode = await _zhipsterLocationDbContext.FIZipCodes.Where(x => x.ZipCodeSourceId == ZipCodeSourceHelper.BringFISource.SourceId && x.ZipCode == zipCode).Select(x => new ValidateZipCodeResponse
					{
						City = x.City,
						Municipality = x.Municipality,
						County = x.County,
						CountryCode = countryCode,
						ZipCode = zipCode,
						Latitude = x.LatitudeY,
						Longitude = x.LongitudeX,
						PoBox = x.IsTypeBox,
					}).FirstOrDefaultAsync();
					break;

				case "NL":
					returnZipCode = await _zhipsterLocationDbContext.NLZipCodes.Where(x => x.ZipCodeSourceId == ZipCodeSourceHelper.BringNLSource.SourceId && x.ZipCode == zipCode).Select(x => new ValidateZipCodeResponse
					{
						City = x.City,
						Municipality = x.Municipality,
						County = x.County,
						CountryCode = countryCode,
						ZipCode = zipCode,
						Latitude = x.LatitudeY,
						Longitude = x.LongitudeX,
						PoBox = x.IsTypeBox,
					}).FirstOrDefaultAsync();
					break;

				case "DE":
					returnZipCode = await _zhipsterLocationDbContext.DEZipCodes.Where(x => x.ZipCodeSourceId == ZipCodeSourceHelper.BringDESource.SourceId && x.ZipCode == zipCode).Select(x => new ValidateZipCodeResponse
					{
						City = x.City,
						Municipality = x.Municipality,
						County = x.County,
						CountryCode = countryCode,
						ZipCode = zipCode,
						Latitude = x.LatitudeY,
						Longitude = x.LongitudeX,
						PoBox = x.IsTypeBox,
					}).FirstOrDefaultAsync();
					break;

				case "US":
					returnZipCode = await _zhipsterLocationDbContext.USZipCodes.Where(x => x.ZipCodeSourceId == ZipCodeSourceHelper.BringUSSource.SourceId && x.ZipCode == zipCode).Select(x => new ValidateZipCodeResponse
					{
						City = x.City,
						Municipality = x.Municipality,
						County = x.County,
						CountryCode = countryCode,
						StateCode = x.StateCode,
						ZipCode = zipCode,
						Latitude = x.LatitudeY,
						Longitude = x.LongitudeX,
						PoBox = x.IsTypeBox,
					}).FirstOrDefaultAsync();
					break;

				case "BE":
					returnZipCode = await _zhipsterLocationDbContext.BEZipCodes.Where(x => x.ZipCodeSourceId == ZipCodeSourceHelper.BringBESource.SourceId && x.ZipCode == zipCode).Select(x => new ValidateZipCodeResponse
					{
						City = x.City,
						Municipality = x.Municipality,
						County = x.County,
						CountryCode = countryCode,
						ZipCode = zipCode,
						Latitude = x.LatitudeY,
						Longitude = x.LongitudeX,
						PoBox = x.IsTypeBox,
					}).FirstOrDefaultAsync();
					break;

				case "FO":
					returnZipCode = await _zhipsterLocationDbContext.FOZipCodes.Where(x => x.ZipCodeSourceId == ZipCodeSourceHelper.BringFOSource.SourceId && x.ZipCode == zipCode).Select(x => new ValidateZipCodeResponse
					{
						City = x.City,
						Municipality = x.Municipality,
						County = x.County,
						CountryCode = countryCode,
						ZipCode = zipCode,
						Latitude = x.LatitudeY,
						Longitude = x.LongitudeX,
						PoBox = x.IsTypeBox,
					}).FirstOrDefaultAsync();
					break;

				case "GL":
					returnZipCode = await _zhipsterLocationDbContext.GLZipCodes.Where(x => x.ZipCodeSourceId == ZipCodeSourceHelper.BringGLSource.SourceId && x.ZipCode == zipCode).Select(x => new ValidateZipCodeResponse
					{
						City = x.City,
						Municipality = x.Municipality,
						County = x.County,
						CountryCode = countryCode,
						ZipCode = zipCode,
						Latitude = x.LatitudeY,
						Longitude = x.LongitudeX,
						PoBox = x.IsTypeBox,
					}).FirstOrDefaultAsync();
					break;

				case "IS":
					returnZipCode = await _zhipsterLocationDbContext.ISZipCodes.Where(x => x.ZipCodeSourceId == ZipCodeSourceHelper.BringISSource.SourceId && x.ZipCode == zipCode).Select(x => new ValidateZipCodeResponse
					{
						City = x.City,
						Municipality = x.Municipality,
						County = x.County,
						CountryCode = countryCode,
						ZipCode = zipCode,
						Latitude = x.LatitudeY,
						Longitude = x.LongitudeX,
						PoBox = x.IsTypeBox,
					}).FirstOrDefaultAsync();
					break;

				case "SJ":
					returnZipCode = await _zhipsterLocationDbContext.SJZipCodes.Where(x => x.ZipCodeSourceId == ZipCodeSourceHelper.BringSJSource.SourceId && x.ZipCode == zipCode).Select(x => new ValidateZipCodeResponse
					{
						City = x.City,
						Municipality = x.Municipality,
						County = x.County,
						CountryCode = countryCode,
						ZipCode = zipCode,
						Latitude = x.LatitudeY,
						Longitude = x.LongitudeX,
						PoBox = x.IsTypeBox,
					}).FirstOrDefaultAsync();
					break;
			}

			if (returnZipCode == null)
			{
				returnZipCode = new ValidateZipCodeResponse
				{
					ZipCodeIsValid = false,
				};
			}

			else
			{
				returnZipCode.ZipCodeIsValid = true;
			}

			return returnZipCode;
		}

		public async Task<List<ZipCodeSourceInformation>> GetZipCodeSources()
		{
			return await _zhipsterLocationDbContext.ZipCodeSources.Select(x => new ZipCodeSourceInformation
			{
				APILink = x.APILink,
				CountryCode = x.CountryCode,
				CreatedDate = x.CreatedDate,
				LastChangedDate = x.LastChangedDate,
				SourceName = x.SourceName,
				SourceRecordCount = x.SourceRecordCount,
				SourceId = x.ZipCodeSourceId
			}).ToListAsync();
		}

		public async Task<List<ZipCodeInformation>> GetZipCodesBySource(Guid sourceID, string searchParameter)
		{
			var listOfZipCodeInformation = new List<ZipCodeInformation>();

			IQueryable<ZipCodeInformation> dataSource;

			var source = await _zhipsterLocationDbContext.ZipCodeSources.Where(x => x.ZipCodeSourceId == sourceID).FirstOrDefaultAsync();

			if (source != null)
			{
				switch (source.CountryCode)
				{
					case "SE":
						dataSource = _zhipsterLocationDbContext.SEZipCodes.Where(x => x.ZipCodeSourceId == source.ZipCodeSourceId).Select(x => new ZipCodeInformation
						{
							CountryCode = "SE",
							City = x.City,
							Municipality = x.Municipality,
							County = x.County,
							CreatedDate = x.CreatedDate,
							IsTypeBox = x.IsTypeBox,
							LatitudeY = x.LatitudeY,
							LongitudeX = x.LongitudeX,
							RoutingCode = x.RoutingCode,
							TerminalID = x.TerminalID,
							ZipCode = x.ZipCode,
							ZipCodeSourceId = x.ZipCodeSourceId,
							ZipCodeSourceName = source.SourceName,
							IsManuallyAddedZipCode = x.IsManuallyAddedZipCode,
							ZipCodeId = x.SEZipCodeId,
						});

						if (!string.IsNullOrWhiteSpace(searchParameter))
						{
							dataSource = dataSource
								.Where(x => x.ZipCode.Contains(searchParameter)
								|| x.City.Contains(searchParameter)
								);
						}

						listOfZipCodeInformation = await dataSource.ToListAsync();
						break;

					case "NO":
						dataSource = _zhipsterLocationDbContext.NOZipCodes.Where(x => x.ZipCodeSourceId == source.ZipCodeSourceId).Select(x => new ZipCodeInformation
						{
							CountryCode = "NO",
							City = x.City,
							Municipality = x.Municipality,
							County = x.County,
							CreatedDate = x.CreatedDate,
							IsTypeBox = x.IsTypeBox,
							LatitudeY = x.LatitudeY,
							LongitudeX = x.LongitudeX,
							RoutingCode = x.RoutingCode,
							TerminalID = x.TerminalID,
							ZipCode = x.ZipCode,
							ZipCodeSourceId = x.ZipCodeSourceId,
							ZipCodeSourceName = source.SourceName,
							IsManuallyAddedZipCode = x.IsManuallyAddedZipCode,
							ZipCodeId = x.NOZipCodeId,
						});

						if (!string.IsNullOrWhiteSpace(searchParameter))
						{
							dataSource = dataSource
								.Where(x => x.ZipCode.Contains(searchParameter)
								|| x.City.Contains(searchParameter)
								);
						}

						listOfZipCodeInformation = await dataSource.ToListAsync();
						break;

					case "DK":
						dataSource = _zhipsterLocationDbContext.DKZipCodes.Where(x => x.ZipCodeSourceId == source.ZipCodeSourceId).Select(x => new ZipCodeInformation
						{
							CountryCode = "DK",
							City = x.City,
							Municipality = x.Municipality,
							County = x.County,
							CreatedDate = x.CreatedDate,
							IsTypeBox = x.IsTypeBox,
							LatitudeY = x.LatitudeY,
							LongitudeX = x.LongitudeX,
							RoutingCode = x.RoutingCode,
							TerminalID = x.TerminalID,
							ZipCode = x.ZipCode,
							ZipCodeSourceId = x.ZipCodeSourceId,
							ZipCodeSourceName = source.SourceName,
							IsManuallyAddedZipCode = x.IsManuallyAddedZipCode,
							ZipCodeId = x.DKZipCodeId,
						});

						if (!string.IsNullOrWhiteSpace(searchParameter))
						{
							dataSource = dataSource
								.Where(x => x.ZipCode.Contains(searchParameter)
								|| x.City.Contains(searchParameter)
								);
						}

						listOfZipCodeInformation = await dataSource.ToListAsync();
						break;

					case "FI":
						dataSource = _zhipsterLocationDbContext.FIZipCodes.Where(x => x.ZipCodeSourceId == source.ZipCodeSourceId).Select(x => new ZipCodeInformation
						{
							CountryCode = "FI",
							City = x.City,
							Municipality = x.Municipality,
							County = x.County,
							CreatedDate = x.CreatedDate,
							IsTypeBox = x.IsTypeBox,
							LatitudeY = x.LatitudeY,
							LongitudeX = x.LongitudeX,
							RoutingCode = x.RoutingCode,
							TerminalID = x.TerminalID,
							ZipCode = x.ZipCode,
							ZipCodeSourceId = x.ZipCodeSourceId,
							ZipCodeSourceName = source.SourceName,
							IsManuallyAddedZipCode = x.IsManuallyAddedZipCode,
							ZipCodeId = x.FIZipCodeId,
						});

						if (!string.IsNullOrWhiteSpace(searchParameter))
						{
							dataSource = dataSource
								.Where(x => x.ZipCode.Contains(searchParameter)
								|| x.City.Contains(searchParameter)
								);
						}

						listOfZipCodeInformation = await dataSource.ToListAsync();
						break;

					case "NL":
						dataSource = _zhipsterLocationDbContext.NLZipCodes.Where(x => x.ZipCodeSourceId == source.ZipCodeSourceId).Select(x => new ZipCodeInformation
						{
							CountryCode = "NL",
							City = x.City,
							Municipality = x.Municipality,
							County = x.County,
							CreatedDate = x.CreatedDate,
							IsTypeBox = x.IsTypeBox,
							LatitudeY = x.LatitudeY,
							LongitudeX = x.LongitudeX,
							RoutingCode = x.RoutingCode,
							TerminalID = x.TerminalID,
							ZipCode = x.ZipCode,
							ZipCodeSourceId = x.ZipCodeSourceId,
							ZipCodeSourceName = source.SourceName,
							IsManuallyAddedZipCode = x.IsManuallyAddedZipCode,
							ZipCodeId = x.NLZipCodeId,
						});

						if (!string.IsNullOrWhiteSpace(searchParameter))
						{
							dataSource = dataSource
								.Where(x => x.ZipCode.Contains(searchParameter)
								|| x.City.Contains(searchParameter)
								);
						}

						listOfZipCodeInformation = await dataSource.ToListAsync();
						break;

					case "DE":
						dataSource = _zhipsterLocationDbContext.DEZipCodes.Where(x => x.ZipCodeSourceId == source.ZipCodeSourceId).Select(x => new ZipCodeInformation
						{
							CountryCode = "DE",
							City = x.City,
							Municipality = x.Municipality,
							County = x.County,
							CreatedDate = x.CreatedDate,
							IsTypeBox = x.IsTypeBox,
							LatitudeY = x.LatitudeY,
							LongitudeX = x.LongitudeX,
							RoutingCode = x.RoutingCode,
							TerminalID = x.TerminalID,
							ZipCode = x.ZipCode,
							ZipCodeSourceId = x.ZipCodeSourceId,
							ZipCodeSourceName = source.SourceName,
							IsManuallyAddedZipCode = x.IsManuallyAddedZipCode,
							ZipCodeId = x.DEZipCodeId,
						});

						if (!string.IsNullOrWhiteSpace(searchParameter))
						{
							dataSource = dataSource
								.Where(x => x.ZipCode.Contains(searchParameter)
								|| x.City.Contains(searchParameter)
								);
						}

						listOfZipCodeInformation = await dataSource.ToListAsync();
						break;

					case "US":
						dataSource = _zhipsterLocationDbContext.USZipCodes.Where(x => x.ZipCodeSourceId == source.ZipCodeSourceId).Select(x => new ZipCodeInformation
						{
							CountryCode = "US",
							StateCode = x.StateCode,
							City = x.City,
							Municipality = x.Municipality,
							County = x.County,
							CreatedDate = x.CreatedDate,
							IsTypeBox = x.IsTypeBox,
							LatitudeY = x.LatitudeY,
							LongitudeX = x.LongitudeX,
							RoutingCode = x.RoutingCode,
							TerminalID = x.TerminalID,
							ZipCode = x.ZipCode,
							ZipCodeSourceId = x.ZipCodeSourceId,
							ZipCodeSourceName = source.SourceName,
							IsManuallyAddedZipCode = x.IsManuallyAddedZipCode,
							ZipCodeId = x.USZipCodeId,
						});

						if (!string.IsNullOrWhiteSpace(searchParameter))
						{
							dataSource = dataSource
								.Where(x => x.ZipCode.Contains(searchParameter)
								|| x.City.Contains(searchParameter)
								);
						}

						listOfZipCodeInformation = await dataSource.ToListAsync();
						break;

					case "BE":
						dataSource = _zhipsterLocationDbContext.BEZipCodes.Where(x => x.ZipCodeSourceId == source.ZipCodeSourceId).Select(x => new ZipCodeInformation
						{
							CountryCode = "BE",
							City = x.City,
							Municipality = x.Municipality,
							County = x.County,
							CreatedDate = x.CreatedDate,
							IsTypeBox = x.IsTypeBox,
							LatitudeY = x.LatitudeY,
							LongitudeX = x.LongitudeX,
							RoutingCode = x.RoutingCode,
							TerminalID = x.TerminalID,
							ZipCode = x.ZipCode,
							ZipCodeSourceId = x.ZipCodeSourceId,
							ZipCodeSourceName = source.SourceName,
							IsManuallyAddedZipCode = x.IsManuallyAddedZipCode,
							ZipCodeId = x.BEZipCodeId,
						});

						if (!string.IsNullOrWhiteSpace(searchParameter))
						{
							dataSource = dataSource
								.Where(x => x.ZipCode.Contains(searchParameter)
								|| x.City.Contains(searchParameter)
								);
						}

						listOfZipCodeInformation = await dataSource.ToListAsync();
						break;

					case "FO":
						dataSource = _zhipsterLocationDbContext.FOZipCodes.Where(x => x.ZipCodeSourceId == source.ZipCodeSourceId).Select(x => new ZipCodeInformation
						{
							CountryCode = "FO",
							City = x.City,
							Municipality = x.Municipality,
							County = x.County,
							CreatedDate = x.CreatedDate,
							IsTypeBox = x.IsTypeBox,
							LatitudeY = x.LatitudeY,
							LongitudeX = x.LongitudeX,
							RoutingCode = x.RoutingCode,
							TerminalID = x.TerminalID,
							ZipCode = x.ZipCode,
							ZipCodeSourceId = x.ZipCodeSourceId,
							ZipCodeSourceName = source.SourceName,
							IsManuallyAddedZipCode = x.IsManuallyAddedZipCode,
							ZipCodeId = x.FOZipCodeId,
						});

						if (!string.IsNullOrWhiteSpace(searchParameter))
						{
							dataSource = dataSource
								.Where(x => x.ZipCode.Contains(searchParameter)
								|| x.City.Contains(searchParameter)
								);
						}

						listOfZipCodeInformation = await dataSource.ToListAsync();
						break;

					case "GL":
						dataSource = _zhipsterLocationDbContext.GLZipCodes.Where(x => x.ZipCodeSourceId == source.ZipCodeSourceId).Select(x => new ZipCodeInformation
						{
							CountryCode = "GL",
							City = x.City,
							Municipality = x.Municipality,
							County = x.County,
							CreatedDate = x.CreatedDate,
							IsTypeBox = x.IsTypeBox,
							LatitudeY = x.LatitudeY,
							LongitudeX = x.LongitudeX,
							RoutingCode = x.RoutingCode,
							TerminalID = x.TerminalID,
							ZipCode = x.ZipCode,
							ZipCodeSourceId = x.ZipCodeSourceId,
							ZipCodeSourceName = source.SourceName,
							IsManuallyAddedZipCode = x.IsManuallyAddedZipCode,
							ZipCodeId = x.GLZipCodeId,
						});

						if (!string.IsNullOrWhiteSpace(searchParameter))
						{
							dataSource = dataSource
								.Where(x => x.ZipCode.Contains(searchParameter)
								|| x.City.Contains(searchParameter)
								);
						}

						listOfZipCodeInformation = await dataSource.ToListAsync();
						break;

					case "IS":
						dataSource = _zhipsterLocationDbContext.ISZipCodes.Where(x => x.ZipCodeSourceId == source.ZipCodeSourceId).Select(x => new ZipCodeInformation
						{
							CountryCode = "IS",
							City = x.City,
							Municipality = x.Municipality,
							County = x.County,
							CreatedDate = x.CreatedDate,
							IsTypeBox = x.IsTypeBox,
							LatitudeY = x.LatitudeY,
							LongitudeX = x.LongitudeX,
							RoutingCode = x.RoutingCode,
							TerminalID = x.TerminalID,
							ZipCode = x.ZipCode,
							ZipCodeSourceId = x.ZipCodeSourceId,
							ZipCodeSourceName = source.SourceName,
							IsManuallyAddedZipCode = x.IsManuallyAddedZipCode,
							ZipCodeId = x.ISZipCodeId,
						});

						if (!string.IsNullOrWhiteSpace(searchParameter))
						{
							dataSource = dataSource
								.Where(x => x.ZipCode.Contains(searchParameter)
								|| x.City.Contains(searchParameter)
								);
						}

						listOfZipCodeInformation = await dataSource.ToListAsync();
						break;

					case "SJ":
						dataSource = _zhipsterLocationDbContext.SJZipCodes.Where(x => x.ZipCodeSourceId == source.ZipCodeSourceId).Select(x => new ZipCodeInformation
						{
							CountryCode = "SJ",
							City = x.City,
							Municipality = x.Municipality,
							County = x.County,
							CreatedDate = x.CreatedDate,
							IsTypeBox = x.IsTypeBox,
							LatitudeY = x.LatitudeY,
							LongitudeX = x.LongitudeX,
							RoutingCode = x.RoutingCode,
							TerminalID = x.TerminalID,
							ZipCode = x.ZipCode,
							ZipCodeSourceId = x.ZipCodeSourceId,
							ZipCodeSourceName = source.SourceName,
							IsManuallyAddedZipCode = x.IsManuallyAddedZipCode,
							ZipCodeId = x.SJZipCodeId,
						});

						if (!string.IsNullOrWhiteSpace(searchParameter))
						{
							dataSource = dataSource
								.Where(x => x.ZipCode.Contains(searchParameter)
								|| x.City.Contains(searchParameter)
								);
						}

						listOfZipCodeInformation = await dataSource.ToListAsync();
						break;
				}
			}

			return listOfZipCodeInformation;
		}

		public async Task InstallAndUpdateZipCodes()
		{
			await _bringZipCodeService.InstallZipCodes();

			await _iDHLZipCodeService.InstallZipCodes();

			await _dSVRoadSwedenZipCodeService.InstallZipCodes();
		}

		public async Task<string> AddZipCodeManually(ZipCodeInformation zipCodeInformation)
		{
			//var NO = ZipCodeSourceHelper.BringNOSource.SourceId.ToString();


			//switch (zipCodeSourceId.ToString())
			//{
			//	case NO.ToString():

			//		break;

			//	default:
			//		break;
			//}
			//var test = await _zhipsterLocationDbContext.NOZipCodes.Where(x => x.ZipCodeSourceId == zipCodeSourceId).FirstOrDefaultAsync);

			//var test2 = _zhipsterLocationDbContext.NOZipCodes.Contains(zipCodeSourceId);



			if (zipCodeInformation.ZipCodeSourceId == ZipCodeSourceHelper.BringNOSource.SourceId)
			{
				zipCodeInformation.ZipCode = StandardizeZipCodeHelper.StandardizeZipCode(zipCodeInformation.ZipCode, ZipCodeSourceHelper.BringNOSource.CountryCode);
				var checkIfZipCodeSourceIdAlreadyExistsInDatabase = await _zhipsterLocationDbContext.NOZipCodes.Where(x => x.ZipCodeSourceId == zipCodeInformation.ZipCodeSourceId && x.ZipCode == zipCodeInformation.ZipCode).AnyAsync();
				if (!checkIfZipCodeSourceIdAlreadyExistsInDatabase)
				{
					var newZipCode = new NOZipCode
					{
						County = zipCodeInformation.County ?? string.Empty,
						Municipality = zipCodeInformation.Municipality ?? string.Empty,
						City = zipCodeInformation.City ?? string.Empty,
						LatitudeY = zipCodeInformation.LatitudeY ?? string.Empty,
						LongitudeX = zipCodeInformation.LongitudeX ?? string.Empty,
						IsTypeBox = false,
						ZipCodeSourceId = zipCodeInformation.ZipCodeSourceId,
						CreatedDate = DateTime.Now,
						ZipCode = zipCodeInformation.ZipCode,
						NOZipCodeId = Guid.NewGuid(),
						RoutingCode = zipCodeInformation.RoutingCode ?? string.Empty,
						TerminalID = zipCodeInformation.TerminalID ?? string.Empty,
						IsManuallyAddedZipCode = true,
					};

					await _zhipsterLocationDbContext.NOZipCodes.AddAsync(newZipCode);
					await _zhipsterLocationDbContext.SaveChangesAsync();

					return $"A new Zip Code with the name {zipCodeInformation.ZipCode} was created successfully!";
				}

				else
				{
					return $"A Zip Code with the name {zipCodeInformation.ZipCode} already exists in the database!";
				}
			}

			else if (zipCodeInformation.ZipCodeSourceId == ZipCodeSourceHelper.BringDKSource.SourceId)
			{
				zipCodeInformation.ZipCode = StandardizeZipCodeHelper.StandardizeZipCode(zipCodeInformation.ZipCode, ZipCodeSourceHelper.BringDKSource.CountryCode);
				var checkIfZipCodeSourceIdAlreadyExistsInDatabase = await _zhipsterLocationDbContext.DKZipCodes.Where(x => x.ZipCodeSourceId == zipCodeInformation.ZipCodeSourceId && x.ZipCode == zipCodeInformation.ZipCode).AnyAsync();
				if (!checkIfZipCodeSourceIdAlreadyExistsInDatabase)
				{
					var newZipCode = new DKZipCode
					{
						County = zipCodeInformation.County ?? string.Empty,
						Municipality = zipCodeInformation.Municipality ?? string.Empty,
						City = zipCodeInformation.City ?? string.Empty,
						LatitudeY = zipCodeInformation.LatitudeY ?? string.Empty,
						LongitudeX = zipCodeInformation.LongitudeX ?? string.Empty,
						IsTypeBox = false,
						ZipCodeSourceId = zipCodeInformation.ZipCodeSourceId,
						CreatedDate = DateTime.Now,
						ZipCode = zipCodeInformation.ZipCode,
						DKZipCodeId = Guid.NewGuid(),
						RoutingCode = zipCodeInformation.RoutingCode ?? string.Empty,
						TerminalID = zipCodeInformation.TerminalID ?? string.Empty,
						IsManuallyAddedZipCode = true,
					};

					await _zhipsterLocationDbContext.DKZipCodes.AddAsync(newZipCode);
					await _zhipsterLocationDbContext.SaveChangesAsync();

					return $"A new Zip Code with the name {zipCodeInformation.ZipCode} was created successfully!";
				}

				else
				{
					return $"A Zip Code with the name {zipCodeInformation.ZipCode} already exists in the database!";
				}
			}

			else if (zipCodeInformation.ZipCodeSourceId == ZipCodeSourceHelper.BringSESource.SourceId || zipCodeInformation.ZipCodeSourceId == ZipCodeSourceHelper.DHLFreightSESource.SourceId || zipCodeInformation.ZipCodeSourceId == ZipCodeSourceHelper.DSVRoadSESource.SourceId)
			{
				zipCodeInformation.ZipCode = StandardizeZipCodeHelper.StandardizeZipCode(zipCodeInformation.ZipCode, ZipCodeSourceHelper.BringSESource.CountryCode);
				var checkIfZipCodeSourceIdAlreadyExistsInDatabase = await _zhipsterLocationDbContext.SEZipCodes.Where(x => x.ZipCodeSourceId == zipCodeInformation.ZipCodeSourceId && x.ZipCode == zipCodeInformation.ZipCode).AnyAsync();
				if (!checkIfZipCodeSourceIdAlreadyExistsInDatabase)
				{
					var newZipCode = new SEZipCode
					{
						County = zipCodeInformation.County ?? string.Empty,
						Municipality = zipCodeInformation.Municipality ?? string.Empty,
						City = zipCodeInformation.City ?? string.Empty,
						LatitudeY = zipCodeInformation.LatitudeY ?? string.Empty,
						LongitudeX = zipCodeInformation.LongitudeX ?? string.Empty,
						IsTypeBox = false,
						ZipCodeSourceId = zipCodeInformation.ZipCodeSourceId,
						CreatedDate = DateTime.Now,
						ZipCode = zipCodeInformation.ZipCode,
						SEZipCodeId = Guid.NewGuid(),
						RoutingCode = zipCodeInformation.RoutingCode ?? string.Empty,
						TerminalID = zipCodeInformation.TerminalID ?? string.Empty,
						IsManuallyAddedZipCode = true,
					};

					await _zhipsterLocationDbContext.SEZipCodes.AddAsync(newZipCode);
					await _zhipsterLocationDbContext.SaveChangesAsync();

					return $"A new Zip Code with the name {zipCodeInformation.ZipCode} was created successfully!";
				}

				else
				{
					return $"A Zip Code with the name {zipCodeInformation.ZipCode} already exists in the database!";
				}
			}

			else if (zipCodeInformation.ZipCodeSourceId == ZipCodeSourceHelper.BringFISource.SourceId)
			{
				zipCodeInformation.ZipCode = StandardizeZipCodeHelper.StandardizeZipCode(zipCodeInformation.ZipCode, ZipCodeSourceHelper.BringFISource.CountryCode);
				var checkIfZipCodeSourceIdAlreadyExistsInDatabase = await _zhipsterLocationDbContext.FIZipCodes.Where(x => x.ZipCodeSourceId == zipCodeInformation.ZipCodeSourceId && x.ZipCode == zipCodeInformation.ZipCode).AnyAsync();
				if (!checkIfZipCodeSourceIdAlreadyExistsInDatabase)
				{
					var newZipCode = new FIZipCode
					{
						County = zipCodeInformation.County ?? string.Empty,
						Municipality = zipCodeInformation.Municipality ?? string.Empty,
						City = zipCodeInformation.City ?? string.Empty,
						LatitudeY = zipCodeInformation.LatitudeY ?? string.Empty,
						LongitudeX = zipCodeInformation.LongitudeX ?? string.Empty,
						IsTypeBox = false,
						ZipCodeSourceId = zipCodeInformation.ZipCodeSourceId,
						CreatedDate = DateTime.Now,
						ZipCode = zipCodeInformation.ZipCode,
						FIZipCodeId = Guid.NewGuid(),
						RoutingCode = zipCodeInformation.RoutingCode ?? string.Empty,
						TerminalID = zipCodeInformation.TerminalID ?? string.Empty,
						IsManuallyAddedZipCode = true,
					};

					await _zhipsterLocationDbContext.FIZipCodes.AddAsync(newZipCode);
					await _zhipsterLocationDbContext.SaveChangesAsync();

					return $"A new Zip Code with the name {zipCodeInformation.ZipCode} was created successfully!";
				}

				else
				{
					return $"A Zip Code with the name {zipCodeInformation.ZipCode} already exists in the database!";
				}
			}

			else if (zipCodeInformation.ZipCodeSourceId == ZipCodeSourceHelper.BringNLSource.SourceId)
			{
				zipCodeInformation.ZipCode = StandardizeZipCodeHelper.StandardizeZipCode(zipCodeInformation.ZipCode, ZipCodeSourceHelper.BringNLSource.CountryCode);
				var checkIfZipCodeSourceIdAlreadyExistsInDatabase = await _zhipsterLocationDbContext.NLZipCodes.Where(x => x.ZipCodeSourceId == zipCodeInformation.ZipCodeSourceId && x.ZipCode == zipCodeInformation.ZipCode).AnyAsync();
				if (!checkIfZipCodeSourceIdAlreadyExistsInDatabase)
				{
					var newZipCode = new NLZipCode
					{
						County = zipCodeInformation.County ?? string.Empty,
						Municipality = zipCodeInformation.Municipality ?? string.Empty,
						City = zipCodeInformation.City ?? string.Empty,
						LatitudeY = zipCodeInformation.LatitudeY ?? string.Empty,
						LongitudeX = zipCodeInformation.LongitudeX ?? string.Empty,
						IsTypeBox = false,
						ZipCodeSourceId = zipCodeInformation.ZipCodeSourceId,
						CreatedDate = DateTime.Now,
						ZipCode = zipCodeInformation.ZipCode,
						NLZipCodeId = Guid.NewGuid(),
						RoutingCode = zipCodeInformation.RoutingCode ?? string.Empty,
						TerminalID = zipCodeInformation.TerminalID ?? string.Empty,
						IsManuallyAddedZipCode = true,
					};

					await _zhipsterLocationDbContext.NLZipCodes.AddAsync(newZipCode);
					await _zhipsterLocationDbContext.SaveChangesAsync();

					return $"A new Zip Code with the name {zipCodeInformation.ZipCode} was created successfully!";
				}

				else
				{
					return $"A Zip Code with the name {zipCodeInformation.ZipCode} already exists in the database!";
				}
			}

			else if (zipCodeInformation.ZipCodeSourceId == ZipCodeSourceHelper.BringDESource.SourceId)
			{
				zipCodeInformation.ZipCode = StandardizeZipCodeHelper.StandardizeZipCode(zipCodeInformation.ZipCode, ZipCodeSourceHelper.BringDESource.CountryCode);
				var checkIfZipCodeSourceIdAlreadyExistsInDatabase = await _zhipsterLocationDbContext.DEZipCodes.Where(x => x.ZipCodeSourceId == zipCodeInformation.ZipCodeSourceId && x.ZipCode == zipCodeInformation.ZipCode).AnyAsync();
				if (!checkIfZipCodeSourceIdAlreadyExistsInDatabase)
				{
					var newZipCode = new DEZipCode
					{
						County = zipCodeInformation.County ?? string.Empty,
						Municipality = zipCodeInformation.Municipality ?? string.Empty,
						City = zipCodeInformation.City ?? string.Empty,
						LatitudeY = zipCodeInformation.LatitudeY ?? string.Empty,
						LongitudeX = zipCodeInformation.LongitudeX ?? string.Empty,
						IsTypeBox = false,
						ZipCodeSourceId = zipCodeInformation.ZipCodeSourceId,
						CreatedDate = DateTime.Now,
						ZipCode = zipCodeInformation.ZipCode,
						DEZipCodeId = Guid.NewGuid(),
						RoutingCode = zipCodeInformation.RoutingCode ?? string.Empty,
						TerminalID = zipCodeInformation.TerminalID ?? string.Empty,
						IsManuallyAddedZipCode = true,
					};

					await _zhipsterLocationDbContext.DEZipCodes.AddAsync(newZipCode);
					await _zhipsterLocationDbContext.SaveChangesAsync();

					return $"A new Zip Code with the name {zipCodeInformation.ZipCode} was created successfully!";
				}

				else
				{
					return $"A Zip Code with the name {zipCodeInformation.ZipCode} already exists in the database!";
				}
			}

			else if (zipCodeInformation.ZipCodeSourceId == ZipCodeSourceHelper.BringUSSource.SourceId)
			{
				zipCodeInformation.ZipCode = StandardizeZipCodeHelper.StandardizeZipCode(zipCodeInformation.ZipCode, ZipCodeSourceHelper.BringUSSource.CountryCode);
				var checkIfZipCodeSourceIdAlreadyExistsInDatabase = await _zhipsterLocationDbContext.USZipCodes.Where(x => x.ZipCodeSourceId == zipCodeInformation.ZipCodeSourceId && x.ZipCode == zipCodeInformation.ZipCode).AnyAsync();
				if (!checkIfZipCodeSourceIdAlreadyExistsInDatabase)
				{
					var newZipCode = new USZipCode
					{
						County = zipCodeInformation.County ?? string.Empty,
						Municipality = zipCodeInformation.Municipality ?? string.Empty,
						City = zipCodeInformation.City ?? string.Empty,
						LatitudeY = zipCodeInformation.LatitudeY ?? string.Empty,
						LongitudeX = zipCodeInformation.LongitudeX ?? string.Empty,
						IsTypeBox = false,
						ZipCodeSourceId = zipCodeInformation.ZipCodeSourceId,
						CreatedDate = DateTime.Now,
						ZipCode = zipCodeInformation.ZipCode,
						USZipCodeId = Guid.NewGuid(),
						RoutingCode = zipCodeInformation.RoutingCode ?? string.Empty,
						TerminalID = zipCodeInformation.TerminalID ?? string.Empty,
						IsManuallyAddedZipCode = true,
					};

					await _zhipsterLocationDbContext.USZipCodes.AddAsync(newZipCode);
					await _zhipsterLocationDbContext.SaveChangesAsync();

					return $"A new Zip Code with the name {zipCodeInformation.ZipCode} was created successfully!";
				}

				else
				{
					return $"A Zip Code with the name {zipCodeInformation.ZipCode} already exists in the database!";
				}
			}

			else if (zipCodeInformation.ZipCodeSourceId == ZipCodeSourceHelper.BringBESource.SourceId)
			{
				zipCodeInformation.ZipCode = StandardizeZipCodeHelper.StandardizeZipCode(zipCodeInformation.ZipCode, ZipCodeSourceHelper.BringBESource.CountryCode);
				var checkIfZipCodeSourceIdAlreadyExistsInDatabase = await _zhipsterLocationDbContext.BEZipCodes.Where(x => x.ZipCodeSourceId == zipCodeInformation.ZipCodeSourceId && x.ZipCode == zipCodeInformation.ZipCode).AnyAsync();
				if (!checkIfZipCodeSourceIdAlreadyExistsInDatabase)
				{
					var newZipCode = new BEZipCode
					{
						County = zipCodeInformation.County ?? string.Empty,
						Municipality = zipCodeInformation.Municipality ?? string.Empty,
						City = zipCodeInformation.City ?? string.Empty,
						LatitudeY = zipCodeInformation.LatitudeY ?? string.Empty,
						LongitudeX = zipCodeInformation.LongitudeX ?? string.Empty,
						IsTypeBox = false,
						ZipCodeSourceId = zipCodeInformation.ZipCodeSourceId,
						CreatedDate = DateTime.Now,
						ZipCode = zipCodeInformation.ZipCode,
						BEZipCodeId = Guid.NewGuid(),
						RoutingCode = zipCodeInformation.RoutingCode ?? string.Empty,
						TerminalID = zipCodeInformation.TerminalID ?? string.Empty,
						IsManuallyAddedZipCode = true,
					};

					await _zhipsterLocationDbContext.BEZipCodes.AddAsync(newZipCode);
					await _zhipsterLocationDbContext.SaveChangesAsync();

					return $"A new Zip Code with the name {zipCodeInformation.ZipCode} was created successfully!";
				}

				else
				{
					return $"A Zip Code with the name {zipCodeInformation.ZipCode} already exists in the database!";
				}
			}

			else if (zipCodeInformation.ZipCodeSourceId == ZipCodeSourceHelper.BringFOSource.SourceId)
			{
				zipCodeInformation.ZipCode = StandardizeZipCodeHelper.StandardizeZipCode(zipCodeInformation.ZipCode, ZipCodeSourceHelper.BringFOSource.CountryCode);
				var checkIfZipCodeSourceIdAlreadyExistsInDatabase = await _zhipsterLocationDbContext.FOZipCodes.Where(x => x.ZipCodeSourceId == zipCodeInformation.ZipCodeSourceId && x.ZipCode == zipCodeInformation.ZipCode).AnyAsync();
				if (!checkIfZipCodeSourceIdAlreadyExistsInDatabase)
				{
					var newZipCode = new FOZipCode
					{
						County = zipCodeInformation.County ?? string.Empty,
						Municipality = zipCodeInformation.Municipality ?? string.Empty,
						City = zipCodeInformation.City ?? string.Empty,
						LatitudeY = zipCodeInformation.LatitudeY ?? string.Empty,
						LongitudeX = zipCodeInformation.LongitudeX ?? string.Empty,
						IsTypeBox = false,
						ZipCodeSourceId = zipCodeInformation.ZipCodeSourceId,
						CreatedDate = DateTime.Now,
						ZipCode = zipCodeInformation.ZipCode,
						FOZipCodeId = Guid.NewGuid(),
						RoutingCode = zipCodeInformation.RoutingCode ?? string.Empty,
						TerminalID = zipCodeInformation.TerminalID ?? string.Empty,
						IsManuallyAddedZipCode = true,
					};

					await _zhipsterLocationDbContext.FOZipCodes.AddAsync(newZipCode);
					await _zhipsterLocationDbContext.SaveChangesAsync();

					return $"A new Zip Code with the name {zipCodeInformation.ZipCode} was created successfully!";
				}

				else
				{
					return $"A Zip Code with the name {zipCodeInformation.ZipCode} already exists in the database!";
				}
			}

			else if (zipCodeInformation.ZipCodeSourceId == ZipCodeSourceHelper.BringGLSource.SourceId)
			{
				zipCodeInformation.ZipCode = StandardizeZipCodeHelper.StandardizeZipCode(zipCodeInformation.ZipCode, ZipCodeSourceHelper.BringGLSource.CountryCode);
				var checkIfZipCodeSourceIdAlreadyExistsInDatabase = await _zhipsterLocationDbContext.GLZipCodes.Where(x => x.ZipCodeSourceId == zipCodeInformation.ZipCodeSourceId && x.ZipCode == zipCodeInformation.ZipCode).AnyAsync();
				if (!checkIfZipCodeSourceIdAlreadyExistsInDatabase)
				{
					var newZipCode = new GLZipCode
					{
						County = zipCodeInformation.County ?? string.Empty,
						Municipality = zipCodeInformation.Municipality ?? string.Empty,
						City = zipCodeInformation.City ?? string.Empty,
						LatitudeY = zipCodeInformation.LatitudeY ?? string.Empty,
						LongitudeX = zipCodeInformation.LongitudeX ?? string.Empty,
						IsTypeBox = false,
						ZipCodeSourceId = zipCodeInformation.ZipCodeSourceId,
						CreatedDate = DateTime.Now,
						ZipCode = zipCodeInformation.ZipCode,
						GLZipCodeId = Guid.NewGuid(),
						RoutingCode = zipCodeInformation.RoutingCode ?? string.Empty,
						TerminalID = zipCodeInformation.TerminalID ?? string.Empty,
						IsManuallyAddedZipCode = true,
					};

					await _zhipsterLocationDbContext.GLZipCodes.AddAsync(newZipCode);
					await _zhipsterLocationDbContext.SaveChangesAsync();

					return $"A new Zip Code with the name {zipCodeInformation.ZipCode} was created successfully!";
				}

				else
				{
					return $"A Zip Code with the name {zipCodeInformation.ZipCode} already exists in the database!";
				}
			}

			else if (zipCodeInformation.ZipCodeSourceId == ZipCodeSourceHelper.BringISSource.SourceId)
			{
				zipCodeInformation.ZipCode = StandardizeZipCodeHelper.StandardizeZipCode(zipCodeInformation.ZipCode, ZipCodeSourceHelper.BringISSource.CountryCode);
				var checkIfZipCodeSourceIdAlreadyExistsInDatabase = await _zhipsterLocationDbContext.ISZipCodes.Where(x => x.ZipCodeSourceId == zipCodeInformation.ZipCodeSourceId && x.ZipCode == zipCodeInformation.ZipCode).AnyAsync();
				if (!checkIfZipCodeSourceIdAlreadyExistsInDatabase)
				{
					var newZipCode = new ISZipCode
					{
						County = zipCodeInformation.County ?? string.Empty,
						Municipality = zipCodeInformation.Municipality ?? string.Empty,
						City = zipCodeInformation.City ?? string.Empty,
						LatitudeY = zipCodeInformation.LatitudeY ?? string.Empty,
						LongitudeX = zipCodeInformation.LongitudeX ?? string.Empty,
						IsTypeBox = false,
						ZipCodeSourceId = zipCodeInformation.ZipCodeSourceId,
						CreatedDate = DateTime.Now,
						ZipCode = zipCodeInformation.ZipCode,
						ISZipCodeId = Guid.NewGuid(),
						RoutingCode = zipCodeInformation.RoutingCode ?? string.Empty,
						TerminalID = zipCodeInformation.TerminalID ?? string.Empty,
						IsManuallyAddedZipCode = true,
					};

					await _zhipsterLocationDbContext.ISZipCodes.AddAsync(newZipCode);
					await _zhipsterLocationDbContext.SaveChangesAsync();

					return $"A new Zip Code with the name {zipCodeInformation.ZipCode} was created successfully!";
				}

				else
				{
					return $"A Zip Code with the name {zipCodeInformation.ZipCode} already exists in the database!";
				}
			}

			else if (zipCodeInformation.ZipCodeSourceId == ZipCodeSourceHelper.BringSJSource.SourceId)
			{
				zipCodeInformation.ZipCode = StandardizeZipCodeHelper.StandardizeZipCode(zipCodeInformation.ZipCode, ZipCodeSourceHelper.BringSJSource.CountryCode);
				var checkIfZipCodeSourceIdAlreadyExistsInDatabase = await _zhipsterLocationDbContext.SJZipCodes.Where(x => x.ZipCodeSourceId == zipCodeInformation.ZipCodeSourceId && x.ZipCode == zipCodeInformation.ZipCode).AnyAsync();
				if (!checkIfZipCodeSourceIdAlreadyExistsInDatabase)
				{
					var newZipCode = new SJZipCode
					{
						County = zipCodeInformation.County ?? string.Empty,
						Municipality = zipCodeInformation.Municipality ?? string.Empty,
						City = zipCodeInformation.City ?? string.Empty,
						LatitudeY = zipCodeInformation.LatitudeY ?? string.Empty,
						LongitudeX = zipCodeInformation.LongitudeX ?? string.Empty,
						IsTypeBox = false,
						ZipCodeSourceId = zipCodeInformation.ZipCodeSourceId,
						CreatedDate = DateTime.Now,
						ZipCode = zipCodeInformation.ZipCode,
						SJZipCodeId = Guid.NewGuid(),
						RoutingCode = zipCodeInformation.RoutingCode ?? string.Empty,
						TerminalID = zipCodeInformation.TerminalID ?? string.Empty,
						IsManuallyAddedZipCode = true,
					};

					await _zhipsterLocationDbContext.SJZipCodes.AddAsync(newZipCode);
					await _zhipsterLocationDbContext.SaveChangesAsync();

					return $"A new Zip Code with the name {zipCodeInformation.ZipCode} was created successfully!";
				}

				else
				{
					return $"A Zip Code with the name {zipCodeInformation.ZipCode} already exists in the database!";
				}
			}

			return "That is not a valid Zip Code or Zip Code Source Id!";
		}

		public async Task<string> RemoveZipCodeFromSource(Guid zipCodeSourceId, Guid zipCodeId)
		{
			if (zipCodeSourceId == ZipCodeSourceHelper.BringNOSource.SourceId)
			{
				var localZipCodeObject = await _zhipsterLocationDbContext.NOZipCodes.Where(x => x.NOZipCodeId == zipCodeId).FirstOrDefaultAsync();

				localZipCodeObject.ZipCode = StandardizeZipCodeHelper.StandardizeZipCode(localZipCodeObject.ZipCode, ZipCodeSourceHelper.BringNOSource.CountryCode);
				var objectToRemove = await _zhipsterLocationDbContext.NOZipCodes.Where(x => x.ZipCodeSourceId == zipCodeSourceId && x.ZipCode == localZipCodeObject.ZipCode).FirstOrDefaultAsync();
				if (objectToRemove != null)
				{
					_zhipsterLocationDbContext.NOZipCodes.Remove(objectToRemove);
					await _zhipsterLocationDbContext.SaveChangesAsync();

					return $"An object with the Zip Code of {localZipCodeObject.ZipCode} was successfully deleted!";
				}

				else
				{
					return "Zip Code not found!";
				}
			}

			else if (zipCodeSourceId == ZipCodeSourceHelper.BringDKSource.SourceId)
			{
				var localZipCodeObject = await _zhipsterLocationDbContext.DKZipCodes.Where(x => x.DKZipCodeId == zipCodeId).FirstOrDefaultAsync();

				localZipCodeObject.ZipCode = StandardizeZipCodeHelper.StandardizeZipCode(localZipCodeObject.ZipCode, ZipCodeSourceHelper.BringDKSource.CountryCode);
				var objectToRemove = await _zhipsterLocationDbContext.DKZipCodes.Where(x => x.ZipCodeSourceId == zipCodeSourceId && x.ZipCode == localZipCodeObject.ZipCode).FirstOrDefaultAsync();
				if (objectToRemove != null)
				{
					_zhipsterLocationDbContext.DKZipCodes.Remove(objectToRemove);
					await _zhipsterLocationDbContext.SaveChangesAsync();

					return $"An object with the Zip Code of {localZipCodeObject.ZipCode} was successfully deleted!";
				}

				else
				{
					return "Zip Code not found!";
				}
			}

			else if (zipCodeSourceId == ZipCodeSourceHelper.BringSESource.SourceId || zipCodeSourceId == ZipCodeSourceHelper.DHLFreightSESource.SourceId || zipCodeSourceId == ZipCodeSourceHelper.DSVRoadSESource.SourceId)
			{
				var localZipCodeObject = await _zhipsterLocationDbContext.SEZipCodes.Where(x => x.SEZipCodeId == zipCodeId).FirstOrDefaultAsync();

				localZipCodeObject.ZipCode = StandardizeZipCodeHelper.StandardizeZipCode(localZipCodeObject.ZipCode, ZipCodeSourceHelper.BringSESource.CountryCode);
				var objectToRemove = await _zhipsterLocationDbContext.SEZipCodes.Where(x => x.ZipCodeSourceId == zipCodeSourceId && x.ZipCode == localZipCodeObject.ZipCode).FirstOrDefaultAsync();
				if (objectToRemove != null)
				{
					_zhipsterLocationDbContext.SEZipCodes.Remove(objectToRemove);
					await _zhipsterLocationDbContext.SaveChangesAsync();

					return $"An object with the Zip Code of {localZipCodeObject.ZipCode} was successfully deleted!";
				}

				else
				{
					return "Zip Code not found!";
				}
			}

			else if (zipCodeSourceId == ZipCodeSourceHelper.BringFISource.SourceId)
			{
				var localZipCodeObject = await _zhipsterLocationDbContext.FIZipCodes.Where(x => x.FIZipCodeId == zipCodeId).FirstOrDefaultAsync();

				localZipCodeObject.ZipCode = StandardizeZipCodeHelper.StandardizeZipCode(localZipCodeObject.ZipCode, ZipCodeSourceHelper.BringFISource.CountryCode);
				var objectToRemove = await _zhipsterLocationDbContext.FIZipCodes.Where(x => x.ZipCodeSourceId == zipCodeSourceId && x.ZipCode == localZipCodeObject.ZipCode).FirstOrDefaultAsync();
				if (objectToRemove != null)
				{
					_zhipsterLocationDbContext.FIZipCodes.Remove(objectToRemove);
					await _zhipsterLocationDbContext.SaveChangesAsync();

					return $"An object with the Zip Code of {localZipCodeObject.ZipCode} was successfully deleted!";
				}

				else
				{
					return "Zip Code not found!";
				}
			}

			else if (zipCodeSourceId == ZipCodeSourceHelper.BringNLSource.SourceId)
			{
				var localZipCodeObject = await _zhipsterLocationDbContext.NLZipCodes.Where(x => x.NLZipCodeId == zipCodeId).FirstOrDefaultAsync();

				localZipCodeObject.ZipCode = StandardizeZipCodeHelper.StandardizeZipCode(localZipCodeObject.ZipCode, ZipCodeSourceHelper.BringNLSource.CountryCode);
				var objectToRemove = await _zhipsterLocationDbContext.NLZipCodes.Where(x => x.ZipCodeSourceId == zipCodeSourceId && x.ZipCode == localZipCodeObject.ZipCode).FirstOrDefaultAsync();
				if (objectToRemove != null)
				{
					_zhipsterLocationDbContext.NLZipCodes.Remove(objectToRemove);
					await _zhipsterLocationDbContext.SaveChangesAsync();

					return $"An object with the Zip Code of {localZipCodeObject.ZipCode} was successfully deleted!";
				}

				else
				{
					return "Zip Code not found!";
				}
			}

			else if (zipCodeSourceId == ZipCodeSourceHelper.BringDESource.SourceId)
			{
				var localZipCodeObject = await _zhipsterLocationDbContext.DEZipCodes.Where(x => x.DEZipCodeId == zipCodeId).FirstOrDefaultAsync();

				localZipCodeObject.ZipCode = StandardizeZipCodeHelper.StandardizeZipCode(localZipCodeObject.ZipCode, ZipCodeSourceHelper.BringDESource.CountryCode);
				var objectToRemove = await _zhipsterLocationDbContext.DEZipCodes.Where(x => x.ZipCodeSourceId == zipCodeSourceId && x.ZipCode == localZipCodeObject.ZipCode).FirstOrDefaultAsync();
				if (objectToRemove != null)
				{
					_zhipsterLocationDbContext.DEZipCodes.Remove(objectToRemove);
					await _zhipsterLocationDbContext.SaveChangesAsync();

					return $"An object with the Zip Code of {localZipCodeObject.ZipCode} was successfully deleted!";
				}

				else
				{
					return "Zip Code not found!";
				}
			}

			else if (zipCodeSourceId == ZipCodeSourceHelper.BringUSSource.SourceId)
			{
				var localZipCodeObject = await _zhipsterLocationDbContext.USZipCodes.Where(x => x.USZipCodeId == zipCodeId).FirstOrDefaultAsync();

				localZipCodeObject.ZipCode = StandardizeZipCodeHelper.StandardizeZipCode(localZipCodeObject.ZipCode, ZipCodeSourceHelper.BringUSSource.CountryCode);
				var objectToRemove = await _zhipsterLocationDbContext.USZipCodes.Where(x => x.ZipCodeSourceId == zipCodeSourceId && x.ZipCode == localZipCodeObject.ZipCode).FirstOrDefaultAsync();
				if (objectToRemove != null)
				{
					_zhipsterLocationDbContext.USZipCodes.Remove(objectToRemove);
					await _zhipsterLocationDbContext.SaveChangesAsync();

					return $"An object with the Zip Code of {localZipCodeObject.ZipCode} was successfully deleted!";
				}

				else
				{
					return "Zip Code not found!";
				}
			}

			else if (zipCodeSourceId == ZipCodeSourceHelper.BringBESource.SourceId)
			{
				var localZipCodeObject = await _zhipsterLocationDbContext.BEZipCodes.Where(x => x.BEZipCodeId == zipCodeId).FirstOrDefaultAsync();

				localZipCodeObject.ZipCode = StandardizeZipCodeHelper.StandardizeZipCode(localZipCodeObject.ZipCode, ZipCodeSourceHelper.BringBESource.CountryCode);
				var objectToRemove = await _zhipsterLocationDbContext.BEZipCodes.Where(x => x.ZipCodeSourceId == zipCodeSourceId && x.ZipCode == localZipCodeObject.ZipCode).FirstOrDefaultAsync();
				if (objectToRemove != null)
				{
					_zhipsterLocationDbContext.BEZipCodes.Remove(objectToRemove);
					await _zhipsterLocationDbContext.SaveChangesAsync();

					return $"An object with the Zip Code of {localZipCodeObject.ZipCode} was successfully deleted!";
				}

				else
				{
					return "Zip Code not found!";
				}
			}

			else if (zipCodeSourceId == ZipCodeSourceHelper.BringFOSource.SourceId)
			{
				var localZipCodeObject = await _zhipsterLocationDbContext.FOZipCodes.Where(x => x.FOZipCodeId == zipCodeId).FirstOrDefaultAsync();

				localZipCodeObject.ZipCode = StandardizeZipCodeHelper.StandardizeZipCode(localZipCodeObject.ZipCode, ZipCodeSourceHelper.BringFOSource.CountryCode);
				var objectToRemove = await _zhipsterLocationDbContext.FOZipCodes.Where(x => x.ZipCodeSourceId == zipCodeSourceId && x.ZipCode == localZipCodeObject.ZipCode).FirstOrDefaultAsync();
				if (objectToRemove != null)
				{
					_zhipsterLocationDbContext.FOZipCodes.Remove(objectToRemove);
					await _zhipsterLocationDbContext.SaveChangesAsync();

					return $"An object with the Zip Code of {localZipCodeObject.ZipCode} was successfully deleted!";
				}

				else
				{
					return "Zip Code not found!";
				}
			}

			else if (zipCodeSourceId == ZipCodeSourceHelper.BringGLSource.SourceId)
			{
				var localZipCodeObject = await _zhipsterLocationDbContext.GLZipCodes.Where(x => x.GLZipCodeId == zipCodeId).FirstOrDefaultAsync();

				localZipCodeObject.ZipCode = StandardizeZipCodeHelper.StandardizeZipCode(localZipCodeObject.ZipCode, ZipCodeSourceHelper.BringGLSource.CountryCode);
				var objectToRemove = await _zhipsterLocationDbContext.GLZipCodes.Where(x => x.ZipCodeSourceId == zipCodeSourceId && x.ZipCode == localZipCodeObject.ZipCode).FirstOrDefaultAsync();
				if (objectToRemove != null)
				{
					_zhipsterLocationDbContext.GLZipCodes.Remove(objectToRemove);
					await _zhipsterLocationDbContext.SaveChangesAsync();

					return $"An object with the Zip Code of {localZipCodeObject.ZipCode} was successfully deleted!";
				}

				else
				{
					return "Zip Code not found!";
				}
			}

			else if (zipCodeSourceId == ZipCodeSourceHelper.BringISSource.SourceId)
			{
				var localZipCodeObject = await _zhipsterLocationDbContext.ISZipCodes.Where(x => x.ISZipCodeId == zipCodeId).FirstOrDefaultAsync();

				localZipCodeObject.ZipCode = StandardizeZipCodeHelper.StandardizeZipCode(localZipCodeObject.ZipCode, ZipCodeSourceHelper.BringISSource.CountryCode);
				var objectToRemove = await _zhipsterLocationDbContext.ISZipCodes.Where(x => x.ZipCodeSourceId == zipCodeSourceId && x.ZipCode == localZipCodeObject.ZipCode).FirstOrDefaultAsync();
				if (objectToRemove != null)
				{
					_zhipsterLocationDbContext.ISZipCodes.Remove(objectToRemove);
					await _zhipsterLocationDbContext.SaveChangesAsync();

					return $"An object with the Zip Code of {localZipCodeObject.ZipCode} was successfully deleted!";
				}

				else
				{
					return "Zip Code not found!";
				}
			}

			else if (zipCodeSourceId == ZipCodeSourceHelper.BringSJSource.SourceId)
			{
				var localZipCodeObject = await _zhipsterLocationDbContext.SJZipCodes.Where(x => x.SJZipCodeId == zipCodeId).FirstOrDefaultAsync();

				localZipCodeObject.ZipCode = StandardizeZipCodeHelper.StandardizeZipCode(localZipCodeObject.ZipCode, ZipCodeSourceHelper.BringSJSource.CountryCode);
				var objectToRemove = await _zhipsterLocationDbContext.SJZipCodes.Where(x => x.ZipCodeSourceId == zipCodeSourceId && x.ZipCode == localZipCodeObject.ZipCode).FirstOrDefaultAsync();
				if (objectToRemove != null)
				{
					_zhipsterLocationDbContext.SJZipCodes.Remove(objectToRemove);
					await _zhipsterLocationDbContext.SaveChangesAsync();

					return $"An object with the Zip Code of {localZipCodeObject.ZipCode} was successfully deleted!";
				}

				else
				{
					return "Zip Code not found!";
				}
			}

			return string.Empty;
		}

		public async Task<List<ZipCodeInformation>> GetZipCodesByCountry(string countryCode, string searchParameter)
		{
			var listOfZipCodeInformation = new List<ZipCodeInformation>();

			countryCode = StandardizeCountryCodeHelper.StandardizeCountryCode(countryCode);

			if (countryCode == "SE")
			{
				var dataSource = (from x in _zhipsterLocationDbContext.SEZipCodes
										join s in _zhipsterLocationDbContext.ZipCodeSources on x.ZipCodeSourceId equals s.ZipCodeSourceId
										select new ZipCodeInformation
										{
											CountryCode = "SE",
											City = x.City,
											Municipality = x.Municipality,
											County = x.County,
											CreatedDate = x.CreatedDate,
											IsTypeBox = x.IsTypeBox,
											LatitudeY = x.LatitudeY,
											LongitudeX = x.LongitudeX,
											RoutingCode = x.RoutingCode,
											TerminalID = x.TerminalID,
											ZipCode = x.ZipCode,
											ZipCodeSourceId = x.ZipCodeSourceId,
											ZipCodeSourceName = s.SourceName,
											IsManuallyAddedZipCode = x.IsManuallyAddedZipCode,
										});

				if (!string.IsNullOrWhiteSpace(searchParameter))
				{
					dataSource = dataSource
						.Where(x => x.ZipCode.Contains(searchParameter)
						|| x.City.Contains(searchParameter)
						);
				}

				listOfZipCodeInformation = await dataSource.ToListAsync();
			}

			else if (countryCode == "NO")
			{
				var dataSource = (from x in _zhipsterLocationDbContext.NOZipCodes
										join s in _zhipsterLocationDbContext.ZipCodeSources on x.ZipCodeSourceId equals s.ZipCodeSourceId
										select new ZipCodeInformation
										{
											CountryCode = "NO",
											City = x.City,
											Municipality = x.Municipality,
											County = x.County,
											CreatedDate = x.CreatedDate,
											IsTypeBox = x.IsTypeBox,
											LatitudeY = x.LatitudeY,
											LongitudeX = x.LongitudeX,
											RoutingCode = x.RoutingCode,
											TerminalID = x.TerminalID,
											ZipCode = x.ZipCode,
											ZipCodeSourceId = x.ZipCodeSourceId,
											ZipCodeSourceName = s.SourceName,
											IsManuallyAddedZipCode = x.IsManuallyAddedZipCode,
										});

				if (!string.IsNullOrWhiteSpace(searchParameter))
				{
					dataSource = dataSource
						.Where(x => x.ZipCode.Contains(searchParameter)
						|| x.City.Contains(searchParameter)
						);
				}

				listOfZipCodeInformation = await dataSource.ToListAsync();
			}

			else if (countryCode == "DK")
			{
				var dataSource = (from x in _zhipsterLocationDbContext.DKZipCodes
										join s in _zhipsterLocationDbContext.ZipCodeSources on x.ZipCodeSourceId equals s.ZipCodeSourceId
										select new ZipCodeInformation
										{
											CountryCode = "DK",
											City = x.City,
											Municipality = x.Municipality,
											County = x.County,
											CreatedDate = x.CreatedDate,
											IsTypeBox = x.IsTypeBox,
											LatitudeY = x.LatitudeY,
											LongitudeX = x.LongitudeX,
											RoutingCode = x.RoutingCode,
											TerminalID = x.TerminalID,
											ZipCode = x.ZipCode,
											ZipCodeSourceId = x.ZipCodeSourceId,
											ZipCodeSourceName = s.SourceName,
											IsManuallyAddedZipCode = x.IsManuallyAddedZipCode,
										});

				if (!string.IsNullOrWhiteSpace(searchParameter))
				{
					dataSource = dataSource
						.Where(x => x.ZipCode.Contains(searchParameter)
						|| x.City.Contains(searchParameter)
						);
				}

				listOfZipCodeInformation = await dataSource.ToListAsync();
			}

			else if (countryCode == "FI")
			{
				var dataSource = (from x in _zhipsterLocationDbContext.FIZipCodes
										join s in _zhipsterLocationDbContext.ZipCodeSources on x.ZipCodeSourceId equals s.ZipCodeSourceId
										select new ZipCodeInformation
										{
											CountryCode = "FI",
											City = x.City,
											Municipality = x.Municipality,
											County = x.County,
											CreatedDate = x.CreatedDate,
											IsTypeBox = x.IsTypeBox,
											LatitudeY = x.LatitudeY,
											LongitudeX = x.LongitudeX,
											RoutingCode = x.RoutingCode,
											TerminalID = x.TerminalID,
											ZipCode = x.ZipCode,
											ZipCodeSourceId = x.ZipCodeSourceId,
											ZipCodeSourceName = s.SourceName,
											IsManuallyAddedZipCode = x.IsManuallyAddedZipCode,
										});

				if (!string.IsNullOrWhiteSpace(searchParameter))
				{
					dataSource = dataSource
						.Where(x => x.ZipCode.Contains(searchParameter)
						|| x.City.Contains(searchParameter)
						);
				}

				listOfZipCodeInformation = await dataSource.ToListAsync();
			}

			else if (countryCode == "NL")
			{
				var dataSource = (from x in _zhipsterLocationDbContext.NLZipCodes
										join s in _zhipsterLocationDbContext.ZipCodeSources on x.ZipCodeSourceId equals s.ZipCodeSourceId
										select new ZipCodeInformation
										{
											CountryCode = "NL",
											City = x.City,
											Municipality = x.Municipality,
											County = x.County,
											CreatedDate = x.CreatedDate,
											IsTypeBox = x.IsTypeBox,
											LatitudeY = x.LatitudeY,
											LongitudeX = x.LongitudeX,
											RoutingCode = x.RoutingCode,
											TerminalID = x.TerminalID,
											ZipCode = x.ZipCode,
											ZipCodeSourceId = x.ZipCodeSourceId,
											ZipCodeSourceName = s.SourceName,
											IsManuallyAddedZipCode = x.IsManuallyAddedZipCode,
										});

				if (!string.IsNullOrWhiteSpace(searchParameter))
				{
					dataSource = dataSource
						.Where(x => x.ZipCode.Contains(searchParameter)
						|| x.City.Contains(searchParameter)
						);
				}

				listOfZipCodeInformation = await dataSource.ToListAsync();
			}

			else if (countryCode == "DE")
			{
				var dataSource = (from x in _zhipsterLocationDbContext.DEZipCodes
										join s in _zhipsterLocationDbContext.ZipCodeSources on x.ZipCodeSourceId equals s.ZipCodeSourceId
										select new ZipCodeInformation
										{
											CountryCode = "DE",
											City = x.City,
											Municipality = x.Municipality,
											County = x.County,
											CreatedDate = x.CreatedDate,
											IsTypeBox = x.IsTypeBox,
											LatitudeY = x.LatitudeY,
											LongitudeX = x.LongitudeX,
											RoutingCode = x.RoutingCode,
											TerminalID = x.TerminalID,
											ZipCode = x.ZipCode,
											ZipCodeSourceId = x.ZipCodeSourceId,
											ZipCodeSourceName = s.SourceName,
											IsManuallyAddedZipCode = x.IsManuallyAddedZipCode,
										});

				if (!string.IsNullOrWhiteSpace(searchParameter))
				{
					dataSource = dataSource
						.Where(x => x.ZipCode.Contains(searchParameter)
						|| x.City.Contains(searchParameter)
						);
				}

				listOfZipCodeInformation = await dataSource.ToListAsync();
			}

			else if (countryCode == "US")
			{
				var dataSource = (from x in _zhipsterLocationDbContext.USZipCodes
										join s in _zhipsterLocationDbContext.ZipCodeSources on x.ZipCodeSourceId equals s.ZipCodeSourceId
										select new ZipCodeInformation
										{
											CountryCode = "US",
											City = x.City,
											Municipality = x.Municipality,
											County = x.County,
											CreatedDate = x.CreatedDate,
											IsTypeBox = x.IsTypeBox,
											LatitudeY = x.LatitudeY,
											LongitudeX = x.LongitudeX,
											RoutingCode = x.RoutingCode,
											TerminalID = x.TerminalID,
											ZipCode = x.ZipCode,
											ZipCodeSourceId = x.ZipCodeSourceId,
											ZipCodeSourceName = s.SourceName,
											IsManuallyAddedZipCode = x.IsManuallyAddedZipCode,
										});

				if (!string.IsNullOrWhiteSpace(searchParameter))
				{
					dataSource = dataSource
						.Where(x => x.ZipCode.Contains(searchParameter)
						|| x.City.Contains(searchParameter)
						);
				}

				listOfZipCodeInformation = await dataSource.ToListAsync();
			}

			else if (countryCode == "BE")
			{
				var dataSource = (from x in _zhipsterLocationDbContext.BEZipCodes
										join s in _zhipsterLocationDbContext.ZipCodeSources on x.ZipCodeSourceId equals s.ZipCodeSourceId
										select new ZipCodeInformation
										{
											CountryCode = "BE",
											City = x.City,
											Municipality = x.Municipality,
											County = x.County,
											CreatedDate = x.CreatedDate,
											IsTypeBox = x.IsTypeBox,
											LatitudeY = x.LatitudeY,
											LongitudeX = x.LongitudeX,
											RoutingCode = x.RoutingCode,
											TerminalID = x.TerminalID,
											ZipCode = x.ZipCode,
											ZipCodeSourceId = x.ZipCodeSourceId,
											ZipCodeSourceName = s.SourceName,
											IsManuallyAddedZipCode = x.IsManuallyAddedZipCode,
										});

				if (!string.IsNullOrWhiteSpace(searchParameter))
				{
					dataSource = dataSource
						.Where(x => x.ZipCode.Contains(searchParameter)
						|| x.City.Contains(searchParameter)
						);
				}

				listOfZipCodeInformation = await dataSource.ToListAsync();
			}

			else if (countryCode == "FO")
			{
				var dataSource = (from x in _zhipsterLocationDbContext.FOZipCodes
										join s in _zhipsterLocationDbContext.ZipCodeSources on x.ZipCodeSourceId equals s.ZipCodeSourceId
										select new ZipCodeInformation
										{
											CountryCode = "FO",
											City = x.City,
											Municipality = x.Municipality,
											County = x.County,
											CreatedDate = x.CreatedDate,
											IsTypeBox = x.IsTypeBox,
											LatitudeY = x.LatitudeY,
											LongitudeX = x.LongitudeX,
											RoutingCode = x.RoutingCode,
											TerminalID = x.TerminalID,
											ZipCode = x.ZipCode,
											ZipCodeSourceId = x.ZipCodeSourceId,
											ZipCodeSourceName = s.SourceName,
											IsManuallyAddedZipCode = x.IsManuallyAddedZipCode,
										});

				if (!string.IsNullOrWhiteSpace(searchParameter))
				{
					dataSource = dataSource
						.Where(x => x.ZipCode.Contains(searchParameter)
						|| x.City.Contains(searchParameter)
						);
				}

				listOfZipCodeInformation = await dataSource.ToListAsync();
			}

			else if (countryCode == "GL")
			{
				var dataSource = (from x in _zhipsterLocationDbContext.GLZipCodes
										join s in _zhipsterLocationDbContext.ZipCodeSources on x.ZipCodeSourceId equals s.ZipCodeSourceId
										select new ZipCodeInformation
										{
											CountryCode = "GL",
											City = x.City,
											Municipality = x.Municipality,
											County = x.County,
											CreatedDate = x.CreatedDate,
											IsTypeBox = x.IsTypeBox,
											LatitudeY = x.LatitudeY,
											LongitudeX = x.LongitudeX,
											RoutingCode = x.RoutingCode,
											TerminalID = x.TerminalID,
											ZipCode = x.ZipCode,
											ZipCodeSourceId = x.ZipCodeSourceId,
											ZipCodeSourceName = s.SourceName,
											IsManuallyAddedZipCode = x.IsManuallyAddedZipCode,
										});

				if (!string.IsNullOrWhiteSpace(searchParameter))
				{
					dataSource = dataSource
						.Where(x => x.ZipCode.Contains(searchParameter)
						|| x.City.Contains(searchParameter)
						);
				}

				listOfZipCodeInformation = await dataSource.ToListAsync();
			}

			else if (countryCode == "IS")
			{
				var dataSource = (from x in _zhipsterLocationDbContext.ISZipCodes
										join s in _zhipsterLocationDbContext.ZipCodeSources on x.ZipCodeSourceId equals s.ZipCodeSourceId
										select new ZipCodeInformation
										{
											CountryCode = "IS",
											City = x.City,
											Municipality = x.Municipality,
											County = x.County,
											CreatedDate = x.CreatedDate,
											IsTypeBox = x.IsTypeBox,
											LatitudeY = x.LatitudeY,
											LongitudeX = x.LongitudeX,
											RoutingCode = x.RoutingCode,
											TerminalID = x.TerminalID,
											ZipCode = x.ZipCode,
											ZipCodeSourceId = x.ZipCodeSourceId,
											ZipCodeSourceName = s.SourceName,
											IsManuallyAddedZipCode = x.IsManuallyAddedZipCode,
										});

				if (!string.IsNullOrWhiteSpace(searchParameter))
				{
					dataSource = dataSource
						.Where(x => x.ZipCode.Contains(searchParameter)
						|| x.City.Contains(searchParameter)
						);
				}

				listOfZipCodeInformation = await dataSource.ToListAsync();
			}

			else if (countryCode == "SJ")
			{
				var dataSource = (from x in _zhipsterLocationDbContext.SJZipCodes
										join s in _zhipsterLocationDbContext.ZipCodeSources on x.ZipCodeSourceId equals s.ZipCodeSourceId
										select new ZipCodeInformation
										{
											CountryCode = "SJ",
											City = x.City,
											Municipality = x.Municipality,
											County = x.County,
											CreatedDate = x.CreatedDate,
											IsTypeBox = x.IsTypeBox,
											LatitudeY = x.LatitudeY,
											LongitudeX = x.LongitudeX,
											RoutingCode = x.RoutingCode,
											TerminalID = x.TerminalID,
											ZipCode = x.ZipCode,
											ZipCodeSourceId = x.ZipCodeSourceId,
											ZipCodeSourceName = s.SourceName,
											IsManuallyAddedZipCode = x.IsManuallyAddedZipCode,
										});

				if (!string.IsNullOrWhiteSpace(searchParameter))
				{
					dataSource = dataSource
						.Where(x => x.ZipCode.Contains(searchParameter)
						|| x.City.Contains(searchParameter)
						);
				}

				listOfZipCodeInformation = await dataSource.ToListAsync();
			}

			return listOfZipCodeInformation;
		}

		public async Task<string> GetCountryBySource(Guid sourceID)
		{
			var country = await _zhipsterLocationDbContext.ZipCodeSources.Where(x => x.ZipCodeSourceId == sourceID).FirstOrDefaultAsync();

			return country.CountryCode;
		}

		public async Task<ZipCodeInformation> GetZipCodeBySourceAndId(Guid sourceID, Guid zipCodeId)
		{
			var localZipCodeObject = new ZipCodeInformation();

			IQueryable<ZipCodeInformation> dataSource;

			var source = await _zhipsterLocationDbContext.ZipCodeSources.Where(x => x.ZipCodeSourceId == sourceID).FirstOrDefaultAsync();

			if (source != null)
			{
				switch (source.CountryCode)
				{
					case "SE":
						dataSource = _zhipsterLocationDbContext.SEZipCodes.Where(x => x.ZipCodeSourceId == source.ZipCodeSourceId && x.SEZipCodeId == zipCodeId).Select(x => new ZipCodeInformation
						{
							CountryCode = "SE",
							City = x.City,
							Municipality = x.Municipality,
							County = x.County,
							CreatedDate = x.CreatedDate,
							IsTypeBox = x.IsTypeBox,
							LatitudeY = x.LatitudeY,
							LongitudeX = x.LongitudeX,
							RoutingCode = x.RoutingCode,
							TerminalID = x.TerminalID,
							ZipCode = x.ZipCode,
							ZipCodeSourceId = x.ZipCodeSourceId,
							ZipCodeSourceName = source.SourceName,
							IsManuallyAddedZipCode = x.IsManuallyAddedZipCode,
							ZipCodeId = x.SEZipCodeId,
						});

						localZipCodeObject = await dataSource.FirstOrDefaultAsync();
						break;

					case "NO":
						dataSource = _zhipsterLocationDbContext.NOZipCodes.Where(x => x.ZipCodeSourceId == source.ZipCodeSourceId && x.NOZipCodeId == zipCodeId).Select(x => new ZipCodeInformation
						{
							CountryCode = "NO",
							City = x.City,
							Municipality = x.Municipality,
							County = x.County,
							CreatedDate = x.CreatedDate,
							IsTypeBox = x.IsTypeBox,
							LatitudeY = x.LatitudeY,
							LongitudeX = x.LongitudeX,
							RoutingCode = x.RoutingCode,
							TerminalID = x.TerminalID,
							ZipCode = x.ZipCode,
							ZipCodeSourceId = x.ZipCodeSourceId,
							ZipCodeSourceName = source.SourceName,
							IsManuallyAddedZipCode = x.IsManuallyAddedZipCode,
							ZipCodeId = x.NOZipCodeId,
						});

						localZipCodeObject = await dataSource.FirstOrDefaultAsync();
						break;

					case "DK":
						dataSource = _zhipsterLocationDbContext.DKZipCodes.Where(x => x.ZipCodeSourceId == source.ZipCodeSourceId && x.DKZipCodeId == zipCodeId).Select(x => new ZipCodeInformation
						{
							CountryCode = "DK",
							City = x.City,
							Municipality = x.Municipality,
							County = x.County,
							CreatedDate = x.CreatedDate,
							IsTypeBox = x.IsTypeBox,
							LatitudeY = x.LatitudeY,
							LongitudeX = x.LongitudeX,
							RoutingCode = x.RoutingCode,
							TerminalID = x.TerminalID,
							ZipCode = x.ZipCode,
							ZipCodeSourceId = x.ZipCodeSourceId,
							ZipCodeSourceName = source.SourceName,
							IsManuallyAddedZipCode = x.IsManuallyAddedZipCode,
							ZipCodeId = x.DKZipCodeId,
						});

						localZipCodeObject = await dataSource.FirstOrDefaultAsync();
						break;

					case "FI":
						dataSource = _zhipsterLocationDbContext.FIZipCodes.Where(x => x.ZipCodeSourceId == source.ZipCodeSourceId && x.FIZipCodeId == zipCodeId).Select(x => new ZipCodeInformation
						{
							CountryCode = "FI",
							City = x.City,
							Municipality = x.Municipality,
							County = x.County,
							CreatedDate = x.CreatedDate,
							IsTypeBox = x.IsTypeBox,
							LatitudeY = x.LatitudeY,
							LongitudeX = x.LongitudeX,
							RoutingCode = x.RoutingCode,
							TerminalID = x.TerminalID,
							ZipCode = x.ZipCode,
							ZipCodeSourceId = x.ZipCodeSourceId,
							ZipCodeSourceName = source.SourceName,
							IsManuallyAddedZipCode = x.IsManuallyAddedZipCode,
							ZipCodeId = x.FIZipCodeId,
						});

						localZipCodeObject = await dataSource.FirstOrDefaultAsync();
						break;

					case "NL":
						dataSource = _zhipsterLocationDbContext.NLZipCodes.Where(x => x.ZipCodeSourceId == source.ZipCodeSourceId && x.NLZipCodeId == zipCodeId).Select(x => new ZipCodeInformation
						{
							CountryCode = "NL",
							City = x.City,
							Municipality = x.Municipality,
							County = x.County,
							CreatedDate = x.CreatedDate,
							IsTypeBox = x.IsTypeBox,
							LatitudeY = x.LatitudeY,
							LongitudeX = x.LongitudeX,
							RoutingCode = x.RoutingCode,
							TerminalID = x.TerminalID,
							ZipCode = x.ZipCode,
							ZipCodeSourceId = x.ZipCodeSourceId,
							ZipCodeSourceName = source.SourceName,
							IsManuallyAddedZipCode = x.IsManuallyAddedZipCode,
							ZipCodeId = x.NLZipCodeId,
						});

						localZipCodeObject = await dataSource.FirstOrDefaultAsync();
						break;

					case "DE":
						dataSource = _zhipsterLocationDbContext.DEZipCodes.Where(x => x.ZipCodeSourceId == source.ZipCodeSourceId && x.DEZipCodeId == zipCodeId).Select(x => new ZipCodeInformation
						{
							CountryCode = "DE",
							City = x.City,
							Municipality = x.Municipality,
							County = x.County,
							CreatedDate = x.CreatedDate,
							IsTypeBox = x.IsTypeBox,
							LatitudeY = x.LatitudeY,
							LongitudeX = x.LongitudeX,
							RoutingCode = x.RoutingCode,
							TerminalID = x.TerminalID,
							ZipCode = x.ZipCode,
							ZipCodeSourceId = x.ZipCodeSourceId,
							ZipCodeSourceName = source.SourceName,
							IsManuallyAddedZipCode = x.IsManuallyAddedZipCode,
							ZipCodeId = x.DEZipCodeId,
						});

						localZipCodeObject = await dataSource.FirstOrDefaultAsync();
						break;

					case "US":
						dataSource = _zhipsterLocationDbContext.USZipCodes.Where(x => x.ZipCodeSourceId == source.ZipCodeSourceId && x.USZipCodeId == zipCodeId).Select(x => new ZipCodeInformation
						{
							CountryCode = "US",
							StateCode = x.StateCode,
							City = x.City,
							Municipality = x.Municipality,
							County = x.County,
							CreatedDate = x.CreatedDate,
							IsTypeBox = x.IsTypeBox,
							LatitudeY = x.LatitudeY,
							LongitudeX = x.LongitudeX,
							RoutingCode = x.RoutingCode,
							TerminalID = x.TerminalID,
							ZipCode = x.ZipCode,
							ZipCodeSourceId = x.ZipCodeSourceId,
							ZipCodeSourceName = source.SourceName,
							IsManuallyAddedZipCode = x.IsManuallyAddedZipCode,
							ZipCodeId = x.USZipCodeId,
						});

						localZipCodeObject = await dataSource.FirstOrDefaultAsync();
						break;

					case "BE":
						dataSource = _zhipsterLocationDbContext.BEZipCodes.Where(x => x.ZipCodeSourceId == source.ZipCodeSourceId && x.BEZipCodeId == zipCodeId).Select(x => new ZipCodeInformation
						{
							CountryCode = "BE",
							City = x.City,
							Municipality = x.Municipality,
							County = x.County,
							CreatedDate = x.CreatedDate,
							IsTypeBox = x.IsTypeBox,
							LatitudeY = x.LatitudeY,
							LongitudeX = x.LongitudeX,
							RoutingCode = x.RoutingCode,
							TerminalID = x.TerminalID,
							ZipCode = x.ZipCode,
							ZipCodeSourceId = x.ZipCodeSourceId,
							ZipCodeSourceName = source.SourceName,
							IsManuallyAddedZipCode = x.IsManuallyAddedZipCode,
							ZipCodeId = x.BEZipCodeId,
						});

						localZipCodeObject = await dataSource.FirstOrDefaultAsync();
						break;

					case "FO":
						dataSource = _zhipsterLocationDbContext.FOZipCodes.Where(x => x.ZipCodeSourceId == source.ZipCodeSourceId && x.FOZipCodeId == zipCodeId).Select(x => new ZipCodeInformation
						{
							CountryCode = "FO",
							City = x.City,
							Municipality = x.Municipality,
							County = x.County,
							CreatedDate = x.CreatedDate,
							IsTypeBox = x.IsTypeBox,
							LatitudeY = x.LatitudeY,
							LongitudeX = x.LongitudeX,
							RoutingCode = x.RoutingCode,
							TerminalID = x.TerminalID,
							ZipCode = x.ZipCode,
							ZipCodeSourceId = x.ZipCodeSourceId,
							ZipCodeSourceName = source.SourceName,
							IsManuallyAddedZipCode = x.IsManuallyAddedZipCode,
							ZipCodeId = x.FOZipCodeId,
						});

						localZipCodeObject = await dataSource.FirstOrDefaultAsync();
						break;

					case "GL":
						dataSource = _zhipsterLocationDbContext.GLZipCodes.Where(x => x.ZipCodeSourceId == source.ZipCodeSourceId && x.GLZipCodeId == zipCodeId).Select(x => new ZipCodeInformation
						{
							CountryCode = "GL",
							City = x.City,
							Municipality = x.Municipality,
							County = x.County,
							CreatedDate = x.CreatedDate,
							IsTypeBox = x.IsTypeBox,
							LatitudeY = x.LatitudeY,
							LongitudeX = x.LongitudeX,
							RoutingCode = x.RoutingCode,
							TerminalID = x.TerminalID,
							ZipCode = x.ZipCode,
							ZipCodeSourceId = x.ZipCodeSourceId,
							ZipCodeSourceName = source.SourceName,
							IsManuallyAddedZipCode = x.IsManuallyAddedZipCode,
							ZipCodeId = x.GLZipCodeId,
						});

						localZipCodeObject = await dataSource.FirstOrDefaultAsync();
						break;

					case "IS":
						dataSource = _zhipsterLocationDbContext.ISZipCodes.Where(x => x.ZipCodeSourceId == source.ZipCodeSourceId && x.ISZipCodeId == zipCodeId).Select(x => new ZipCodeInformation
						{
							CountryCode = "IS",
							City = x.City,
							Municipality = x.Municipality,
							County = x.County,
							CreatedDate = x.CreatedDate,
							IsTypeBox = x.IsTypeBox,
							LatitudeY = x.LatitudeY,
							LongitudeX = x.LongitudeX,
							RoutingCode = x.RoutingCode,
							TerminalID = x.TerminalID,
							ZipCode = x.ZipCode,
							ZipCodeSourceId = x.ZipCodeSourceId,
							ZipCodeSourceName = source.SourceName,
							IsManuallyAddedZipCode = x.IsManuallyAddedZipCode,
							ZipCodeId = x.ISZipCodeId,
						});

						localZipCodeObject = await dataSource.FirstOrDefaultAsync();
						break;

					case "SJ":
						dataSource = _zhipsterLocationDbContext.SJZipCodes.Where(x => x.ZipCodeSourceId == source.ZipCodeSourceId && x.SJZipCodeId == zipCodeId).Select(x => new ZipCodeInformation
						{
							CountryCode = "SJ",
							City = x.City,
							Municipality = x.Municipality,
							County = x.County,
							CreatedDate = x.CreatedDate,
							IsTypeBox = x.IsTypeBox,
							LatitudeY = x.LatitudeY,
							LongitudeX = x.LongitudeX,
							RoutingCode = x.RoutingCode,
							TerminalID = x.TerminalID,
							ZipCode = x.ZipCode,
							ZipCodeSourceId = x.ZipCodeSourceId,
							ZipCodeSourceName = source.SourceName,
							IsManuallyAddedZipCode = x.IsManuallyAddedZipCode,
							ZipCodeId = x.SJZipCodeId,
						});

						localZipCodeObject = await dataSource.FirstOrDefaultAsync();
						break;
				}
			}

			return localZipCodeObject;
		}
	}
}