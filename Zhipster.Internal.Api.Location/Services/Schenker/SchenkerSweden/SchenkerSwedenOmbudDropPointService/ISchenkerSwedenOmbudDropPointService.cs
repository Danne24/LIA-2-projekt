﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Zhipster.Internal.Api.Location.Models.DropPoint;

namespace Zhipster.Internal.Api.Location.Services.Schenker.SchenkerSweden.SchenkerOmbudDropPointService
{
	public interface ISchenkerSwedenOmbudDropPointService
	{
		Task<List<DropPoint>> GetDropPoints(GetDropPointRequest dropPointRequest);
	}
}
