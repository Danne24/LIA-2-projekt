using System.Collections.Generic;

namespace Zhipster.Internal.Api.Location.Models.Posti
{
	public class PostiResponse
	{
		public List<Location> locations { get; set; }
	}

	public class Fi
	{
		public string address { get; set; }
		public string streetName { get; set; }
		public string streetNumber { get; set; }
		public string postalCode { get; set; }
		public string postalCodeName { get; set; }
		public string municipality { get; set; }
	}

	public class Sv
	{
		public string address { get; set; }
		public string streetName { get; set; }
		public string streetNumber { get; set; }
		public string postalCode { get; set; }
		public string postalCodeName { get; set; }
		public string municipality { get; set; }
	}

	public class En
	{
		public string address { get; set; }
		public string streetName { get; set; }
		public string streetNumber { get; set; }
		public string postalCode { get; set; }
		public string postalCodeName { get; set; }
		public string municipality { get; set; }
	}

	public class CountryAddress
	{
		public Fi fi { get; set; }
		public Sv sv { get; set; }
		public En en { get; set; }
	}

	public class PublicName
	{
		public string fi { get; set; }
		public string sv { get; set; }
		public string en { get; set; }
	}

	public class LabelName
	{
		public string fi { get; set; }
		public string sv { get; set; }
		public string en { get; set; }
	}

	public class LocationName
	{
		public string fi { get; set; }
		public string sv { get; set; }
		public string en { get; set; }
	}

	public class AdditionalInfo
	{
		public string fi { get; set; }
		public string sv { get; set; }
		public string en { get; set; }
	}

	public class OpeningTime
	{
		public string weekday { get; set; }
		public string timeFrom { get; set; }
		public string timeTo { get; set; }
		public string timeToWithPoint { get; set; }
		public string timeFromWithPoint { get; set; }
	}

	public class Location
	{
		public string id { get; set; }
		public string type { get; set; }
		public string postalCode { get; set; }
		public IList<string> postalCodeAreas { get; set; }
		public CountryAddress address { get; set; }
		public PublicName publicName { get; set; }
		public LabelName labelName { get; set; }
		public string countryCode { get; set; }
		public LocationName locationName { get; set; }
		public object postalOfficeType { get; set; }
		public string dropOfTimeParcel { get; set; }
		public string dropOfTimeLetters { get; set; }
		public string dropOfTimeExpress { get; set; }
		public AdditionalInfo additionalInfo { get; set; }
		public string customerServicePhoneNumber { get; set; }
		public IList<OpeningTime> openingTimes { get; set; }
		public string availability { get; set; }
		public bool wheelChairAccess { get; set; }
		public string pupCode { get; set; }
		public string routingServiceCode { get; set; }
		public string partnerType { get; set; }
		public string category { get; set; }
		public string emptyTime { get; set; }
		public string lastEmptyTime { get; set; }
		public string letterClass { get; set; }
		public string capacity { get; set; }
	}
}
