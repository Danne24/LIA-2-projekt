using Newtonsoft.Json;
using System.Collections.Generic;

namespace Zhipster.Internal.Api.Test.Models.Bring
{
	public class BringPostalCodesResponseJSON
	{
		[JsonProperty("navigation")]
		public Navigation Navigation { get; set; }

		[JsonProperty("postal_codes")]
		public List<PostalCode> PostalCodes { get; set; }
	}

	public class Navigation
	{
		[JsonProperty("self")]
		public string Self { get; set; }

		[JsonProperty("total_hits")]
		public int TotalHits { get; set; }
	}

	public class PostalCode
	{
		[JsonProperty("county")]
		public string County { get; set; }

		[JsonProperty("municipality")]
		public string Municipality { get; set; }

		[JsonProperty("city")]
		public string City { get; set; }

		[JsonProperty("latitude")]
		public string Latitude { get; set; }

		[JsonProperty("longitude")]
		public string Longitude { get; set; }

		[JsonProperty("po_box")]
		public bool PoBox { get; set; }

		[JsonProperty("postal_code")]

		public int ZipCode { get; set; }
	}
}
