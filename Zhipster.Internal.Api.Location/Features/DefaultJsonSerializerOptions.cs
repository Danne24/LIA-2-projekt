using System.Text.Json;

namespace Zhipster.Internal.Api.Location.Features.Authentication
{
	public static class DefaultJsonSerializerOptions
	{
		public static JsonSerializerOptions Options => new JsonSerializerOptions
		{
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
			IgnoreNullValues = true
		};
	}
}
