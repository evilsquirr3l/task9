using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.SimpleNotificationService;
using Amazon.SQS;
using Amazon.SQS.Model;
using HelloWorld.Interfaces;

namespace HelloWorld.Services
{
    public class AwsService : IAwsService
    {
        private readonly AppSettings _appSettings;

        public AwsService(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }
        
        public AmazonS3Client GetBucketAccessClient()
        {
            var credentials = GetAwsCredentials();
            var config = new AmazonS3Config
            {
                RegionEndpoint = Amazon.RegionEndpoint.GetBySystemName(_appSettings.Region)
            };

            return new AmazonS3Client(credentials, config);
        }

        public AmazonSimpleNotificationServiceClient GetSnsAccessClient()
        {
            var credentials = GetAwsCredentials();
            var config = new AmazonSimpleNotificationServiceConfig
            {
                RegionEndpoint = Amazon.RegionEndpoint.GetBySystemName(_appSettings.Region)
            };

            return new AmazonSimpleNotificationServiceClient(credentials, config);
        }

        private BasicAWSCredentials GetAwsCredentials()
        {
            return new BasicAWSCredentials(_appSettings.AccessKey, _appSettings.SecretKey);
        }

        public string GetSnsTopicArn()
        {
            return _appSettings.SnsTopicArn;
        }

        public AmazonSQSClient GetSqsClient()
        {
            var credentials = GetAwsCredentials();
            var config = new AmazonSQSConfig
            {
                RegionEndpoint = Amazon.RegionEndpoint.GetBySystemName(_appSettings.Region)
            };

            return new AmazonSQSClient(credentials, config);
        }

        public async Task<string> GetQueueUrl()
        {
            using var client = GetSqsClient();
        
            var getQueueRequest = new GetQueueUrlRequest(_appSettings.QueueName);
            var getQueueUrlResponse = await client.GetQueueUrlAsync(getQueueRequest);
            
            return getQueueUrlResponse.QueueUrl;
        }
    }
}