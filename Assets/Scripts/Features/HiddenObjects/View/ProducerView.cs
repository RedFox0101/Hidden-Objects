using UniRx;
using UnityEngine;
using Zenject;

public class ProducerView : BaseObjectView
{
    [SerializeField] private HiddenObjectView _hiddenObjectView;

    private ObjectInitializeService _initializeService;
    private CompositeDisposable _disposables = new CompositeDisposable();
    [Inject]
    private void Constructor(ObjectInitializeService initializeService)
    {
        _initializeService = initializeService;
    }

    public override void Setup(HiddenObjectData hiddenObjectData)
    {
        base.Setup(hiddenObjectData);
        Observable.Timer(System.TimeSpan.FromSeconds(0.5f))
        .Subscribe(_ =>
        {
            ObjectClickCommand = new ProducerCommand(Collider, _initializeService, HiddenObjectData);
        }).AddTo(_disposables);
    }
}
