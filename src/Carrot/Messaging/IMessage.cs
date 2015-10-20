namespace Carrot.Messaging
{
    public interface IMessage<out TMessage>
        where TMessage : class
    {
        TMessage Content { get; }

        HeaderCollection Headers { get; }
    }
}