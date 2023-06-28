using System.Collections.Generic;
using System.Threading.Tasks;
using Zhipster.Internal.Api.Location.Helpers;
using Zhipster.Internal.Api.Location.Models.DropPoint;
using Zhipster.Internal.Api.Location.Services.BudbeeDropPointService;
using Zhipster.Internal.Api.Location.Services.DHL.DHLFreightSweden.DHLFreightSwedenDropPointService;
using Zhipster.Internal.Api.Location.Services.DHLParcelConnect.DHLParcelConnectDropPointService;
using Zhipster.Internal.Api.Location.Services.GLSDropPointService;
using Zhipster.Internal.Api.Location.Services.PostiDropPointService;
using Zhipster.Internal.Api.Location.Services.PostNordDropPointService;
using Zhipster.Internal.Api.Location.Services.Schenker.SchenkerFinland.SchenkerFinlandDropPointService;
using Zhipster.Internal.Api.Location.Services.Schenker.SchenkerSweden.SchenkerBoxDropPointService;
using Zhipster.Internal.Api.Location.Services.Schenker.SchenkerSweden.SchenkerOmbudDropPointService;

namespace Zhipster.Internal.Api.Location.Services
{
	public class DropPointService : IDropPointService
	{
		private readonly IBringDropPointService _bringDropPointService;
		private readonly IDHLFreightSwedenDropPointService _dhldDropPointService;
		private readonly IDHLParcelConnectDropPointService _dhlParcelConnectDropPointService;
		private readonly IPostNordDropPointService _postNordDropPointService;
		private readonly ISchenkerSwedenOmbudDropPointService _schenkerOmbudDropPointService;
		private readonly ISchenkerSwedenBoxDropPointService _schenkerBoxDropPointService;
		private readonly ISchenkerFinlandDropPointService _schenkerFinlandDropPointService;
		private readonly IBudbeeDropPointService _budbeeDropPointService;
		private readonly IPostiDropPointService _postiDropPointService;
		private readonly IGLSDropPointService _glsDropPointService;

		public DropPointService(IBringDropPointService bringDropPointService, IDHLFreightSwedenDropPointService dhldDropPointService, IDHLParcelConnectDropPointService dhlParcelConnectDropPointService, IPostNordDropPointService postNordDropPointService, ISchenkerSwedenOmbudDropPointService schenkerOmbudDropPointService, ISchenkerSwedenBoxDropPointService schenkerBoxDropPointService, ISchenkerFinlandDropPointService schenkerFinlandDropPointService, IBudbeeDropPointService budbeeDropPointService, IPostiDropPointService postiDropPointService, IGLSDropPointService glsDropPointService)
		{
			_bringDropPointService = bringDropPointService;
			_dhldDropPointService = dhldDropPointService;
			_dhlParcelConnectDropPointService = dhlParcelConnectDropPointService;
			_postNordDropPointService = postNordDropPointService;
			_schenkerOmbudDropPointService = schenkerOmbudDropPointService;
			_schenkerBoxDropPointService = schenkerBoxDropPointService;
			_schenkerFinlandDropPointService = schenkerFinlandDropPointService;
			_budbeeDropPointService = budbeeDropPointService;
			_postiDropPointService = postiDropPointService;
			_glsDropPointService = glsDropPointService;
		}

		public async Task<List<DropPoint>> GetDropPoints(GetDropPointRequest dropPointRequest)
		{
			if (dropPointRequest.ForwarderId == ForwarderHelper.BringForwarderId || dropPointRequest.ForwarderId == ForwarderHelper.BringParcelSwedenForwarderId)
			{
				//Get Bring DropPoints API

				return await _bringDropPointService.GetDropPoints(dropPointRequest);
			}
			else if (dropPointRequest.ForwarderId == ForwarderHelper.DHLFreightSwedenId)
			{
				if (dropPointRequest.FreightServiceName == "Service Point")
				{
					return await _dhldDropPointService.GetDropPoints(dropPointRequest);
				}
				else if (dropPointRequest.FreightServiceName == "Parcel Connect (Service Point)" || dropPointRequest.FreightServiceName == "Parcel Connect (Parcelshop)")
				{
					return await _dhlParcelConnectDropPointService.GetDropPoints(dropPointRequest);
				}
			}
			else if (dropPointRequest.ForwarderId == ForwarderHelper.PostNordSwedenId || dropPointRequest.ForwarderId == ForwarderHelper.PostNordNorwayId)
			{
				//Get PostNord Sweden and Norway DropPoints API

				return await _postNordDropPointService.GetDropPoints(dropPointRequest);
			}
			else if (dropPointRequest.ForwarderId == ForwarderHelper.SchenkerSwedenId)
			{
				//Get Schenker Sweden DropPoints API

				if (dropPointRequest.FreightServiceName == "Parcel Ombud")
				{
					return await _schenkerOmbudDropPointService.GetDropPoints(dropPointRequest);
				}
				else if (dropPointRequest.FreightServiceName == "Parcel Box")
				{
					return await _schenkerBoxDropPointService.GetDropPoints(dropPointRequest);
				}
			}
			else if (dropPointRequest.ForwarderId == ForwarderHelper.SchenkerFinlandId)
			{
				//Get Schenker Finland DropPoints API

				return await _schenkerFinlandDropPointService.GetDropPoints(dropPointRequest);
			}

			else if (dropPointRequest.ForwarderId == ForwarderHelper.BudbeeId)
			{
				//Get Budbee DropPoints API

				return await _budbeeDropPointService.GetDropPoints(dropPointRequest);
			}

			else if (dropPointRequest.ForwarderId == ForwarderHelper.PostiId)
			{
				//Get Posti DropPoints API

				return await _postiDropPointService.GetDropPoints(dropPointRequest);
			}

			else if (dropPointRequest.ForwarderId == ForwarderHelper.GLSId || dropPointRequest.ForwarderId == ForwarderHelper.GLSGlobalId)
			{
				//Get GLS DropPoints API

				return await _glsDropPointService.GetDropPoints(dropPointRequest);
			}

			return new List<DropPoint>();
		}
	}
}