using Amazon.Lambda.APIGatewayEvents;
using Lovehack20.Ichor.Lambda.Interfaces;
using Lovehack20.Ichor.Lambda.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Lovehack20.Ichor.Lambda.Handlers
{
    public class GetHandler : IHttpMethodHandler
    {
        public async Task<APIGatewayProxyResponse> HandleAsync(APIGatewayProxyRequest request)
        {
            var donor = await FetchData();

            var data = new
            {
                request.Path,
                request.PathParameters,
                request.Resource,
                request.QueryStringParameters,
                data = donor
            };


            var response = new APIGatewayProxyResponse
            {
                Body = JsonConvert.SerializeObject(data),
                IsBase64Encoded = false,
                StatusCode = 200
            };

            return response;
        }

        private Task<Donor> FetchData()
        {
            return Task.FromResult(new Donor
            {
                FirstName = "Bruno",
                LastName = "Castro",
                Address = new Address
                {
                    City = "Dublin",
                    EirCode = "D18XW31",
                    Line1 = "33 weavers hall, levmoss park",
                    Line2 = "Dublin 18, Dublin"
                },
                Birthday = new DateTime(1990, 05, 14)
            });
        }
    }
}
