using System;
using System.Collections.Generic;
using System.Globalization;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Xml;
using Zhipster.Internal.Api.Location.Helpers;
using Zhipster.Internal.Api.Location.Models.DropPoint;

namespace Zhipster.Internal.Api.Location.Services.Schenker.SchenkerSweden.SchenkerOmbudDropPointService
{
	public class SchenkerSwedenOmbudDropPointService : ISchenkerSwedenOmbudDropPointService
	{
		public async Task<List<DropPoint>> GetDropPoints(GetDropPointRequest dropPointRequest)
		{
			var dropPointList = new List<DropPoint>();

			var endpoint = new EndpointAddress("http://privpakservices.schenker.nu/package/package_1.3/packageservices.asmx");
			var timeOut = new TimeSpan(0, 0, 1, 0);
			var binding = new BasicHttpBinding
			{
				CloseTimeout = timeOut,
				OpenTimeout = timeOut,
				ReceiveTimeout = timeOut,
				SendTimeout = timeOut,
				MaxReceivedMessageSize = 2147483647,
				MaxBufferPoolSize = 2147483647,
				MaxBufferSize = 2147483647,
				TransferMode = TransferMode.Streamed,
				ReaderQuotas = new XmlDictionaryReaderQuotas
				{
					MaxArrayLength = 2147483647,
					MaxDepth = 2147483647,
					MaxNameTableCharCount = 2147483647,
					MaxStringContentLength = 2147483647,
					MaxBytesPerRead = 2147483647,
				},
			};

			try
			{
				var client = new SchenkerOmbudAPIService.packageservicesSoapClient(binding, endpoint);

				var requestApi = new SchenkerOmbudAPIService.SearchCollectionPointRequest
				{
					paramID = 1,
					customerID = 10070,
					key = "",
					maxhits = 0,
					address = dropPointRequest.DeliveryAddressStreet1,
					city = dropPointRequest.DeliveryAddressCity,
					postcode = dropPointRequest.DeliveryAddressZipCode,
					serviceID = ""
				};

				var pickupPoints = await client.SearchCollectionPointAsync(requestApi);

				if (pickupPoints != null && pickupPoints.SearchCollectionPointResult != null)
				{
					foreach (var pickupPoint in pickupPoints.SearchCollectionPointResult)
					{
						var dropPoint = new DropPoint
						{
							//AgentLocationId = schenkerPoint.CpointID.Trim(),
							//AgentName = schenkerPoint.DisplayName.Trim().FormatAsTitleText(),
							//Street1 = schenkerPoint.AddressLine1.Trim().FormatAsTitleText(),
							//Street2 = schenkerPoint.AddressLine2.Trim().FormatAsTitleText(),
							//Zip = schenkerPoint.PostCode.Trim(),
							//City = schenkerPoint.City.Trim().FormatAsTitleText(),
							//CountryIsoCode = schenkerPoint.CountryCode.Trim(),
							//DistanceInMeters = 999999999,

							DropPointID = pickupPoint.CpointID,
							AddressName = FirstLetterIsCapitalHelper.MakeFirstLetterBig(pickupPoint.DisplayName),
							AddressStreet1 = FirstLetterIsCapitalHelper.MakeFirstLetterBig(pickupPoint.AddressLine1),
							AddressStreet2 = FirstLetterIsCapitalHelper.MakeFirstLetterBig(pickupPoint.AddressLine2),
							AddressCountryCode = pickupPoint.CountryCode,
							AddressCity = FirstLetterIsCapitalHelper.MakeFirstLetterBig(pickupPoint.City),
							AddressZipCode = StandardizeZipCodeHelper.StandardizeZipCode(pickupPoint.PostCode, pickupPoint.CountryCode),
							DistanceInMeters = 999999999,
						};

						//var distanceInMeters = decimal.TryParse(pickupPoint.Distance, out number) ? number : 9999999.0m;
						//if (distanceInMeters > 0)
						//{
						//	dropPoint.DistanceInMeters = distanceInMeters;
						//}

						//dropPointList.Add(dropPoint);

						if (!string.IsNullOrWhiteSpace(pickupPoint.Distance))
						{
							var culture = CultureInfo.CreateSpecificCulture("en-US");
							decimal distanceInmetres;
							decimal.TryParse(pickupPoint.Distance, NumberStyles.AllowDecimalPoint, culture, out distanceInmetres);

							if (distanceInmetres > 0)
							{
								var meters = distanceInmetres;
								dropPoint.DistanceInMeters = Math.Round(meters, 0);
							}
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

			return dropPointList;
			//return servicePointList.OrderBy(a => a.DistanceInMeters).ToList();
		}
	}
}
