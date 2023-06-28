using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using Zhipster.Internal.Api.Location.Helpers;
using Zhipster.Internal.Api.Location.Models.DropPoint;
using Zhipster.Internal.Api.Location.Models.Bring;
using System.Globalization;

namespace Zhipster.Internal.Api.Location.Services
{
	public class BringDropPointService : IBringDropPointService
	{
		public async Task<List<DropPoint>> GetDropPoints(GetDropPointRequest dropPointRequest)
		{
			var servicePointList = new List<DropPoint>();
			try
			{
				dropPointRequest.DeliveryAddressStreet1 = Uri.EscapeDataString(dropPointRequest.DeliveryAddressStreet1);

				var url = "https://api.bring.com/pickuppoint/api/pickuppoint/" + dropPointRequest.DeliveryAddressCountryCode + "/postalCode/" + dropPointRequest.DeliveryAddressZipCode + ".json?street=" + dropPointRequest.DeliveryAddressStreet1;



				var client = new HttpClient();
				client.DefaultRequestHeaders.Add("X-MyBring-API-Uid", "");
				client.DefaultRequestHeaders.Add("X-MyBring-API-Key", "");
				client.DefaultRequestHeaders.Add("X-Bring-Client-URL", "");

				var httpRequestMessage = new HttpRequestMessage
				{
					Method = HttpMethod.Get,
					RequestUri = new Uri(url),
				};

				var pickupPoints = new List<PickupPoint>();

				httpRequestMessage.Headers.Add(HttpRequestHeader.Accept.ToString(), "application/json");

				var response = await client.SendAsync(httpRequestMessage).ConfigureAwait(false);
				if (response.IsSuccessStatusCode)
				{
					var json = await response.Content.ReadAsStringAsync();
					var bringPickupPoints = await response.Content.ReadAsAsync<BringPickupPoints>();
					if (bringPickupPoints.PickupPoint != null && bringPickupPoints.PickupPoint.Any())
					{
						pickupPoints = bringPickupPoints.PickupPoint;
					}
				}



				if (pickupPoints != null && pickupPoints.Any())
				{
					foreach (var pickupPoint in pickupPoints)
					{
						var dropPoint = new DropPoint
						{
							DropPointID = pickupPoint.Id,
							//	AgentRoutingId = point.UnitId,
							AddressName = FirstLetterIsCapitalHelper.MakeFirstLetterBig(pickupPoint.Name),
							AddressStreet1 = FirstLetterIsCapitalHelper.MakeFirstLetterBig(pickupPoint.Address),
							AddressCountryCode = pickupPoint.CountryCode,
							AddressCity = FirstLetterIsCapitalHelper.MakeFirstLetterBig(pickupPoint.City),
							AddressZipCode = StandardizeZipCodeHelper.StandardizeZipCode(pickupPoint.PostalCode, pickupPoint.CountryCode),
							DistanceInMeters = 999999999,
						};

						if (!string.IsNullOrWhiteSpace(pickupPoint.DistanceInKm))
						{
							var culture = CultureInfo.CreateSpecificCulture("en-US");
							decimal distanceInKilometres;
							decimal.TryParse(pickupPoint.DistanceInKm, NumberStyles.AllowDecimalPoint, culture, out distanceInKilometres);

							if (distanceInKilometres > 0)
							{
								var meters = distanceInKilometres * 1000;
								dropPoint.DistanceInMeters = Math.Round(meters, 0);
							}
						}

						if (string.IsNullOrWhiteSpace(dropPoint.AddressStreet1))
						{
							dropPoint.AddressStreet1 = dropPoint.AddressStreet1;
						}

						servicePointList.Add(dropPoint);
					}
				}
			}
			catch
			{

			}

			return servicePointList.OrderBy(a => a.DistanceInMeters).ToList();
		}
	}
}
