using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Zhipster.Internal.Api.Data.Models
{
	public class ForwarderZipCodeSource
	{
		[Key]
		[Column("ForwarderZipCodeSourceId", Order = 0)]
		public Guid ForwarderZipCodeSourceId { get; set; }

		[Column("CreatedDate", Order = 1)]
		public DateTime CreatedDate { get; set; }

		[Column("ForwarderId", Order = 2)]
		public Guid ForwarderId { get; set; }

		[Column("ZipCodeSourceId", Order = 3)]
		public Guid ZipCodeSourceId { get; set; }

		[Column("ForwarderName", Order = 4)]
		[StringLength(100)]
		public string ForwarderName { get; set; }
	}
}