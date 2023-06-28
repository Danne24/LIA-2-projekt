namespace Zhipster.Internal.Api.Location.Models.DropPoint
{
	public class DropPoint
	{
		public string DropPointID { get; set; }
		public string AddressName { get; set; }
		public string AddressStreet1 { get; set; }
		public string AddressStreet2 { get; set; }
		public string AddressZipCode { get; set; }
		public string AddressCity { get; set; }
		public string AddressCountryCode { get; set; }
		public decimal DistanceInMeters { get; set; }
	}
}
