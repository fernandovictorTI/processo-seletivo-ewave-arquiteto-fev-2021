using FavoDeMel.Domain.Core.Messaging;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace FavoDeMel.Infra.RabbitMQ
{
    public class Publisher : IPublisher
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public Publisher(ISendEndpointProvider sendEndpointProvider)
        {
            _sendEndpointProvider = sendEndpointProvider;
        }

        public async Task Publish<T>(T model) where T : IMessagin
        {
            var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri(model.Key));
            await endpoint.Send(model);
        }
    }
}
