using System.Collections.Generic;
using System.Threading.Tasks;
using Zhipster.Internal.Api.Location.Models.DropPoint;

namespace Zhipster.Internal.Api.Location.Services.Schenker.SchenkerFinland.SchenkerFinlandDropPointService
{
	public interface ISchenkerFinlandDropPointService
	{
		Task<List<DropPoint>> GetDropPoints(GetDropPointRequest dropPointRequest);
	}
}
