using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zhipster.Internal.Api.Data.Data;
using Zhipster.Internal.Api.Data.Models;
using Zhipster.Internal.Api.Location.Helpers;
using Zhipster.Internal.Api.Location.Models;

namespace Zhipster.Internal.Api.Location.Services.ForwarderZipCodeSourceService
{
	public class ForwarderZipCodeService : IForwarderZipCodeService
	{
		private readonly ZhipsterLocationDbContext _zhipsterLocationDbContext;

		public ForwarderZipCodeService(ZhipsterLocationDbContext zhipsterLocationDbContext)
		{
			_zhipsterLocationDbContext = zhipsterLocationDbContext;
		}

		public async Task InstallForwarderZipCodeSources()
		{
			if (_zhipsterLocationDbContext.ForwarderZipCodeSources.IsNullOrEmpty())
			{
				var forwarderSources = new List<ForwarderZipCodeSource>();

				forwarderSources.Add(new ForwarderZipCodeSource
				{
					ForwarderZipCodeSourceId = Guid.NewGuid(),
					ForwarderId = ForwarderHelper.DHLFreightSwedenId,
					ZipCodeSourceId = ZipCodeSourceHelper.DHLFreightSESource.SourceId,
					ForwarderName = "DHL Freight",
					CreatedDate = DateTime.Now,
				});

				forwarderSources.Add(new ForwarderZipCodeSource
				{
					ForwarderZipCodeSourceId = Guid.NewGuid(),
					ForwarderId = ForwarderHelper.SchenkerSwedenId,
					ZipCodeSourceId = ZipCodeSourceHelper.DHLFreightSESource.SourceId,
					ForwarderName = "DB Schenker",
					CreatedDate = DateTime.Now,
				});

				forwarderSources.Add(new ForwarderZipCodeSource
				{
					ForwarderZipCodeSourceId = Guid.NewGuid(),
					ForwarderId = ZipCodeSourceHelper.DHLFreightSESource.SourceId,
					ZipCodeSourceId = ZipCodeSourceHelper.DSVRoadSESource.SourceId,
					ForwarderName = "DB Schenker",
					CreatedDate = DateTime.Now,
				});

				forwarderSources.Add(new ForwarderZipCodeSource
				{
					ForwarderZipCodeSourceId = Guid.NewGuid(),
					ForwarderId = ForwarderHelper.BringForwarderId,
					ZipCodeSourceId = ZipCodeSourceHelper.BringSESource.SourceId,
					ForwarderName = "Bring",
					CreatedDate = DateTime.Now,
				});

				forwarderSources.Add(new ForwarderZipCodeSource
				{
					ForwarderZipCodeSourceId = Guid.NewGuid(),
					ForwarderId = ForwarderHelper.BringForwarderId,
					ZipCodeSourceId = ZipCodeSourceHelper.BringNOSource.SourceId,
					ForwarderName = "Bring",
					CreatedDate = DateTime.Now,
				});

				forwarderSources.Add(new ForwarderZipCodeSource
				{
					ForwarderZipCodeSourceId = Guid.NewGuid(),
					ForwarderId = ForwarderHelper.BringForwarderId,
					ZipCodeSourceId = ZipCodeSourceHelper.BringDKSource.SourceId,
					ForwarderName = "Bring",
					CreatedDate = DateTime.Now,
				});

				forwarderSources.Add(new ForwarderZipCodeSource
				{
					ForwarderZipCodeSourceId = Guid.NewGuid(),
					ForwarderId = ForwarderHelper.BringForwarderId,
					ZipCodeSourceId = ZipCodeSourceHelper.BringFISource.SourceId,
					ForwarderName = "Bring",
					CreatedDate = DateTime.Now,
				});

				forwarderSources.Add(new ForwarderZipCodeSource
				{
					ForwarderZipCodeSourceId = Guid.NewGuid(),
					ForwarderId = ForwarderHelper.BringForwarderId,
					ZipCodeSourceId = ZipCodeSourceHelper.BringNLSource.SourceId,
					ForwarderName = "Bring",
					CreatedDate = DateTime.Now,
				});

				forwarderSources.Add(new ForwarderZipCodeSource
				{
					ForwarderZipCodeSourceId = Guid.NewGuid(),
					ForwarderId = ForwarderHelper.BringForwarderId,
					ZipCodeSourceId = ZipCodeSourceHelper.BringDESource.SourceId,
					ForwarderName = "Bring",
					CreatedDate = DateTime.Now,
				});

				forwarderSources.Add(new ForwarderZipCodeSource
				{
					ForwarderZipCodeSourceId = Guid.NewGuid(),
					ForwarderId = ForwarderHelper.BringForwarderId,
					ZipCodeSourceId = ZipCodeSourceHelper.BringUSSource.SourceId,
					ForwarderName = "Bring",
					CreatedDate = DateTime.Now,
				});

				forwarderSources.Add(new ForwarderZipCodeSource
				{
					ForwarderZipCodeSourceId = Guid.NewGuid(),
					ForwarderId = ForwarderHelper.BringForwarderId,
					ZipCodeSourceId = ZipCodeSourceHelper.BringBESource.SourceId,
					ForwarderName = "Bring",
					CreatedDate = DateTime.Now,
				});

				forwarderSources.Add(new ForwarderZipCodeSource
				{
					ForwarderZipCodeSourceId = Guid.NewGuid(),
					ForwarderId = ForwarderHelper.BringForwarderId,
					ZipCodeSourceId = ZipCodeSourceHelper.BringFOSource.SourceId,
					ForwarderName = "Bring",
					CreatedDate = DateTime.Now,
				});

				forwarderSources.Add(new ForwarderZipCodeSource
				{
					ForwarderZipCodeSourceId = Guid.NewGuid(),
					ForwarderId = ForwarderHelper.BringForwarderId,
					ZipCodeSourceId = ZipCodeSourceHelper.BringGLSource.SourceId,
					ForwarderName = "Bring",
					CreatedDate = DateTime.Now,
				});

				forwarderSources.Add(new ForwarderZipCodeSource
				{
					ForwarderZipCodeSourceId = Guid.NewGuid(),
					ForwarderId = ForwarderHelper.BringForwarderId,
					ZipCodeSourceId = ZipCodeSourceHelper.BringISSource.SourceId,
					ForwarderName = "Bring",
					CreatedDate = DateTime.Now,
				});

				forwarderSources.Add(new ForwarderZipCodeSource
				{
					ForwarderZipCodeSourceId = Guid.NewGuid(),
					ForwarderId = ForwarderHelper.BringForwarderId,
					ZipCodeSourceId = ZipCodeSourceHelper.BringSJSource.SourceId,
					ForwarderName = "Bring",
					CreatedDate = DateTime.Now,
				});

				forwarderSources.Add(new ForwarderZipCodeSource
				{
					ForwarderZipCodeSourceId = Guid.NewGuid(),
					ForwarderId = ForwarderHelper.PostNordSwedenId,
					ZipCodeSourceId = ZipCodeSourceHelper.DHLFreightSESource.SourceId,
					ForwarderName = "PostNord Sweden",
					CreatedDate = DateTime.Now,
				});

				forwarderSources.Add(new ForwarderZipCodeSource
				{
					ForwarderZipCodeSourceId = Guid.NewGuid(),
					ForwarderId = ForwarderHelper.PostNordSwedenId,
					ZipCodeSourceId = ZipCodeSourceHelper.DSVRoadSESource.SourceId,
					ForwarderName = "PostNord Sweden",
					CreatedDate = DateTime.Now,
				});

				forwarderSources.Add(new ForwarderZipCodeSource
				{
					ForwarderZipCodeSourceId = Guid.NewGuid(),
					ForwarderId = Guid.Parse("ea7eece1-4bbe-432e-b01c-7c32be825761"),
					ZipCodeSourceId = ZipCodeSourceHelper.DSVRoadSESource.SourceId,
					ForwarderName = "DSV Road Sweden",
					CreatedDate = DateTime.Now,
				});

				await _zhipsterLocationDbContext.BulkInsertAsync(forwarderSources);
			}
		}

