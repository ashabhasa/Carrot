using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Carrot.Configuration;
using Carrot.Messages;

namespace Carrot
{
    public class Connection : IConnection
    {
        protected readonly EnvironmentConfiguration Configuration;

        private readonly RabbitMQ.Client.IConnection _connection;
        private readonly IEnumerable<ConsumerBase> _consumers;
        private readonly IOutboundChannel _channel;

        internal Connection(RabbitMQ.Client.IConnection connection,
                            IEnumerable<ConsumerBase> consumers,
                            IOutboundChannel channel,
                            EnvironmentConfiguration configuration)
        {
            _connection = connection;
            _consumers = consumers;
            _channel = channel;
            Configuration = configuration;
        }
        
        public Task<IPublishResult> PublishAsync<TMessage>(OutboundMessage<TMessage> message,
                                                           Exchange exchange,
                                                           String routingKey = "")
            where TMessage : class
        {
            return _channel.PublishAsync(message, exchange, routingKey);
        }

        public void Dispose()
        {
            foreach (var consumer in _consumers)
                consumer.Dispose();

            _channel?.Dispose();
            _connection?.Dispose();
        }
    }
}