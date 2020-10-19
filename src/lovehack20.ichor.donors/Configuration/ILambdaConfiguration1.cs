using Microsoft.Extensions.Configuration;

namespace Lovehack20.Ichor.Lambda.Configuration
{
    public interface ILambdaConfiguration
    {
        IConfiguration Configuration { get; }
    }
}