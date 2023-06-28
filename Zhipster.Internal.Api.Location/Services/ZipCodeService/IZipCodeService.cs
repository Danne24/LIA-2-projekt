using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zhipster.Internal.Api.Location.Models;

namespace Zhipster.Internal.Api.Location.Services
{
	public interface IZipCodeService
	{
		Task<ValidateZipCodeResponse> ValidateZipCode(string zipCode, string countryCode);

		Task<List<ZipCodeSourceInformation>> GetZipCodeSources();

		Task<List<ZipCodeInformation>> GetZipCodesByCountry(string countryCode, string searchParameter);

		Task<List<ZipCodeInformation>> GetZipCodesBySource(Guid sourceID, string searchParameter);

		Task<ZipCodeInformation> GetZipCodeBySourceAndId(Guid sourceID, Guid zipCodeId);

		Task<String> GetCountryBySource(Guid sourceID);

		Task InstallAndUpdateZipCodes();

		Task<string> AddZipCodeManually(ZipCodeInformation zipCodeInformation);

		Task<String> RemoveZipCodeFromSource(Guid zipCodeSourceId, Guid zipCodeId);
	}
}