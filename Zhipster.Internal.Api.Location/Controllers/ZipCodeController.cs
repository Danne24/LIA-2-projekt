using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zhipster.Internal.Api.Location.Helpers;
using Zhipster.Internal.Api.Location.Models;
using Zhipster.Internal.Api.Location.Services;
using Zhipster.Internal.Api.Location.Services.ForwarderZipCodeSourceService;

namespace Zhipster.Internal.Api.Location.Controllers
{
	[Authorize]
	[ApiController]
	[Route("[controller]")]
	public class ZipCodeController
	{
		private readonly IZipCodeService _zipCodeService;
		private readonly IForwarderZipCodeService _forwarderZipCodeService;

		public ZipCodeController(IZipCodeService zipCodeService, IForwarderZipCodeService forwarderZipCodeService)
		{
			_zipCodeService = zipCodeService;
			_forwarderZipCodeService = forwarderZipCodeService;
		}

		[HttpGet("ValidateZipCode")]
		public async Task<ValidateZipCodeResponse> ValidateZipCode(string zipCode, string countryCode)
		{
			countryCode = StandardizeCountryCodeHelper.StandardizeCountryCode(countryCode);
			zipCode = StandardizeZipCodeHelper.StandardizeZipCode(zipCode, countryCode);

			return await _zipCodeService.ValidateZipCode(zipCode, countryCode);
		}

		[HttpGet("ValidateForwarderZipCode")]
		public async Task<ValidateZipCodeResponse> ValidateForwarderZipCode(Guid forwarderId, string zipCode, string countryCode)
		{
			countryCode = StandardizeCountryCodeHelper.StandardizeCountryCode(countryCode);
			zipCode = StandardizeZipCodeHelper.StandardizeZipCode(zipCode, countryCode);

			return await _forwarderZipCodeService.ValidateForwarderZipCode(forwarderId, zipCode, countryCode);
		}

		[HttpGet("GetZipCodeSources")]
		public async Task<List<ZipCodeSourceInformation>> GetZipCodeSources()
		{
			return await _zipCodeService.GetZipCodeSources();
		}

		[HttpGet("GetZipCodesByCountry")]
		public async Task<List<ZipCodeInformation>> GetZipCodesByCountry(string countryCode, string searchParameter)
		{
			return await _zipCodeService.GetZipCodesByCountry(countryCode, searchParameter);
		}

		[HttpGet("GetZipCodesBySource")]
		public async Task<List<ZipCodeInformation>> GetZipCodesBySource(Guid sourceID, string searchParameter)
		{
			return await _zipCodeService.GetZipCodesBySource(sourceID, searchParameter);
		}

		[HttpGet("GetZipCodeBySourceAndId")]
		public async Task<ZipCodeInformation> GetZipCodeBySourceAndId(Guid sourceID, Guid zipCodeId)
		{
			return await _zipCodeService.GetZipCodeBySourceAndId(sourceID, zipCodeId);
		}

		[HttpGet("GetCountryBySource")]
		public async Task<string> GetCountryBySource(Guid sourceID)
		{
			return await _zipCodeService.GetCountryBySource(sourceID);
		}

		[HttpGet("InstallAndUpdateZipCodes")]
		public async Task InstallAndUpdateZipCodes()
		{
			await _zipCodeService.InstallAndUpdateZipCodes();
		}

		[HttpGet("GetForwarderZipCodeSources")]
		public async Task<List<ZipCodeSourceInformation>> GetForwarderZipCodeSources(Guid forwarderId)
		{
			return await _forwarderZipCodeService.GetForwarderZipCodeSources(forwarderId);
		}

		[HttpGet("RemoveZipCodeSourceFromForwarder")]
		public async Task<string> RemoveZipCodeSourceFromForwarder(Guid forwarderZipCodeSourceId)
		{
			return await _forwarderZipCodeService.RemoveZipCodeSourceFromForwarder(forwarderZipCodeSourceId);
		}

		[HttpGet("AddZipCodeSourceToForwarder")]
		public async Task<string> AddZipCodeSourceToForwarder(Guid forwarderId, Guid zipCodeSourceId, string forwarderName)
		{
			return await _forwarderZipCodeService.AddZipCodeSourceToForwarder(forwarderId, zipCodeSourceId, forwarderName);
		}

		[HttpPost("AddZipCodeManually")]
		public async Task<string> AddZipCodeManually(ZipCodeInformation zipCodeInformation)
		{
			return await _zipCodeService.AddZipCodeManually(zipCodeInformation);
		}

		[HttpGet("RemoveZipCodeFromSource")]
		public async Task<string> RemoveZipCodeFromSource(Guid zipCodeSourceId, Guid zipCodeId)
		{
			return await _zipCodeService.RemoveZipCodeFromSource(zipCodeSourceId, zipCodeId);
		}
	}
}