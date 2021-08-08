using System;
using Microsoft.Extensions.Hosting;

namespace HelloWorld
{
    public class EnvironmentService : IEnvironmentService
    {
        public EnvironmentService()
        {
            EnvironmentName = Environment.GetEnvironmentVariable(Constants.EnvironmentVariables.AspnetCoreEnvironment)
                              ?? Environments.Development;
        }

        public string EnvironmentName { get; set; }
    }
}