using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Zhipster.Internal.Api.Location.Models.DHLFreightSweden
{
	public class DHLFreightSwedenPostalCodesResponseJSON
	{
		[JsonProperty("success")]
		public bool Success { get; set; }

		[JsonProperty("data")]
		public List<ZipCode> Data { get; set; }
	}

	public class ZipCode
	{
		[JsonProperty("countryCode")]
		public string CountryCode { get; set; }

		[JsonProperty("postalCode")]
		public string PostalCode { get; set; }

		[JsonProperty("city")]
		public string City { get; set; }

		[JsonProperty("lineHaul")]
		public string LineHaul { get; set; }

		[JsonProperty("terminalId")]
		public string TerminalId { get; set; }

		[JsonProperty("deviating")]
		public bool Deviating { get; set; }

		[JsonProperty("updatedDate")]
		public DateTimeOffset UpdatedDate { get; set; }

		[JsonProperty("bookable")]
		public bool Bookable { get; set; }

		[JsonProperty("deleted")]
		public bool Deleted { get; set; }
	}
}