using System;

namespace Zhipster.Internal.Api.Location.Models
{
	public class ZipCodeInformation
	{
		public DateTime CreatedDate { get; set; }

		public string CountryCode { get; set; }

		public string StateCode { get; set; }

		public string ZipCode { get; set; }

		public Guid ZipCodeId { get; set; }

		public string City { get; set; }

		public string Municipality { get; set; }

		public string County { get; set; }

		public string LatitudeY { get; set; }

		public string LongitudeX { get; set; }

		public string RoutingCode { get; set; }

		public string TerminalID { get; set; }

		public bool IsTypeBox { get; set; }

		public bool IsManuallyAddedZipCode { get; set; }

		public Guid ZipCodeSourceId { get; set; }

		public string ZipCodeSourceName { get; set; }
	}
}