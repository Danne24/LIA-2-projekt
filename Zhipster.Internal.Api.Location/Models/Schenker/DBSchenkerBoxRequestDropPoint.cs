using Newtonsoft.Json;

namespace Entrix.Logic.Models.Forwarder.DBSchenker
{
	public class DBSchenkerBoxRequest
	{
		[JsonProperty("City")]
		public string City { get; set; }

		[JsonProperty("StreetAddress")]
		public string StreetAddress { get; set; }

		[JsonProperty("PostalCode")]
		public string PostalCode { get; set; }

		[JsonProperty("LocationMaxDistance")]
		public int LocationMaxDistance { get; set; }

		[JsonProperty("LocationsMaxQty")]
		public int LocationsMaxQty { get; set; }

		[JsonProperty("RequiresLowBox")]
		public bool RequiresLowBox { get; set; }
	}
}
