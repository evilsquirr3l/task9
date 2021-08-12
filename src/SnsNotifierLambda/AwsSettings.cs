namespace SnsNotifierLambda
{
    public class AppSettings
    {
        public string AccessKey { get; set; }
        
        public string SecretKey { get; set; }

        public string Region { get; set; }
        
        public string SnsTopicArn { get; set; }

        public string QueueName { get; set; }
    }
}