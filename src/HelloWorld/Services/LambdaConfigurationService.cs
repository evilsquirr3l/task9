using System.IO;
using Microsoft.Extensions.Configuration;

namespace HelloWorld
{
    public class LambdaConfigurationService : ILambdaConfiguration
    {
        private readonly IEnvironmentService _environment;

        public LambdaConfigurationService(IEnvironmentService environment)
        {
            _environment = environment;
        }

        public IConfiguration Configuration => new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{_environment}.json", optional: true)
            .AddEnvironmentVariables()
            .Build();
    }
}