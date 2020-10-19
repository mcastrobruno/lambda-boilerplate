using Amazon.Lambda.APIGatewayEvents;
using Lovehack20.Ichor.Lambda.Interfaces;
using System;
using System.Threading.Tasks;

namespace Lovehack20.Ichor.Lambda.Handlers
{
    public class PostHandler : IHttpMethodHandler
    {
        public Task<APIGatewayProxyResponse> HandleAsync(APIGatewayProxyRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
