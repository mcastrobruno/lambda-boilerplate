using Amazon.Lambda.APIGatewayEvents;
using System.Threading.Tasks;

namespace Lovehack20.Ichor.Lambda.Interfaces
{
    public interface IProxyRequestHandler
    {
        Task<APIGatewayProxyResponse> HandleRequest(APIGatewayProxyRequest request);
    }
}