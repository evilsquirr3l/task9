using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.OpsWorks.Model;
using HelloWorld.Interfaces;
using HelloWorld.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace HelloWorld
{
    public class Function
    {
        private ServiceCollection _serviceCollection;
        
        public Function()
        {
            ConfigureServices();
        }

        public async Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayProxyRequest gatewayEvent,
            ILambdaContext context)
        {
            await using (var serviceProvider = _serviceCollection.BuildServiceProvider())
            {
                var sqsService = serviceProvider.GetService<ISqsService>();
                await sqsService.SendSqsMessagesToSnsTopic();
            }

            var body = new Dictionary<string, string>
            {
                {"Success!", "Messages from sqs topic were sent"}
            };
            
            gatewayEvent.Headers.TryGetValue("sender", out string sender);
            if (string.IsNullOrEmpty(sender))
            {
                sender = "cloudwatch rule";
            }
            
            Console.WriteLine($"Hello from {sender}");

            return new APIGatewayProxyResponse
            {
                Body = JsonConvert.SerializeObject(body),
                StatusCode = 200,
                Headers = new Dictionary<string, string> {{"Content-Type", "application/json"}, {"Sender", sender}}
            };
        }
        
        private void ConfigureServices()
        {
            _serviceCollection = new ServiceCollection();
            _serviceCollection.AddOptions();
            _serviceCollection.AddTransient<ILambdaConfiguration, LambdaConfigurationService>();
            _serviceCollection.AddTransient<IAwsService, AwsService>();
            _serviceCollection.AddTransient<ISqsService, SqsService>();
            _serviceCollection.AddTransient<IEnvironmentService, EnvironmentService>();
            
            Configuration = _serviceCollection.BuildServiceProvider().GetService<ILambdaConfiguration>();

            var settings = Configuration?.Configuration.GetSection("AwsSettings").Get<AppSettings>();
            
            _serviceCollection.AddSingleton(settings);
        }
        
        private ILambdaConfiguration Configuration { get; set; }
    }
}