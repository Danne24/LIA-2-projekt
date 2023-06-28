using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Zhipster.Internal.Api.Location.Models.DropPoint;
using Entrix.Logic.Models.Forwarder.DBSchenker;
using Zhipster.Internal.Api.Location.Helpers;
using System.Security.Cryptography;

namespace Zhipster.Internal.Api.Location.Services.Schenker.SchenkerSweden.SchenkerBoxDropPointService
{
	public class SchenkerSwedenBoxDropPointService : ISchenkerSwedenBoxDropPointService
	{
		public async Task<List<DropPoint>> GetDropPoints(GetDropPointRequest dropPointRequest)
		{
			var dropPointList = new List<DropPoint>();

			try
			{
				var endpoint = "https://staging-parcelservices-se.schenker.nu/ApiPartner/DeliveryPoint/v3/GetNearestBoxes";
				var userId = "";
				var secret = "";

				var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
				if (environment == "Production")
				{
					endpoint = "https://parcelservices-se.dbschenker.com/Apipartner/DeliveryPoint/v3/GetNearestBoxes";
					userId = "";
					secret = "";
				}

				var client = new HttpClient
				{
					BaseAddress = new Uri(endpoint),
					Timeout = TimeSpan.FromSeconds(60),
				};

				var serializerSettings = new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore,
					DefaultValueHandling = DefaultValueHandling.Include,
				};

				var schenkerBoxRequest = new DBSchenkerBoxRequest
				{
					StreetAddress = dropPointRequest.DeliveryAddressStreet1,
					City = dropPointRequest.DeliveryAddressCity,
					PostalCode = dropPointRequest.DeliveryAddressZipCode,
					LocationMaxDistance = 1000000,
					LocationsMaxQty = 10,
					RequiresLowBox = false,
				};

				var schenkerBoxRequestJson = JsonConvert.SerializeObject(schenkerBoxRequest, serializerSettings);

				string sha256EncryptedSecred = string.Empty;
				using (var sha256 = SHA256.Create())
				{
					foreach (byte b in sha256.ComputeHash(Encoding.UTF8.GetBytes(schenkerBoxRequestJson + secret)))
					{
						sha256EncryptedSecred += $"{b:X2}";
					}
				}

				client.DefaultRequestHeaders.Add("Authentication", $"{userId}:{sha256EncryptedSecred}");
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				var requestHttpContent = new StringContent(schenkerBoxRequestJson);
				requestHttpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

				var boxHttpResult = await client.PostAsync(endpoint, requestHttpContent);
				if (boxHttpResult.IsSuccessStatusCode)
				{
					var schenkerBoxResponseJson = await boxHttpResult.Content.ReadAsStringAsync();
					var pickupPoints = JsonConvert.DeserializeObject<List<DBSchenkerBoxResponse>>(schenkerBoxResponseJson);

					if (pickupPoints != null)
					{
						foreach (var pickupPoint in pickupPoints)
						{
							var dropPoint = new DropPoint
							{
								DropPointID = pickupPoint.AddressId,
								AddressName = FirstLetterIsCapitalHelper.MakeFirstLetterBig(pickupPoint.Address.Name),
								AddressStreet1 = FirstLetterIsCapitalHelper.MakeFirstLetterBig(pickupPoint.Address.AddressLine1),
								AddressStreet2 = FirstLetterIsCapitalHelper.MakeFirstLetterBig(pickupPoint.Address.AddressLine2),
								AddressCountryCode = pickupPoint.Address.CountryCode,
								AddressCity = FirstLetterIsCapitalHelper.MakeFirstLetterBig(pickupPoint.Address.City),
								AddressZipCode = StandardizeZipCodeHelper.StandardizeZipCode(pickupPoint.Address.PostalCode, pickupPoint.Address.City),
							};

							if (string.IsNullOrWhiteSpace(dropPoint.AddressStreet1))
							{
								dropPoint.AddressStreet1 = dropPoint.AddressStreet1;
							}

							dropPointList.Add(dropPoint);
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