		public async Task<List<ZipCodeSourceInformation>> GetForwarderZipCodeSources(Guid forwarderId)
		{
			var forwarderZipCodeSourceIds = await _zhipsterLocationDbContext.ForwarderZipCodeSources.Where(x => x.ForwarderId == forwarderId).Select(x => x.ZipCodeSourceId).ToListAsync();

			return await _zhipsterLocationDbContext.ZipCodeSources.Where(x => forwarderZipCodeSourceIds.Contains(x.ZipCodeSourceId)).Select(x => new ZipCodeSourceInformation
			{
				APILink = x.APILink,
				CountryCode = x.CountryCode,
				CreatedDate = x.CreatedDate,
				LastChangedDate = x.LastChangedDate,
				SourceName = x.SourceName,
				SourceRecordCount = x.SourceRecordCount
			}).ToListAsync();
		}

		public async Task<ValidateZipCodeResponse> ValidateForwarderZipCode(Guid forwarderId, string zipCode, string countryCode)
		{
			ValidateZipCodeResponse returnZipCode = null;

			var forwarderZipCodeSourceIds = await _zhipsterLocationDbContext.ForwarderZipCodeSources.Where(x => x.ForwarderId == forwarderId).Select(x => x.ZipCodeSourceId).ToListAsync();

			var countryZipCodeSourceIds = await _zhipsterLocationDbContext.ZipCodeSources.Where(x => forwarderZipCodeSourceIds.Contains(x.ZipCodeSourceId) && x.CountryCode == countryCode).Select(x => x.ZipCodeSourceId).ToListAsync();

			if (countryZipCodeSourceIds.Any())
			{
				switch (countryCode)
				{
					case "SE":
						returnZipCode = await _zhipsterLocationDbContext.SEZipCodes.Where(x => countryZipCodeSourceIds.Contains(x.ZipCodeSourceId) && x.ZipCode == zipCode).Select(x => new ValidateZipCodeResponse
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
						returnZipCode = await _zhipsterLocationDbContext.NOZipCodes.Where(x => countryZipCodeSourceIds.Contains(x.ZipCodeSourceId) && x.ZipCode == zipCode).Select(x => new ValidateZipCodeResponse
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
						returnZipCode = await _zhipsterLocationDbContext.DKZipCodes.Where(x => countryZipCodeSourceIds.Contains(x.ZipCodeSourceId) && x.ZipCode == zipCode).Select(x => new ValidateZipCodeResponse
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
						returnZipCode = await _zhipsterLocationDbContext.FIZipCodes.Where(x => countryZipCodeSourceIds.Contains(x.ZipCodeSourceId) && x.ZipCode == zipCode).Select(x => new ValidateZipCodeResponse
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
						returnZipCode = await _zhipsterLocationDbContext.NLZipCodes.Where(x => countryZipCodeSourceIds.Contains(x.ZipCodeSourceId) && x.ZipCode == zipCode).Select(x => new ValidateZipCodeResponse
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
						returnZipCode = await _zhipsterLocationDbContext.DEZipCodes.Where(x => countryZipCodeSourceIds.Contains(x.ZipCodeSourceId) && x.ZipCode == zipCode).Select(x => new ValidateZipCodeResponse
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
						returnZipCode = await _zhipsterLocationDbContext.USZipCodes.Where(x => countryZipCodeSourceIds.Contains(x.ZipCodeSourceId) && x.ZipCode == zipCode).Select(x => new ValidateZipCodeResponse
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

					case "BE":
						returnZipCode = await _zhipsterLocationDbContext.BEZipCodes.Where(x => countryZipCodeSourceIds.Contains(x.ZipCodeSourceId) && x.ZipCode == zipCode).Select(x => new ValidateZipCodeResponse
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
						returnZipCode = await _zhipsterLocationDbContext.FOZipCodes.Where(x => countryZipCodeSourceIds.Contains(x.ZipCodeSourceId) && x.ZipCode == zipCode).Select(x => new ValidateZipCodeResponse
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
						returnZipCode = await _zhipsterLocationDbContext.GLZipCodes.Where(x => countryZipCodeSourceIds.Contains(x.ZipCodeSourceId) && x.ZipCode == zipCode).Select(x => new ValidateZipCodeResponse
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
						returnZipCode = await _zhipsterLocationDbContext.ISZipCodes.Where(x => countryZipCodeSourceIds.Contains(x.ZipCodeSourceId) && x.ZipCode == zipCode).Select(x => new ValidateZipCodeResponse
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
						returnZipCode = await _zhipsterLocationDbContext.SJZipCodes.Where(x => countryZipCodeSourceIds.Contains(x.ZipCodeSourceId) && x.ZipCode == zipCode).Select(x => new ValidateZipCodeResponse
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
			}
			else
			{
				returnZipCode = new ValidateZipCodeResponse
				{
					ZipCodeIsValid = true,
					ZipCodeMessage = "No Zip Code Source Connected to this forwarder."
				};
			}

			if (returnZipCode == null)
			{
				returnZipCode = new ValidateZipCodeResponse
				{
					ZipCodeIsValid = false
				};
			}
			else
			{
				returnZipCode.ZipCodeIsValid = true;
			}

			return returnZipCode;
		}

		public async Task<string> RemoveZipCodeSourceFromForwarder(Guid forwarderZipCodeSourceId)
		{
			var sourceExists = await _zhipsterLocationDbContext.ForwarderZipCodeSources
				.Where(x => x.ForwarderZipCodeSourceId == forwarderZipCodeSourceId).AnyAsync();

			if (sourceExists)
			{
				await _zhipsterLocationDbContext.ForwarderZipCodeSources.Where(x => x.ForwarderZipCodeSourceId == forwarderZipCodeSourceId).BatchDeleteAsync();

				return $"A Forwarder Zip Code Source with the Id {forwarderZipCodeSourceId} has been successfully deleted!";
			}
			else
			{
				return $"A Forwarder Zip Code Source with the Id {forwarderZipCodeSourceId} does not exist!";
			}
		}

		public async Task<string> AddZipCodeSourceToForwarder(Guid forwarderId, Guid zipCodeSourceId, string forwarderName)
		{
			var sourceExists = await _zhipsterLocationDbContext.ForwarderZipCodeSources
				.Where(x => x.ForwarderId == forwarderId && x.ZipCodeSourceId == zipCodeSourceId).AnyAsync();

			var newDatabaseObject = new ForwarderZipCodeSource();

			if (!sourceExists)
			{
				newDatabaseObject = new ForwarderZipCodeSource()
				{
					ForwarderZipCodeSourceId = new Guid(),
					CreatedDate = DateTime.Now,
					ForwarderName = forwarderName,
					ForwarderId = forwarderId,
					ZipCodeSourceId = zipCodeSourceId
				};

				await _zhipsterLocationDbContext.ForwarderZipCodeSources.AddAsync(newDatabaseObject);
				await _zhipsterLocationDbContext.SaveChangesAsync();

				return $"A Forwarder Zip Code Source object with the Id {newDatabaseObject.ForwarderZipCodeSourceId} has been successfully created!";
			}
			else
			{
				return "A Forwarder Zip Code Source object with that Id already exists in the database!";
			}
		}
	}
}