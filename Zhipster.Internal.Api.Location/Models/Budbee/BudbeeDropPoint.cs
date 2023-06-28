using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace Zhipster.Internal.Api.Location.Models.Budbee
{
	public partial class BudbeeBoxResponse
	{
		[JsonProperty("lockers")]
		public List<Locker> Lockers { get; set; }
	}

	public partial class Locker
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("address")]
		public Address Address { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("directions")]
		public string Directions { get; set; }

		[JsonProperty("openingHours")]
		public OpeningHours OpeningHours { get; set; }

		[JsonProperty("estimatedDelivery")]
		public DateTimeOffset EstimatedDelivery { get; set; }

		[JsonProperty("cutoff")]
		public DateTimeOffset Cutoff { get; set; }

		[JsonProperty("distance")]
		public long Distance { get; set; }

		[JsonProperty("label")]
		public string Label { get; set; }
	}

	public partial class Address
	{
		[JsonProperty("street")]
		public string Street { get; set; }

		[JsonProperty("postalCode")]
		public string PostalCode { get; set; }

		[JsonProperty("city")]
		public string City { get; set; }

		[JsonProperty("country")]
		public string Country { get; set; }

		[JsonProperty("coordinate")]
		public Coordinate Coordinate { get; set; }
	}

	public partial class Coordinate
	{
		[JsonProperty("latitude")]
		public double Latitude { get; set; }

		[JsonProperty("longitude")]
		public double Longitude { get; set; }
	}

	public partial class OpeningHours
	{
		[JsonProperty("periods")]
		public List<Period> Periods { get; set; }

		[JsonProperty("weekdayText")]
		public List<string> WeekdayText { get; set; }
	}

	public partial class Period
	{
		[JsonProperty("open")]
		public Open Open { get; set; }

		[JsonProperty("close")]
		public Open Close { get; set; }
	}

	public partial class Open
	{
		[JsonProperty("day")]
		public string Day { get; set; }

		[JsonProperty("time")]
		public string Time { get; set; }
	}
}
