using System.Collections.Generic;

namespace Zhipster.Internal.Api.Location.Models
{
	public class ValidateZipCodeRequest
	{
		public string ZipCode { get; set; }

		public string CountryCode { get; set; }
	}
}
