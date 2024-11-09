using UnityEngine;

public class MessageBase
{
    public ISender Sender { get; private set; }
    public string id { get; private set; }
    public Object data { get; private set; }

    public MessageBase(ISender sender, string id, Object data)
    {
        Sender = sender;
        this.id = id;
        this.data = data;
    }

    public static MessageBase Create(ISender sender, string id, Object data)
    {
        return new MessageBase(sender, id, data);
    }
}
