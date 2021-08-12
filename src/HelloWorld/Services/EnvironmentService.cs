using System;
using HelloWorld.Interfaces;
using Microsoft.Extensions.Hosting;

namespace HelloWorld.Services
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