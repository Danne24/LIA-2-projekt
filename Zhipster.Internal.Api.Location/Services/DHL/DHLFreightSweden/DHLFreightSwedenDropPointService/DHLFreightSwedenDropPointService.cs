using System;
using System.Collections.Generic;
using System.Linq;
using Zhipster.Internal.Api.Location.Models.DropPoint;
using Zhipster.Internal.Api.Location.Models.DHLFreightSweden;
using System.Threading.Tasks;
using System.Net.Http;
using Zhipster.Internal.Api.Location.Helpers;
using Newtonsoft.Json;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace Zhipster.Internal.Api.Location.Services.DHL.DHLFreightSweden.DHLFreightSwedenDropPointService
{
    public class DHLFreightSwedenDropPointService : IDHLFreightSwedenDropPointService
    {
        public async Task<List<DropPoint>> GetDropPoints(GetDropPointRequest dropPointRequest)
        {
            var servicePointList = new List<DropPoint>();
            try
            {
                var apiRequestModel = new DHlFreightServicePointRequestV2
                {
                    MaxNumberOfItems = 10,
                    Address = new Address
                    {
                        CityName = dropPointRequest.DeliveryAddressCity,
                        CountryCode = dropPointRequest.DeliveryAddressCountryCode,
                        PostalCode = dropPointRequest.DeliveryAddressZipCode,
                        Street = dropPointRequest.DeliveryAddressStreet1,
                    },
                };

                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("client-key", "");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var requestJson = JsonConvert.SerializeObject(apiRequestModel, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    DefaultValueHandling = DefaultValueHandling.Include,
                });

                var requestContent = new StringContent(requestJson);
                requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var formatter = new JsonMediaTypeFormatter()
                {
                    SerializerSettings = new JsonSerializerSettings()
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                    }
                };

                var pickupPoints = new List<ServicePoint>();
                var endpoint = "https://api.freight-logistics.dhl.com/servicepointlocatorapi/v1/servicepoint/findnearestservicepoints";
                var response = await httpClient.PostAsync(endpoint, requestContent);

                if (response.IsSuccessStatusCode)
                {
                    var servicePointResponse = await response.Content.ReadAsAsync<DHlFreightServicePointResponseV2>();
                    if (servicePointResponse.ServicePoints != null && servicePointResponse.ServicePoints.Any())
                    {
                        pickupPoints = servicePointResponse.ServicePoints;
                    }
                }

                if (pickupPoints != null && pickupPoints.Any())
                {
                    foreach (var pickupPoint in pickupPoints)
                    {
                        var dropPoint = new DropPoint
                        {
                            DropPointID = pickupPoint.Id,
                            AddressName = FirstLetterIsCapitalHelper.MakeFirstLetterBig(pickupPoint.Name),
                            AddressStreet1 = FirstLetterIsCapitalHelper.MakeFirstLetterBig(pickupPoint.Street),
                            AddressCountryCode = pickupPoint.CountryCode,
                            AddressCity = FirstLetterIsCapitalHelper.MakeFirstLetterBig(pickupPoint.CityName),
                            AddressZipCode = StandardizeZipCodeHelper.StandardizeZipCode(pickupPoint.PostalCode, pickupPoint.CountryCode),
                            DistanceInMeters = 999999999,
                        };

                        var distanceInKilometres = pickupPoint.RouteDistance;
                        if (distanceInKilometres <= 0)
                        {
                            distanceInKilometres = pickupPoint.Distance;
                        }

                        if (distanceInKilometres > 0)
                        {
                            var meters = distanceInKilometres * 1000;
                            dropPoint.DistanceInMeters = Math.Round(meters, 0);
                        }

                        servicePointList.Add(dropPoint);
                    }
                }
            }
            catch
            {

            }

            //Let DHL Sort
            //return servicePointList.OrderBy(a => a.DistanceInMeters).ToList();

            return servicePointList.ToList();
        }
    }
}
