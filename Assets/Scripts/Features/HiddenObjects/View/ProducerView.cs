using UniRx;
using UnityEngine;
using Zenject;

public class ProducerView : BaseObjectView
{
    [SerializeField] private HiddenObjectView _hiddenObjectView;

    private ObjectInitializeService _initializeService;
    private CompositeDisposable _disposables = new CompositeDisposable();
    private MessageBroker _messageBroker;

    [Inject]
    private void Constructor(ObjectInitializeService initializeService, MessageBroker messageBroker)
    {
        _initializeService = initializeService;
        _messageBroker = messageBroker;
    }

    public override void Setup(HiddenObjectData hiddenObjectData)
    {
        ObjectClickCommand = new ProducerClickCommand(_messageBroker, _initializeService, hiddenObjectData);
        LoadSaveCommand = new ProducerLoadSaveCommand(ObjectClickCommand);
        base.Setup(hiddenObjectData);
    }
}
