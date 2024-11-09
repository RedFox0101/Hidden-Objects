using UniRx;

public class MessageBroker
{

    private readonly Subject<MessageBase> _messageSubject = new Subject<MessageBase>();

    public void Publish(MessageBase message)
    {
        _messageSubject.OnNext(message);
    }

}
