using System.Collections.Generic;
using System.Threading.Tasks;
using Zhipster.Internal.Api.Location.Models.DropPoint;

namespace Zhipster.Internal.Api.Location.Services.DHL.DHLFreightSweden.DHLFreightSwedenDropPointService
{
    public interface IDHLFreightSwedenDropPointService
    {
        Task<List<DropPoint>> GetDropPoints(GetDropPointRequest dropPointRequest);
    }
}
