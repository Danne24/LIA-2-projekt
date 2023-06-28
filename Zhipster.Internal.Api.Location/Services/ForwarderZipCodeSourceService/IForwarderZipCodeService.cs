using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Zhipster.Internal.Api.Data.Data;
using Zhipster.Internal.Api.Location.Models;
using Zhipster.Internal.Api.Location.Models.DHLFreightSweden;

namespace Zhipster.Internal.Api.Location.Services.ForwarderZipCodeSourceService
{
	public interface IForwarderZipCodeService
	{
		Task InstallForwarderZipCodeSources();

		Task<string> RemoveZipCodeSourceFromForwarder(Guid forwarderZipCodeSourceId);

		Task<string> AddZipCodeSourceToForwarder(Guid forwarderId, Guid zipCodeSourceId, string forwarderName);

		Task<List<ZipCodeSourceInformation>> GetForwarderZipCodeSources(Guid forwarderId);

		Task<ValidateZipCodeResponse> ValidateForwarderZipCode(Guid forwarderId, string zipCode, string countryCode);
	}
}
