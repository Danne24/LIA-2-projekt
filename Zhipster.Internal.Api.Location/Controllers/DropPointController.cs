using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zhipster.Internal.Api.Location.Helpers;
using Zhipster.Internal.Api.Location.Models.DropPoint;
using Zhipster.Internal.Api.Location.Services;

namespace Zhipster.Internal.Api.Location.Controllers
{
	[Authorize]
	[ApiController]
	[Route("[controller]")]
	public class DropPointController
	{
		private readonly IDropPointService _dropPointService;

		public DropPointController(IDropPointService dropPointService)
		{
			_dropPointService = dropPointService;
		}

		[HttpPost("GetDropPoints")]
		public async Task<List<DropPoint>> GetDropPoints(GetDropPointRequest dropPointRequest)
		{
			dropPointRequest.DeliveryAddressZipCode = StandardizeZipCodeHelper.StandardizeZipCode(dropPointRequest.DeliveryAddressZipCode, dropPointRequest.DeliveryAddressCountryCode);

			return await _dropPointService.GetDropPoints(dropPointRequest);
		}
	}
}