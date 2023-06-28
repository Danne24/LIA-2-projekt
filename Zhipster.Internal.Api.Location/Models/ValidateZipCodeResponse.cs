namespace Zhipster.Internal.Api.Location.Models
{
	public class ValidateZipCodeResponse
	{
		public string CountryCode { get; set; }

		public string StateCode { get; set; }

		public string County { get; set; }

		public string Municipality { get; set; }

		public string City { get; set; }

		public string Latitude { get; set; }

		public string Longitude { get; set; }

		public bool PoBox { get; set; }

		public string ZipCode { get; set; }

		public bool ZipCodeIsValid { get; set; }

		public string ZipCodeMessage { get; set; }
	}
}