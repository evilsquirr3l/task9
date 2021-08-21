using System.Threading.Tasks;
using Amazon.SQS.Model;

namespace SnsNotifierLambda.Interfaces
{
    public interface ISqsService
    {
        Task SendSqsMessagesToSnsTopic(int waitTime, int maxMessages);
    }
}