using Amazon.Lambda.APIGatewayEvents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lovehack20.Ichor.Lambda.Interfaces
{
    public interface IHttpMethodHandler
    {
        Task<APIGatewayProxyResponse> HandleAsync(APIGatewayProxyRequest request);
        
    }
}
