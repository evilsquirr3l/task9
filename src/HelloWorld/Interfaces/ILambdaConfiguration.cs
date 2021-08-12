using Microsoft.Extensions.Configuration;

namespace HelloWorld.Interfaces
{
    public interface ILambdaConfiguration
    {
        IConfiguration Configuration { get; }
    }
}