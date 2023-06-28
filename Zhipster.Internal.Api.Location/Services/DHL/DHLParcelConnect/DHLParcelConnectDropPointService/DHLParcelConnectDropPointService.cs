using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using Zhipster.Internal.Api.Location.Models.DropPoint;
using Zhipster.Internal.Api.Location.Models.DHLParcelConnect;
using Zhipster.Internal.Api.Location.Helpers;

namespace Zhipster.Internal.Api.Location.Services.DHLParcelConnect.DHLParcelConnectDropPointService
{
	public class DHLParcelConnectDropPointService : IDHLParcelConnectDropPointService
	{
		public async Task<List<DropPoint>> GetDropPoints(GetDropPointRequest dropPointRequest)
		{
			var servicePointList = new List<DropPoint>();
			try
			{
				var maxItems = 20;
				var radiusInMeters = 1000000;
				var parcelStationLocations = new List<LocationElement>();

				if (dropPointRequest.FreightServiceName == "Parcel Connect (Service Point)" || dropPointRequest.FreightServiceName == "Parcel Connect (Parcelshop)")
				{
					//Add Service Points
					var connectServicePoints = await GetDHLParcelStationLocationsAsync("https://api.dhl.com/location-finder/v1/find-by-address?locationType=servicepoint&countryCode=" + dropPointRequest.DeliveryAddressCountryCode + "&addressLocality=" + dropPointRequest.DeliveryAddressCity + "&postalCode=" + dropPointRequest.DeliveryAddressZipCode + "&streetAddress=" + dropPointRequest.DeliveryAddressStreet1 + "&radius=" + radiusInMeters + "&limit=" + maxItems);
					if (connectServicePoints != null && connectServicePoints.Any())
					{
						parcelStationLocations.AddRange(connectServicePoints);
					}

					//Add Post Offices
					var connectPostOffices = await GetDHLParcelStationLocationsAsync("https://api.dhl.com/location-finder/v1/find-by-address?locationType=postoffice&countryCode=" + dropPointRequest.DeliveryAddressCountryCode + "&addressLocality=" + dropPointRequest.DeliveryAddressCity + "&postalCode=" + dropPointRequest.DeliveryAddressZipCode + "&streetAddress=" + dropPointRequest.DeliveryAddressStreet1 + "&radius=" + radiusInMeters + "&limit=" + maxItems);
					if (connectPostOffices != null && connectPostOffices.Any())
					{
						parcelStationLocations.AddRange(connectPostOffices);
					}
				}
				else
				{
					//Swipbox Locker
					var url = "https://api.dhl.com/location-finder/v1/find-by-address?locationType=locker&countryCode=" + dropPointRequest.DeliveryAddressCountryCode + "&addressLocality=" + dropPointRequest.DeliveryAddressCity + "&postalCode=" + dropPointRequest.DeliveryAddressZipCode + "&streetAddress=" + dropPointRequest.DeliveryAddressStreet1 + "&radius=" + radiusInMeters + "&limit=" + maxItems;
					parcelStationLocations = await GetDHLParcelStationLocationsAsync(url);
				}

				if (parcelStationLocations != null && parcelStationLocations.Any())
				{
					foreach (var pickupPoint in parcelStationLocations)
					{
						if (pickupPoint.Place?.Address != null && pickupPoint.Location.Ids != null && pickupPoint.Location.Ids.Any())
						{
							var keywordId = pickupPoint.Location.KeywordId;
							var keyword = pickupPoint.Location.Keyword;
							var keywordType = pickupPoint.Location.Type;

							if (!string.IsNullOrWhiteSpace(keywordId) && !string.IsNullOrWhiteSpace(keyword) && !string.IsNullOrWhiteSpace(keywordType))
							{
								var keyWordAndType = keyword + ":::" + keywordType;

								var pointAddress = pickupPoint.Place.Address;

								var dropPoint = new DropPoint
								{
									DropPointID = keywordId,
									AddressName = FirstLetterIsCapitalHelper.MakeFirstLetterBig(pickupPoint.Name),
									AddressStreet1 = FirstLetterIsCapitalHelper.MakeFirstLetterBig(pickupPoint.Place.Address.StreetAddress),
									AddressCountryCode = pickupPoint.Place.Address.CountryCode,
									AddressCity = FirstLetterIsCapitalHelper.MakeFirstLetterBig(pickupPoint.Place.Address.AddressLocality),
									AddressZipCode = StandardizeZipCodeHelper.StandardizeZipCode(pickupPoint.Place.Address.PostalCode, pickupPoint.Place.Address.CountryCode),
									DistanceInMeters = 999999999,
								};

								if (pickupPoint.Distance.HasValue)
								{
									//var culture = CultureInfo.CreateSpecificCulture("en-US");
									decimal distanceInMeters = Convert.ToDecimal(pickupPoint.Distance);
									//decimal.TryParse(pickupPoint.Distance, NumberStyles.AllowDecimalPoint, culture, out distanceInMeters);

									if (distanceInMeters > 0)
									{
										dropPoint.DistanceInMeters = distanceInMeters;
									}
								}

								servicePointList.Add(dropPoint);
							}
						}
					}
				}
			}
			catch
			{

			}

			return servicePointList.OrderBy(a => a.DistanceInMeters).ToList();
		}

		private static async Task<List<LocationElement>> GetDHLParcelStationLocationsAsync(string url)
		{
			var httpRequestMessage = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(url),
			};

			httpRequestMessage.Headers.Add(HttpRequestHeader.Accept.ToString(), "application/json");
			httpRequestMessage.Headers.Add("DHL-API-Key", "");

			var client = new HttpClient();
			var response = await client.SendAsync(httpRequestMessage).ConfigureAwait(false);
			if (response.IsSuccessStatusCode)
			{
				var parcelConnect = response.Content.ReadAsAsync<ParcelConnect>().Result;
				if (parcelConnect.Locations != null && parcelConnect.Locations.Any())
				{
					return parcelConnect.Locations;
				}
			}

			return null;
		}
	}
}
