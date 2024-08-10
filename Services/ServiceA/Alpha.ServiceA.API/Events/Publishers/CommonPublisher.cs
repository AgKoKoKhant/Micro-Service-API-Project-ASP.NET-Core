using Alpha.Shared.Models;
using Alpha.Shared.Utils.Extensions;
using MassTransit;

namespace Alpha.ServiceA.API.Events.Publishers
{
    public interface ICommonPublisher
    {
        Task PublishMessage(CommonModel context, string queueName);
    }
    public class CommonPublisher : ICommonPublisher
    {
        private readonly ILogger<CommonPublisher> _logger;
        private readonly ISendEndpointProvider _sendEndpointProvider;
        public CommonPublisher(ILogger<CommonPublisher> logger, ISendEndpointProvider sendEndpointProvider)
        {
            _sendEndpointProvider = sendEndpointProvider;
            _logger = logger;
        }
        public async Task PublishMessage(CommonModel context, string queueName)
        {
            _logger.InformationLog("Started CommonPubllisher");
            var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{queueName}"));
            await endpoint.Send(context);
        }
    }
}
