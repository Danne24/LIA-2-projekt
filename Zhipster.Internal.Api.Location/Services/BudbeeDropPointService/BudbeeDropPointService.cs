using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Zhipster.Internal.Api.Location.Models.Budbee;
using Zhipster.Internal.Api.Location.Models.DropPoint;
using System.Globalization;
using Zhipster.Internal.Api.Location.Helpers;

namespace Zhipster.Internal.Api.Location.Services.BudbeeDropPointService
{
	public class BudbeeDropPointService : IBudbeeDropPointService
	{
		public async Task<List<DropPoint>> GetDropPoints(GetDropPointRequest dropPointRequest)
		{
			var dropPointList = new List<DropPoint>();

			try
			{
				var budbeeBaseUrl = "https://api.budbee.com";
				var username = "";
				var password = "";

				var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
				if (environment == "Production")
				{

				}

				var budbeeUrl = $"/boxes/postalcodes/validate/{dropPointRequest.DeliveryAddressCountryCode}/{dropPointRequest.DeliveryAddressZipCode}";

				var authorization = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));
				var authValue = new AuthenticationHeaderValue("Basic", authorization);
				var client = new HttpClient
				{
					DefaultRequestHeaders = { Authorization = authValue }
				};

				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.budbee.boxes-v1+json"));
				var response = await client.GetAsync(budbeeBaseUrl + budbeeUrl);

				var jsonResponse = await response.Content.ReadAsStringAsync();
				if (response.IsSuccessStatusCode)
				{
					var pickupPoints = JsonConvert.DeserializeObject<BudbeeBoxResponse>(jsonResponse);
					if (pickupPoints.Lockers != null && pickupPoints.Lockers.Any())
					{
						foreach (var pickupPoint in pickupPoints.Lockers)
						{
							if (pickupPoint.Address != null && !string.IsNullOrWhiteSpace(pickupPoint.Id))
							{
								var dropPoint = new DropPoint
								{
									DropPointID = pickupPoint.Id,
									AddressName = FirstLetterIsCapitalHelper.MakeFirstLetterBig(pickupPoint.Name),
									AddressStreet1 = FirstLetterIsCapitalHelper.MakeFirstLetterBig(pickupPoint.Address.Street),
									AddressCountryCode = pickupPoint.Address.Country,
									AddressCity = FirstLetterIsCapitalHelper.MakeFirstLetterBig(pickupPoint.Address.City),
									AddressZipCode = StandardizeZipCodeHelper.StandardizeZipCode(pickupPoint.Address.PostalCode, pickupPoint.Address.City),
									DistanceInMeters = 999999999,
								};

								if (!pickupPoint.Distance.Equals(null))
								{
									decimal distanceInmetres = Convert.ToDecimal(pickupPoint.Distance);

									if (distanceInmetres > 0)
									{
										var meters = distanceInmetres;
										dropPoint.DistanceInMeters = Math.Round(meters, 0);
									}
								}

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
