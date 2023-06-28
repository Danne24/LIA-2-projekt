using System.Text.RegularExpressions;

namespace Zhipster.Internal.Api.Location.Helpers
{
	public static class StandardizeCountryCodeHelper
	{
		public static string StandardizeCountryCode(string countryCode)
		{
			countryCode = Regex.Replace(countryCode, @" ", "").ToUpper();

			return countryCode;
		}
	}
}