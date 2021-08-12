using Microsoft.Extensions.Configuration;

namespace SnsNotifierLambda.Interfaces
{
    public interface ILambdaConfiguration
    {
        IConfiguration Configuration { get; }
    }
}