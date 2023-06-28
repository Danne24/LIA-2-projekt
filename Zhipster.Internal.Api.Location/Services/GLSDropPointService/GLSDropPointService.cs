using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Zhipster.Internal.Api.Location.Helpers;
using Zhipster.Internal.Api.Location.Models.DropPoint;
using Zhipster.Internal.Api.Location.Models.GLS;

namespace Zhipster.Internal.Api.Location.Services.GLSDropPointService
{
	public class GLSDropPointService : IGLSDropPointService
	{
		public async Task<List<DropPoint>> GetDropPoints(GetDropPointRequest dropPointRequest)
		{
			var dropPointList = new List<DropPoint>();

			try
			{
				var maxItems = 10;
				var endpoint = $"http://www.gls.dk/webservices_v4/wsShopFinder.asmx/SearchNearestParcelShops";
				var getUri = endpoint + $"?street={dropPointRequest.DeliveryAddressStreet1}&zipcode={dropPointRequest.DeliveryAddressZipCode}&countryIso3166A2={dropPointRequest.DeliveryAddressCountryCode}&amount={maxItems}";
				var client = new HttpClient();
				var response = client.GetAsync(getUri).Result;
				if (response.IsSuccessStatusCode)
				{
					var PickupPoints = await response.Content.XmlDeserializeAsync<ParcelShopSearchResult>();
					if (PickupPoints?.ServicePoints?.ServicePointLocations != null && PickupPoints.ServicePoints.ServicePointLocations.Any())
					{
						foreach (var pickupPoint in PickupPoints.ServicePoints.ServicePointLocations)
						{
							if (!string.IsNullOrWhiteSpace(pickupPoint.Identifier))
							{
								var dropPoint = new DropPoint
								{
									//AgentName = point.CompanyName.FormatAsTitleText(),
									//Street1 = point.Streetname.FormatAsTitleText(),
									//Street2 = point.Streetname2.FormatAsTitleText(),
									//Zip = point.ZipCode,
									//City = point.CityName.FormatAsTitleText(),
									//CountryIsoCode = point.CountryCodeISO3166A2,
									//AgentLocationId = point.Identifier,
									//AgentRoutingId = point.Identifier,

									DropPointID = pickupPoint.Identifier,
									AddressName = FirstLetterIsCapitalHelper.MakeFirstLetterBig(pickupPoint.CompanyName),
									AddressStreet1 = FirstLetterIsCapitalHelper.MakeFirstLetterBig(pickupPoint.Streetname),
									AddressCountryCode = pickupPoint.CountryCodeISO3166A2,
									AddressCity = FirstLetterIsCapitalHelper.MakeFirstLetterBig(pickupPoint.CityName),
									AddressZipCode = StandardizeZipCodeHelper.StandardizeZipCode(pickupPoint.ZipCode, pickupPoint.CityName),
									DistanceInMeters = 999999999,
								};

								if (!pickupPoint.DistanceMetersAsTheCrowFlies.IsNullOrEmpty())
								{
									var meters = Convert.ToDecimal(pickupPoint.DistanceMetersAsTheCrowFlies);
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

				}
			}
			catch
			{

			}

			return dropPointList;
		}
	}
}
