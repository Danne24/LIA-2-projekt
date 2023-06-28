using Newtonsoft.Json;
using System.Collections.Generic;

namespace Zhipster.Internal.Api.Location.Models.PostNord
{
	public class PostNordDropPoint
	{
		[JsonProperty("servicePointInformationResponse")]
		public ServicePointInformationResponse ServicePointInformationResponse { get; set; }
	}

	public class ServicePointInformationResponse
	{
		[JsonProperty("customerSupportPhoneNo")]
		public string CustomerSupportPhoneNo { get; set; }

		[JsonProperty("coordinate")]
		public Coordinate Coordinate { get; set; }

		[JsonProperty("compositeFault")]
		public CompositeFault CompositeFault { get; set; }

		[JsonProperty("servicePoints")]
		public List<ServicePoint> ServicePoints { get; set; }
	}

	public class CompositeFault
	{
		[JsonProperty("faults")]
		public List<Fault> Faults { get; set; }
	}

	public class Fault
	{
		[JsonProperty("faultCode")]
		public string FaultCode { get; set; }

		[JsonProperty("explanationText")]
		public string ExplanationText { get; set; }

		[JsonProperty("paramValues")]
		public List<ParamValue> ParamValues { get; set; }
	}

	public class ParamValue
	{
		[JsonProperty("param")]
		public string Param { get; set; }

		[JsonProperty("value")]
		public string Value { get; set; }
	}

	public class Coordinate
	{
		[JsonProperty("srId")]
		public string SrId { get; set; }

		[JsonProperty("northing")]
		public long Northing { get; set; }

		[JsonProperty("easting")]
		public long Easting { get; set; }

		[JsonProperty("countryCode")]
		public string CountryCode { get; set; }
	}

	public class ServicePoint
	{
		[JsonProperty("servicePointId")]
		public string ServicePointId { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("routeDistance")]
		public long RouteDistance { get; set; }

		[JsonProperty("visitingAddress")]
		public Address VisitingAddress { get; set; }

		[JsonProperty("deliveryAddress")]
		public Address DeliveryAddress { get; set; }

		[JsonProperty("coordinate")]
		public Coordinate Coordinate { get; set; }

		[JsonProperty("routingCode")]
		public string RoutingCode { get; set; }

		[JsonProperty("handlingOffice")]
		public string HandlingOffice { get; set; }

		[JsonProperty("dropOffTime")]
		public DropOffTime DropOffTime { get; set; }

		[JsonProperty("locationDetail")]
		public string LocationDetail { get; set; }

		[JsonProperty("openingHour")]
		public List<OpeningHour> OpeningHour { get; set; }
	}

	public class Address
	{
		[JsonProperty("streetName")]
		public string StreetName { get; set; }

		[JsonProperty("streetNumber")]
		public string StreetNumber { get; set; }

		[JsonProperty("postalCode")]
		public string PostalCode { get; set; }

		[JsonProperty("city")]
		public string City { get; set; }

		[JsonProperty("countryCode")]
		public string CountryCode { get; set; }
	}

	public class DropOffTime
	{
		[JsonProperty("dropOffTimeDatas")]
		public DropOffTimeDatas DropOffTimeDatas { get; set; }
	}

	public class DropOffTimeDatas
	{
		[JsonProperty("dropOffTimeData")]
		public List<DropOffTimeDatum> DropOffTimeData { get; set; }
	}

	public class DropOffTimeDatum
	{
		[JsonProperty("latestTime")]
		public string LatestTime { get; set; }

		[JsonProperty("day")]
		public string Day { get; set; }
	}

	public class OpeningHour
	{
		[JsonProperty("from1")]
		public string From1 { get; set; }

		[JsonProperty("to1")]
		public string To1 { get; set; }

		[JsonProperty("from2")]
		public string From2 { get; set; }

		[JsonProperty("to2")]
		public string To2 { get; set; }

		[JsonProperty("day")]
		public string Day { get; set; }
	}
}
