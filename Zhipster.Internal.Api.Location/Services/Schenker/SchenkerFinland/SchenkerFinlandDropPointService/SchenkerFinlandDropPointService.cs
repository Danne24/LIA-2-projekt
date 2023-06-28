using SchenkerFinlandOmbudAPIService;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Xml;
using Zhipster.Internal.Api.Location.Helpers;
using Zhipster.Internal.Api.Location.Models.DropPoint;

namespace Zhipster.Internal.Api.Location.Services.Schenker.SchenkerFinland.SchenkerFinlandDropPointService
{
	public class SchenkerFinlandDropPointService : ISchenkerFinlandDropPointService
	{
		public async Task<List<DropPoint>> GetDropPoints(GetDropPointRequest dropPointRequest)
		{
			var dropPointList = new List<DropPoint>();
			var endpoint = new EndpointAddress("https://webservice.myschenker.fi/ewebsecure3_0/webservice3_0.svc");

			var timeOut = new TimeSpan(0, 0, 1, 0);
			var binding = new BasicHttpsBinding
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
				var client = new WebService3_0Client(binding, endpoint);
				var auth = new Authentication
				{
					userName = "",
					accessKey = "",
					//ExtensionData = null
				};

				var deliveryAddress = dropPointRequest.DeliveryAddressStreet1 + " " + dropPointRequest.DeliveryAddressZipCode;

				var request = new getNearestCPWithDistanceRequest
				{
					amount = 10,
					auth = auth,
					searchAddress = deliveryAddress
				};

				var pickupPoints = await client.getNearestCPWithDistanceAsync(request);
				if (pickupPoints != null)
				{
					foreach (var pickupPoint in pickupPoints.getNearestCPWithDistanceResult)
					{
						var dropPoint = new DropPoint
						{
							DropPointID = pickupPoint.CollectionPointID,
							AddressName = FirstLetterIsCapitalHelper.MakeFirstLetterBig(pickupPoint.CollectionPointName),
							AddressStreet1 = FirstLetterIsCapitalHelper.MakeFirstLetterBig(pickupPoint.Address1),
							AddressStreet2 = FirstLetterIsCapitalHelper.MakeFirstLetterBig(pickupPoint.Address2),
							AddressCountryCode = "FI",
							AddressCity = FirstLetterIsCapitalHelper.MakeFirstLetterBig(pickupPoint.City),
							AddressZipCode = StandardizeZipCodeHelper.StandardizeZipCode(pickupPoint.PostalCode, "FI"),
							DistanceInMeters = 999999999,
						};

						var distanceInMeters = 0;
						if (!string.IsNullOrWhiteSpace(pickupPoint.Distance))
						{
							distanceInMeters = int.Parse(pickupPoint.Distance);
							dropPoint.DistanceInMeters = Math.Round((decimal)distanceInMeters, 0);
						}

						dropPointList.Add(dropPoint);
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
