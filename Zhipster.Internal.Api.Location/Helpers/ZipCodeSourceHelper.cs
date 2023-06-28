using System;
using Zhipster.Internal.Api.Location.Models;

namespace Zhipster.Internal.Api.Location.Helpers
{
	public static class ZipCodeSourceHelper
	{
		public static SourceInformation BringSESource = new SourceInformation
		{
			SourceId = Guid.Parse("2C986CDE-AB0C-40C9-8E98-58AE1F3A7E63"),
			SourceName = "BringSE",
			CountryCode = "SE",
			APILink = "https://api.bring.com/address/api/SE/postal-codes"
		};

		public static SourceInformation BringNOSource = new SourceInformation
		{
			SourceId = Guid.Parse("E828A30C-6642-4A32-8DCC-585C51C51EE3"),
			SourceName = "BringNO",
			CountryCode = "NO",
			APILink = "https://api.bring.com/address/api/NO/postal-codes"
		};

		public static SourceInformation BringDKSource = new SourceInformation
		{
			SourceId = Guid.Parse("A5A5655A-B816-4655-B5DE-E20D65229044"),
			SourceName = "BringDK",
			CountryCode = "DK",
			APILink = "https://api.bring.com/address/api/DK/postal-codes"
		};

		public static SourceInformation BringFISource = new SourceInformation
		{
			SourceId = Guid.Parse("6231DA1E-01A4-4CDF-AD55-FC1331806B90"),
			SourceName = "BringFI",
			CountryCode = "FI",
			APILink = "https://api.bring.com/address/api/FI/postal-codes"
		};

		public static SourceInformation BringNLSource = new SourceInformation
		{
			SourceId = Guid.Parse("8000C20F-3FEE-4165-A99B-0356928ACA36"),
			SourceName = "BringNL",
			CountryCode = "NL",
			APILink = "https://api.bring.com/address/api/NL/postal-codes"
		};

		public static SourceInformation BringDESource = new SourceInformation
		{
			SourceId = Guid.Parse("134A8576-B39E-40E6-A0E1-DE2B88303470"),
			SourceName = "BringDE",
			CountryCode = "DE",
			APILink = "https://api.bring.com/address/api/DE/postal-codes"
		};

		public static SourceInformation BringUSSource = new SourceInformation
		{
			SourceId = Guid.Parse("0A17959C-F478-4F1F-8FF4-757BA7970096"),
			SourceName = "BringUS",
			CountryCode = "US",
			APILink = "https://api.bring.com/address/api/US/postal-codes"
		};

		public static SourceInformation BringBESource = new SourceInformation
		{
			SourceId = Guid.Parse("B3C16493-48F1-43D2-A5AF-97F3F6B4152E"),
			SourceName = "BringBE",
			CountryCode = "BE",
			APILink = "https://api.bring.com/address/api/BE/postal-codes"
		};

		public static SourceInformation BringFOSource = new SourceInformation
		{
			SourceId = Guid.Parse("1261BC1B-1282-483E-8944-B1F0A354A599"),
			SourceName = "BringFO",
			CountryCode = "FO",
			APILink = "https://api.bring.com/address/api/FO/postal-codes"
		};

		public static SourceInformation BringGLSource = new SourceInformation
		{
			SourceId = Guid.Parse("2E6FB816-AE8B-4975-B5AC-4B1F6DA6291E"),
			SourceName = "BringGL",
			CountryCode = "GL",
			APILink = "https://api.bring.com/address/api/GL/postal-codes"
		};

		public static SourceInformation BringISSource = new SourceInformation
		{
			SourceId = Guid.Parse("B07D30E1-19D4-4B04-A4D5-49344CE08833"),
			SourceName = "BringIS",
			CountryCode = "IS",
			APILink = "https://api.bring.com/address/api/IS/postal-codes"
		};

		public static SourceInformation BringSJSource = new SourceInformation
		{
			SourceId = Guid.Parse("4E7B873C-644E-4568-9AD1-1634117FF8A9"),
			SourceName = "BringSJ",
			CountryCode = "SJ",
			APILink = "https://api.bring.com/address/api/SJ/postal-codes"
		};

		public static SourceInformation DHLFreightSESource = new SourceInformation
		{
			SourceId = Guid.Parse("DB3FEBA7-8D4C-40D9-B99A-3D399B2619D5"),
			SourceName = "DHLFreightSE",
			CountryCode = "SE",
			APILink = "https://api.freight-logistics.dhl.com/postalcodeapi/v1/postalcodes/se/updated"
		};

		public static SourceInformation DSVRoadSESource = new SourceInformation
		{
			SourceId = Guid.Parse("0EE289AC-6870-4D00-A006-819DD6B8A974"),
			SourceName = "DSVRoadSE",
			CountryCode = "SE",
			APILink = ""
		};
	}
}