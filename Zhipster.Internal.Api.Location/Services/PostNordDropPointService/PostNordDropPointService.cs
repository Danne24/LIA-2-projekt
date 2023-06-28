using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Zhipster.Internal.Api.Location.Helpers;
using Zhipster.Internal.Api.Location.Models.DropPoint;
using Zhipster.Internal.Api.Location.Models.PostNord;

namespace Zhipster.Internal.Api.Location.Services.PostNordDropPointService
{
	public class PostNordDropPointService : IPostNordDropPointService
	{
		public async Task<List<DropPoint>> GetDropPoints(GetDropPointRequest dropPointRequest)
		{
			var dropPointList = new List<DropPoint>();
			try
			{
				var url = "https://api2.postnord.com/rest/businesslocation/v5/servicepoints/nearest/byaddress?apikey=&returnType=json&countryCode=" + dropPointRequest.DeliveryAddressCountryCode + "&city=" + dropPointRequest.DeliveryAddressCity + "&postalCode=" + dropPointRequest.DeliveryAddressZipCode + "&streetName=" + dropPointRequest.DeliveryAddressStreet1 + "&numberOfServicePoints=10&locale=en&responseFilter=public&context=optionalservicepoint";

				var client = new HttpClient();

				var httpRequestMessage = new HttpRequestMessage
				{
					Method = HttpMethod.Get,
					RequestUri = new Uri(url),
				};

				var pickupPoints = new List<Models.PostNord.ServicePoint>();

				httpRequestMessage.Headers.Add(HttpRequestHeader.Accept.ToString(), "application/json");

				var response = await client.SendAsync(httpRequestMessage);
				if (response.IsSuccessStatusCode)
				{
					var json = await response.Content.ReadAsStringAsync();
					var postNordPickupPoints = await response.Content.ReadAsAsync<PostNordDropPoint>();
					if (postNordPickupPoints?.ServicePointInformationResponse?.ServicePoints != null)
					{
						pickupPoints = postNordPickupPoints.ServicePointInformationResponse.ServicePoints;
					}
				}

				if (pickupPoints != null && pickupPoints.Any())
				{
					foreach (var pickupPoint in pickupPoints)
					{
						var dropPoint = new DropPoint
						{
							DropPointID = pickupPoint.ServicePointId,
							AddressName = FirstLetterIsCapitalHelper.MakeFirstLetterBig(pickupPoint.Name),
							AddressStreet1 = FirstLetterIsCapitalHelper.MakeFirstLetterBig(pickupPoint.DeliveryAddress.StreetName + " " + pickupPoint.DeliveryAddress.StreetNumber),
							AddressCountryCode = pickupPoint.DeliveryAddress.CountryCode,
							AddressCity = FirstLetterIsCapitalHelper.MakeFirstLetterBig(pickupPoint.DeliveryAddress.City),
							AddressZipCode = StandardizeZipCodeHelper.StandardizeZipCode(pickupPoint.DeliveryAddress.PostalCode, pickupPoint.DeliveryAddress.City),
							DistanceInMeters = 999999999,
						};

						if (pickupPoint.RouteDistance > 0)
						{
							var meters = Convert.ToDecimal(pickupPoint.RouteDistance);
							dropPoint.DistanceInMeters = Math.Round(meters, 0);
						}

						if (string.IsNullOrWhiteSpace(dropPoint.AddressStreet1))
						{
							dropPoint.AddressStreet1 = dropPoint.AddressStreet1;
						}

						dropPointList.Add(dropPoint);
					}
				}
			}
			catch
			{

			}

			return dropPointList.OrderBy(a => a.DistanceInMeters).ToList();
		}
	}
}
