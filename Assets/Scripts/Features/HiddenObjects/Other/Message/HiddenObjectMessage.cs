public class HiddenObjectMessage : MessageBase
{
    public readonly HiddenObjectMessageContainer MessageContainer;

    public HiddenObjectMessage(HiddenObjectMessageContainer messageContainer, string id) : base(id)
    {
        MessageContainer = messageContainer;
    }
}
