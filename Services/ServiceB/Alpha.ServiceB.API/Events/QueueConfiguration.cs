using Alpha.ServiceB.API.Events.Consumers;
using Alpha.Shared.Models;
using Alpha.Shared.Utils.Extensions;

namespace Alpha.ServiceB.API.Events
{
    public class QueueConfiguration
    {
        public static List<ConsumerQueueConfig> CreateDefaultMappings()
        {
            return new List<ConsumerQueueConfig>
        {
            new() {
                QueueName = QueueNames.SCHEDULE_JOB_QUEUE,
                ConsumerType = typeof(CommonConsumer)
            },
        };
        }
    }
}
