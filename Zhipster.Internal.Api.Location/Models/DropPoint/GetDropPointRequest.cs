using System;

namespace Zhipster.Internal.Api.Location.Models.DropPoint
{
	public class GetDropPointRequest
	{
		public Guid ForwarderId { get; set; }
		public string ForwarderName { get; set; }
		public string FreightServiceName { get; set; }

		public string DeliveryAddressStreet1 { get; set; }
		public string DeliveryAddressZipCode { get; set; }
		public string DeliveryAddressCity { get; set; }
		public string DeliveryAddressCountryCode { get; set; }
	}
}
