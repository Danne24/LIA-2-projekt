using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Zhipster.Internal.Api.Location.Models.GLS
{
	public static class HttpContentExtensions
	{
		public static async Task<T> XmlDeserializeAsync<T>(this HttpContent source) where T : class, new()
		{
			using (var stream = await source.ReadAsStreamAsync())
			{
				return new XmlSerializer(typeof(T)).Deserialize(stream) as T;
			}
		}
	}

	[XmlRoot(ElementName = "ParcelShopSearchResult", Namespace = "http://gls.dk/webservices/")]
	public class ParcelShopSearchResult
	{
		[XmlElement(ElementName = "accuracylevel", Namespace = "http://gls.dk/webservices/")]
		public string Accuracylevel { get; set; }
		[XmlElement(ElementName = "parcelshops", Namespace = "http://gls.dk/webservices/")]
		public ServicePoints ServicePoints { get; set; }
		[XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Xsd { get; set; }
		[XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Xsi { get; set; }
		[XmlAttribute(AttributeName = "xmlns")]
		public string Xmlns { get; set; }
	}

	[XmlRoot(ElementName = "PakkeshopData", Namespace = "http://gls.dk/webservices/")]
	public class ServicePoint
	{
		[XmlElement(ElementName = "Number", Namespace = "http://gls.dk/webservices/")]
		public string Identifier { get; set; }
		[XmlElement(ElementName = "CompanyName", Namespace = "http://gls.dk/webservices/")]
		public string CompanyName { get; set; }
		[XmlElement(ElementName = "Streetname", Namespace = "http://gls.dk/webservices/")]
		public string Streetname { get; set; }
		[XmlElement(ElementName = "Streetname2", Namespace = "http://gls.dk/webservices/")]
		public string Streetname2 { get; set; }
		[XmlElement(ElementName = "ZipCode", Namespace = "http://gls.dk/webservices/")]
		public string ZipCode { get; set; }
		[XmlElement(ElementName = "CityName", Namespace = "http://gls.dk/webservices/")]
		public string CityName { get; set; }
		[XmlElement(ElementName = "CountryCode", Namespace = "http://gls.dk/webservices/")]
		public string CountryCode { get; set; }
		[XmlElement(ElementName = "CountryCodeISO3166A2", Namespace = "http://gls.dk/webservices/")]
		public string CountryCodeISO3166A2 { get; set; }
		[XmlElement(ElementName = "Telephone", Namespace = "http://gls.dk/webservices/")]
		public string Telephone { get; set; }
		[XmlElement(ElementName = "Longitude", Namespace = "http://gls.dk/webservices/")]
		public string Longitude { get; set; }
		[XmlElement(ElementName = "Latitude", Namespace = "http://gls.dk/webservices/")]
		public string Latitude { get; set; }
		[XmlElement(ElementName = "DistanceMetersAsTheCrowFlies", Namespace = "http://gls.dk/webservices/")]
		public string DistanceMetersAsTheCrowFlies { get; set; }
	}

	[XmlRoot(ElementName = "parcelshops", Namespace = "http://gls.dk/webservices/")]
	public class ServicePoints
	{
		[XmlElement(ElementName = "PakkeshopData", Namespace = "http://gls.dk/webservices/")]
		public List<ServicePoint> ServicePointLocations { get; set; }
	}
}
