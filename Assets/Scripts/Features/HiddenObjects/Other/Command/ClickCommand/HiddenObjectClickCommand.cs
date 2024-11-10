
public class HiddenObjectClickCommand : IClickCommand
{
    private BaseObjectView _baseObjectView;
    private MessageBroker _messageBroker;

    public HiddenObjectClickCommand(BaseObjectView baseObjectView, MessageBroker messageBroker)
    {
        _baseObjectView = baseObjectView;
        _messageBroker = messageBroker;
    }

    public void Execute()
    {
        var message = new HiddenObjectMessage(new HiddenObjectMessageContainer(_baseObjectView.HiddenObjectData, _baseObjectView.transform), _baseObjectView.HiddenObjectData.Id);
        _messageBroker.Publish(message);
        _baseObjectView.gameObject.SetActive(false);
    }
}
