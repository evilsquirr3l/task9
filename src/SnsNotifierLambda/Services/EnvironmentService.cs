using System;
using Microsoft.Extensions.Hosting;
using SnsNotifierLambda.Interfaces;

namespace SnsNotifierLambda.Services
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