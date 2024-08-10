using Alpha.Shared.Models;
using Alpha.Shared.Utils.Extensions;
using MassTransit;

namespace Alpha.ServiceB.API.Events.Consumers
{
    public class CommonConsumer : IConsumer<CommonModel>
    {
        private readonly ILogger<CommonConsumer> _logger;
        public CommonConsumer(ILogger<CommonConsumer> logger)
        {
            _logger = logger;

        }

        public Task Consume(ConsumeContext<CommonModel> context)
        {
            _logger.InformationLog("Started CommonConsumer" + context.ToString());
            return Task.CompletedTask;
        }
    }
}
