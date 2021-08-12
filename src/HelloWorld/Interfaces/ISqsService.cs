using System.Threading.Tasks;
using Amazon.SQS.Model;

namespace HelloWorld.Interfaces
{
    public interface ISqsService
    {
        Task<SendMessageResponse> PublishEventToSqsQueue(string message);

        Task SendSqsMessagesToSnsTopic();
    }
}