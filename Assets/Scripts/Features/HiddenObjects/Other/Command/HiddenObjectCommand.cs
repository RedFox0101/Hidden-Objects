
public class HiddenObjectCommand : ICommand, ISender
{
    private BaseObjectView _baseObjectView;
    private MessageBroker _messageBroker;

    public HiddenObjectCommand(BaseObjectView baseObjectView, MessageBroker messageBroker)
    {
        _baseObjectView = baseObjectView;
        _messageBroker = messageBroker;
    }

    public void Execute()
    {
        _messageBroker.Publish(MessageBase.Create(this, _baseObjectView.HiddenObjectData.Id, null));
        _baseObjectView.gameObject.SetActive(false);
    }
}
