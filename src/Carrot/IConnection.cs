using System;
using System.Threading.Tasks;
using Carrot.Messages;

namespace Carrot
{
    public interface IConnection : IDisposable
    {
        Task<IPublishResult> PublishAsync<TMessage>(OutboundMessage<TMessage> message,
                                                    Exchange exchange,
                                                    String routingKey = "")
            where TMessage : class;
    }
}