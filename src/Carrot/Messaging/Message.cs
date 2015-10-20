namespace Carrot.Messaging
{
    public class Message<TMessage> : IMessage<TMessage>
        where TMessage : class
    {
        private readonly TMessage _content;
        private readonly HeaderCollection _headers;

        internal Message(TMessage content, HeaderCollection headers)
        {
            _content = content;
            _headers = headers;
        }

        public TMessage Content
        {
            get { return _content; }
        }

        public HeaderCollection Headers
        {
            get { return _headers; }
        }
    }
}