using Newtonsoft.Json;

namespace Entrix.Logic.Models.Forwarder.DBSchenker
{
	public class DBSchenkerBoxResponse
	{
		[JsonProperty("Name")]
		public string Name { get; set; }

		[JsonProperty("AddressId")]
		public string AddressId { get; set; }

		[JsonProperty("Address")]
		public Address Address { get; set; }

		[JsonProperty("ProviderAddon")]
		public string ProviderAddon { get; set; }
	}

	public class Address
	{
		[JsonProperty("Name")]
		public string Name { get; set; }

		[JsonProperty("AddressLine1")]
		public string AddressLine1 { get; set; }

		[JsonProperty("AddressLine2")]
		public string AddressLine2 { get; set; }

		[JsonProperty("City")]
		public string City { get; set; }

		[JsonProperty("PostalCode")]
		public string PostalCode { get; set; }

		[JsonProperty("CountryCode")]
		public string CountryCode { get; set; }
	}
}
