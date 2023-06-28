using System;
using System.ComponentModel.DataAnnotations;

namespace Zhipster.Internal.Api.Location.Models
{
	public class SourceInformation
	{
		public Guid SourceId { get; set; }

		public string SourceName { get; set; }

		[StringLength(2)]
		public string CountryCode { get; set; }

		public string APILink { get; set; }
	}
}
