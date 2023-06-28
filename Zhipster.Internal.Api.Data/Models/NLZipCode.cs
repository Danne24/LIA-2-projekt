﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Zhipster.Internal.Api.Data.Models
{
	public class NLZipCode
	{
		[Key]
		[Column("NLZipCodeId", Order = 0)]
		public Guid NLZipCodeId { get; set; }

		[Column("CreatedDate", Order = 1)]
		public DateTime CreatedDate { get; set; }

		[Column("ZipCode", Order = 2)]
		[StringLength(5)]
		public string ZipCode { get; set; }

		[Column("City", Order = 3)]
		[StringLength(100)]
		public string City { get; set; }

		[Column("Municipality", Order = 4)]
		[StringLength(100)]
		public string Municipality { get; set; }

		[Column("County", Order = 5)]
		[StringLength(100)]
		public string County { get; set; }

		[Column("LatitudeY", Order = 6)]
		[StringLength(25)]
		public string LatitudeY { get; set; }

		[Column("LongitudeX", Order = 7)]
		[StringLength(25)]
		public string LongitudeX { get; set; }

		[StringLength(25)]
		public string RoutingCode { get; set; }

		[StringLength(25)]
		public string TerminalID { get; set; }

		public bool IsTypeBox { get; set; }

		public bool IsManuallyAddedZipCode { get; set; }

		public Guid ZipCodeSourceId { get; set; }
	}
}