public class ProducerClickCommand : IClickCommand
{
    private ObjectInitializeService _hiddenObjectFactory;
    private HiddenObjectData _hiddenObjectData;
    private MessageBroker _messageBroker;

    public ProducerClickCommand(MessageBroker messageBroker, ObjectInitializeService hiddenObjectFactory, HiddenObjectData hiddenObjectData)
    {
        _messageBroker = messageBroker;
        _hiddenObjectFactory = hiddenObjectFactory;
        _hiddenObjectData = hiddenObjectData;

    }

    public void Execute()
    {
        if (_messageBroker == null)
            return;

        var hiddenObjectData = new HiddenObjectData()
        {
            Id = _hiddenObjectData.Produces.Id,
            Layer = _hiddenObjectData.Produces.Layer,
            Position = _hiddenObjectData.Produces.Position,
            Rotation = _hiddenObjectData.Produces.Rotation,
            Scale = _hiddenObjectData.Produces.Scale,
            Key = _hiddenObjectData.Produces.Key,
        };
        _hiddenObjectFactory.CreateHiddenObject(hiddenObjectData);
        _messageBroker.Publish(new ProducerMessage(_hiddenObjectData.Id, _hiddenObjectData));

        _messageBroker = null;
        _hiddenObjectData = null;
    }
}
