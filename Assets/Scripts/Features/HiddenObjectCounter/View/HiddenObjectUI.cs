using Assets.Scripts.Features.AssetLoader;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class HiddenObjectUI : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _label;

    private AssetsLoaderService _assetsLoaderService;
    private MessageBroker _messageBroker;
    private CompositeDisposable _disposables=new CompositeDisposable();

    private int _currentNumberObject;

    [Inject]
    private void Constructor(AssetsLoaderService assetsLoaderService, MessageBroker messageBroker)
    {
        _assetsLoaderService=assetsLoaderService;
        _messageBroker=messageBroker;
    }

    public  async void Setup(string maxHiddenObject, string id)
    {
        _label.text = $"{_currentNumberObject}/{maxHiddenObject}";
        _icon.sprite =await _assetsLoaderService.LoadAsset<Sprite>(id);

        _messageBroker.Receive<MessageBase>()
           .Where(msg => msg.id == id)
           .Subscribe(msg => {
               _currentNumberObject++;
               _label.text = $"{_currentNumberObject}/{maxHiddenObject}";
           }).AddTo(_disposables);
    }

    private void OnDestroy()
    {
        _disposables.Dispose();
    }
}
