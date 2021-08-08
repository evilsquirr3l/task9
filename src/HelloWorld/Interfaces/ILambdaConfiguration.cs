using Microsoft.Extensions.Configuration;

namespace HelloWorld
{
    public interface ILambdaConfiguration
    {
        IConfiguration Configuration { get; }
    }
}