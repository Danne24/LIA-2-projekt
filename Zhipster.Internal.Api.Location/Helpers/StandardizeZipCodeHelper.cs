using System.Text.RegularExpressions;

namespace Zhipster.Internal.Api.Location.Helpers
{
	public static class StandardizeZipCodeHelper
	{
		public static string StandardizeZipCode(string zipCode, string countryCode)
		{
			switch (countryCode)
			{
				case "NO":
				case "DK":
				case "SE":
				case "FI":
				case "NL":
				case "DE":
				case "US":
				case "BE":
				case "FO":
				case "GL":
				case "IS":
				case "SJ":
					zipCode = Regex.Replace(zipCode, @" ", "");
					break;
			}

			return zipCode;
		}
	}
}