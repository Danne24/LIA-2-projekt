using System.Threading.Tasks;

namespace Zhipster.Internal.Api.Location.Services.DSVRoadSwedenZipCodeService
{
	public interface IDSVRoadSwedenZipCodeService
	{
		Task<bool> InstallZipCodes();
	}
}