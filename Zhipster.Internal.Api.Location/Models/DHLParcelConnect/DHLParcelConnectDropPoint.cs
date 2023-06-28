using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zhipster.Internal.Api.Location.Models.DHLParcelConnect
{
	public partial class ParcelConnect
	{
		[JsonProperty("locations")]
		public List<LocationElement> Locations { get; set; }
	}

	public partial class LocationElement
	{
		[JsonProperty("url")]
		public string Url { get; set; }

		[JsonProperty("location")]
		public LocationLocation Location { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("distance")]
		public long? Distance { get; set; }

		[JsonProperty("place")]
		public Place Place { get; set; }

		[JsonProperty("openingHours")]
		public List<OpeningHour> OpeningHours { get; set; }

		[JsonProperty("closurePeriods")]
		public List<object> ClosurePeriods { get; set; }

		[JsonProperty("serviceTypes")]
		public List<string> ServiceTypes { get; set; }
	}

	public partial class LocationLocation
	{
		[JsonProperty("ids")]
		public List<Id> Ids { get; set; }

		[JsonProperty("keyword")]
		public string Keyword { get; set; }

		[JsonProperty("keywordId")]
		public string KeywordId { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}

	public partial class Id
	{
		[JsonProperty("locationId")]
		public string LocationId { get; set; }

		[JsonProperty("provider")]
		public string Provider { get; set; }
	}

	public partial class OpeningHour
	{
		[JsonProperty("opens")]
		public DateTimeOffset Opens { get; set; }

		[JsonProperty("closes")]
		public DateTimeOffset Closes { get; set; }

		[JsonProperty("dayOfWeek")]
		public Uri DayOfWeek { get; set; }
	}

	public partial class Place
	{
		[JsonProperty("address")]
		public Address Address { get; set; }

		[JsonProperty("geo")]
		public Geo Geo { get; set; }
	}

	public partial class Address
	{
		[JsonProperty("countryCode")]
		public string CountryCode { get; set; }

		[JsonProperty("postalCode")]
		public string PostalCode { get; set; }

		[JsonProperty("addressLocality")]
		public string AddressLocality { get; set; }

		[JsonProperty("streetAddress")]
		public string StreetAddress { get; set; }
	}

	public partial class Geo
	{
		[JsonProperty("latitude")]
		public double Latitude { get; set; }

		[JsonProperty("longitude")]
		public double Longitude { get; set; }
	}
}
