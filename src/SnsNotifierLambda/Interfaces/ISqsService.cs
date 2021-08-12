using System.Threading.Tasks;
using Amazon.SQS.Model;

namespace SnsNotifierLambda.Interfaces
{
    public interface ISqsService
    {
        Task<SendMessageResponse> PublishEventToSqsQueue(string message);

        Task SendSqsMessagesToSnsTopic();
    }
}