using System;

namespace Zhipster.Internal.Api.Location.Models
{
	public class ZipCodeSourceInformation
	{
		public DateTime CreatedDate { get; set; }

		public DateTime LastChangedDate { get; set; }

		public string SourceName { get; set; }

		public Guid SourceId { get; set; }

		public string CountryCode { get; set; }

		public string APILink { get; set; }

		public int SourceRecordCount { get; set; }
	}
}