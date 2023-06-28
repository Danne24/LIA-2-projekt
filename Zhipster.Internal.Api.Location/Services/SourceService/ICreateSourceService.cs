using System.Threading.Tasks;
using Zhipster.Internal.Api.Location.Models;

namespace Zhipster.Internal.Api.Location.Services.SourceService
{
	public interface ICreateSourceService
	{
		Task CreateSource(SourceInformation source);
	}
}
