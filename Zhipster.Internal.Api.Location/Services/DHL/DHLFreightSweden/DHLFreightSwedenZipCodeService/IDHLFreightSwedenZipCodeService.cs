using System.Threading.Tasks;

namespace Zhipster.Internal.Api.Location.Services.DHL.DHLFreightSweden.DHLFreightSwedenZipCodeService
{
    public interface IDHLFreightSwedenZipCodeService
    {
        Task<bool> InstallZipCodes();
    }
}
