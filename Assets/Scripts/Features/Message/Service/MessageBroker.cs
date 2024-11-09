using System;
using UniRx;

public class MessageBroker
{

    private readonly Subject<MessageBase> _messageSubject = new Subject<MessageBase>();

    public void Publish(MessageBase message)
    {
        _messageSubject.OnNext(message);
    }

    public IObservable<T> Receive<T>() where T : MessageBase
    {
        return _messageSubject
           .Where(message => message is T)
           .Select(message => (T)message);
    }
}
