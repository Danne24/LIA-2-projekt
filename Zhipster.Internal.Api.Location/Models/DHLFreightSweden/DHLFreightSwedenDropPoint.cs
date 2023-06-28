using System.Collections.Generic;

namespace Zhipster.Internal.Api.Location.Models.DHLFreightSweden
{
	public partial class DHlFreightServicePointRequestV2
	{
		public Address Address { get; set; }
		public List<string> FeatureCodes { get; set; }
		public List<string> BitCatCodes { get; set; }
		public int MaxNumberOfItems { get; set; }
	}

	public partial class Address
	{
		public string Street { get; set; }
		public string StreetNumber { get; set; }
		public string AdditionalAddressInfo { get; set; }
		public string CityName { get; set; }
		public string PostalCode { get; set; }
		public string CountryCode { get; set; }
	}

	public partial class DHlFreightServicePointResponseV2
	{
		public string Status { get; set; }
		public List<ServicePoint> ServicePoints { get; set; }
	}

	public partial class ServicePoint
	{
		public string Id { get; set; }
		public string Street { get; set; }
		public string Name { get; set; }
		public string CityName { get; set; }
		public string PostalCode { get; set; }
		public string CountryCode { get; set; }
		public decimal Distance { get; set; }
		public decimal RouteDistance { get; set; }
		public List<string> FeatureCodes { get; set; }
	}
}
