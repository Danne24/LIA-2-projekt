using System.Collections.Generic;
using System.Threading.Tasks;
using Zhipster.Internal.Api.Location.Models.DropPoint;

namespace Zhipster.Internal.Api.Location.Services.BudbeeDropPointService
{
	public interface IBudbeeDropPointService
	{
		Task<List<DropPoint>> GetDropPoints(GetDropPointRequest dropPointRequest);
	}
}
