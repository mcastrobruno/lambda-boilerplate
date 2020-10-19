using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Lovehack20.Ichor.Lambda.Configuration;
using Lovehack20.Ichor.Lambda.Handlers;
using Lovehack20.Ichor.Lambda.Interfaces;
using Microsoft.Extensions.DependencyInjection;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace Lovehack20.Ichor.Lambda
{
    public class Function
    {
        private ILambdaConfiguration Configuration { get; }
        private readonly IProxyRequestHandler _handler;
        public Function()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            Configuration = serviceProvider.GetService<ILambdaConfiguration>();
            _handler = serviceProvider.GetService<IProxyRequestHandler>();
        }

        public async Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayProxyRequest input, ILambdaContext context)
        {
            return await _handler.HandleRequest(input);
        }

        private void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ILambdaConfiguration, LambdaConfiguration>();
            serviceCollection.AddTransient<GetHandler>();
            serviceCollection.AddTransient<PostHandler>();
            serviceCollection.AddTransient<DeleteHandler>();

            serviceCollection.AddTransient<IProxyRequestHandler>(sp =>
            {
                return new ProxyRequestHandler(sp.GetService<GetHandler>(), sp.GetService<PostHandler>(), sp.GetService<DeleteHandler>());
            });
        }

    }
}
