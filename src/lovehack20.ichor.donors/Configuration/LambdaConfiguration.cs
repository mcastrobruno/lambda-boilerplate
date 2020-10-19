using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lovehack20.Ichor.Lambda.Configuration
{
    public class LambdaConfiguration : ILambdaConfiguration
    {
        public IConfiguration Configuration => new ConfigurationBuilder()
            .AddEnvironmentVariables()
                .Build();

    }
}
