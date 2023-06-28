using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Zhipster.Internal.Api.Location.Helpers;
using Zhipster.Internal.Api.Location.Models.Bring;
using Zhipster.Internal.Api.Location.Models.DropPoint;

namespace Zhipster.Internal.Api.Location.Services.PostiDropPointService
{
	public class PostiDropPointService : IPostiDropPointService
	{
		public async Task<List<DropPoint>> GetDropPoints(GetDropPointRequest dropPointRequest)
		{
			var dropPointList = new List<DropPoint>();

			try
			{
				var url = "http://locationservice.posti.com/location?locationZipCode=" + dropPointRequest.DeliveryAddressZipCode + "&countryCode=" + dropPointRequest.DeliveryAddressCountryCode + "&top=10&types=POSTOFFICE";

				var client = new HttpClient();

				var httpRequestMessage = new HttpRequestMessage
				{
					Method = HttpMethod.Get,
					RequestUri = new Uri(url),
				};

				var postiLocations = new List<Models.Posti.Location>();

				httpRequestMessage.Headers.Add(HttpRequestHeader.Accept.ToString(), "application/json");

				var response = await client.SendAsync(httpRequestMessage);
				if (response.IsSuccessStatusCode)
				{
					var json = await response.Content.ReadAsStringAsync();
					var postiResponse = await response.Content.ReadAsAsync<Models.Posti.PostiResponse>();
					if (postiResponse != null)
					{
						postiLocations = postiResponse.locations;
					}
				}

				if (postiLocations != null && postiLocations.Any())
				{
					foreach (var postiLocation in postiLocations)
					{
						if (postiLocation?.address?.en != null && postiLocation.locationName?.en != null)
						{
							var location = postiLocation.locationName.en;
							if (!string.IsNullOrWhiteSpace(postiLocation.id) && !string.IsNullOrWhiteSpace(location))
							{
								var dropPoint = new DropPoint
								{
									//AgentName = location.FormatAsTitleText(),
									//DistanceInMeters = 0,
									//Street1 = postiPointAddress.address.FormatAsTitleText(),
									//Zip = postiPointAddress.postalCode,
									//City = postiPointAddress.municipality.FormatAsTitleText(),
									//CountryIsoCode = deliveryCountryCode,
									//AgentLocationId = point.routingServiceCode,
									//AgentRoutingId = point.id,

									DropPointID = postiLocation.id,
									AddressName = FirstLetterIsCapitalHelper.MakeFirstLetterBig(postiLocation.locationName.en),
									AddressStreet1 = FirstLetterIsCapitalHelper.MakeFirstLetterBig(postiLocation.address.en.streetName + " " + postiLocation.address.en.streetNumber),
									AddressCountryCode = postiLocation.countryCode,
									AddressCity = FirstLetterIsCapitalHelper.MakeFirstLetterBig(postiLocation.address.en.municipality),
									AddressZipCode = StandardizeZipCodeHelper.StandardizeZipCode(postiLocation.postalCode, postiLocation.address.en.municipality),
								};

								dropPointList.Add(dropPoint);
							}
						}
					}
				}
			}
			catch
			{

			}

			return dropPointList;
		}
	}
}
