public class ProducerMessage : MessageBase
{
    public readonly HiddenObjectData HiddenObjectData;

    public ProducerMessage(string id, HiddenObjectData hiddenObjectData) : base(id)
    {
        HiddenObjectData = hiddenObjectData;
    }
}
