using Amazon.Lambda.APIGatewayEvents;
using Lovehack20.Ichor.Lambda.Interfaces;
using System;
using System.Threading.Tasks;

namespace Lovehack20.Ichor.Lambda.Handlers
{
    public class ProxyRequestHandler : IProxyRequestHandler
    {
        private readonly IHttpMethodHandler _getHandler;
        private readonly IHttpMethodHandler _postHandler;
        private readonly IHttpMethodHandler _deletetHandler;

        public ProxyRequestHandler(IHttpMethodHandler getHandler, IHttpMethodHandler postHandler, IHttpMethodHandler deleteHandler)
        {
            _getHandler = getHandler;
            _postHandler = postHandler;
            _deletetHandler = deleteHandler;
        }

        public Task<APIGatewayProxyResponse> HandleRequest(APIGatewayProxyRequest request)
        {
            return request.HttpMethod switch
            {
                "POST" => _postHandler.HandleAsync(request),
                "GET" => _getHandler.HandleAsync(request),
                "DELETE" => _deletetHandler.HandleAsync(request),
                _ => throw new InvalidOperationException($"Method ({request.HttpMethod}) not allowed."),
            };
        }
    }
}
