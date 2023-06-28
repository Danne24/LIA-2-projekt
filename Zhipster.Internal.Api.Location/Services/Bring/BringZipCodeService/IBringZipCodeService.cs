using System.Threading.Tasks;

namespace Zhipster.Internal.Api.Location.Services
{
	public interface IBringZipCodeService
	{
		Task<bool> InstallZipCodes();
	}
}
