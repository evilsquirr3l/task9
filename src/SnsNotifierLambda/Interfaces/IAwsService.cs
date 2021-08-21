using System.Threading.Tasks;
using Amazon.S3;
using Amazon.SimpleNotificationService;
using Amazon.SQS;

namespace SnsNotifierLambda.Interfaces
{
    public interface IAwsService
    {
        AmazonSimpleNotificationServiceClient GetSnsAccessClient();

        string GetSnsTopicArn();

        AmazonSQSClient GetSqsClient();

        Task<string> GetQueueUrl();
    }
}