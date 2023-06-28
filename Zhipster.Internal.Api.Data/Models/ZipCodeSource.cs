using System.ComponentModel.DataAnnotations;

namespace Zhipster.Internal.Api.Data.Models
{
	public class ZipCodeSource
	{
		[Key]
		public Guid ZipCodeSourceId { get; set; }

		public DateTime CreatedDate { get; set; }

		public DateTime LastChangedDate { get; set; }

		[StringLength(100)]
		public string SourceName { get; set; }

		[StringLength(2)]
		public string CountryCode { get; set; }

		[StringLength(300)]
		public string APILink { get; set; }

		public int SourceRecordCount { get; set; }
	}
}