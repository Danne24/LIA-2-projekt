using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zhipster.Internal.Api.Location.Models.Bring
{
	public partial class BringPickupPoints
	{
		[JsonProperty("pickupPoint")]
		public List<PickupPoint> PickupPoint { get; set; }
	}

	public partial class PickupPoint
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("unitId")]
		public string UnitId { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("address")]
		public string Address { get; set; }

		[JsonProperty("postalCode")]
		public string PostalCode { get; set; }

		[JsonProperty("city")]
		public string City { get; set; }

		[JsonProperty("countryCode")]
		public string CountryCode { get; set; }

		[JsonProperty("municipality")]
		public string Municipality { get; set; }

		[JsonProperty("county")]
		public string County { get; set; }

		[JsonProperty("visitingAddress")]
		public string VisitingAddress { get; set; }

		[JsonProperty("visitingPostalCode")]
		public string VisitingPostalCode { get; set; }

		[JsonProperty("visitingCity")]
		public string VisitingCity { get; set; }

		[JsonProperty("openingHoursNorwegian")]
		public string OpeningHoursNorwegian { get; set; }

		[JsonProperty("openingHoursEnglish")]
		public string OpeningHoursEnglish { get; set; }

		[JsonProperty("openingHoursFinnish")]
		public string OpeningHoursFinnish { get; set; }

		[JsonProperty("openingHoursDanish")]
		public string OpeningHoursDanish { get; set; }

		[JsonProperty("openingHoursSwedish")]
		public string OpeningHoursSwedish { get; set; }

		[JsonProperty("latitude")]
		public double Latitude { get; set; }

		[JsonProperty("longitude")]
		public double Longitude { get; set; }

		[JsonProperty("utmX")]
		public string UtmX { get; set; }

		[JsonProperty("utmY")]
		public string UtmY { get; set; }

		[JsonProperty("postenMapsLink")]
		public Uri PostenMapsLink { get; set; }

		[JsonProperty("googleMapsLink")]
		public Uri GoogleMapsLink { get; set; }

		[JsonProperty("distanceInKm")]
		public string DistanceInKm { get; set; }

		[JsonProperty("distanceType")]
		public string DistanceType { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("additionalServiceCode")]
		public string AdditionalServiceCode { get; set; }

		[JsonProperty("routeMapsLink")]
		public Uri RouteMapsLink { get; set; }

		[JsonProperty("locationDescription", NullValueHandling = NullValueHandling.Ignore)]
		public string LocationDescription { get; set; }
	}
}
