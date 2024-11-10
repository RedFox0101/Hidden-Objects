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
    [SerializeField] private RectTransform _rectTransform;

    private AssetsLoaderService _assetsLoaderService;
    private MessageBroker _messageBroker;
    private AnimationViewFactory _animationViewFactory;
    private CompositeDisposable _disposables = new CompositeDisposable();

    private int _foundObjectCount;

    [Inject]
    private void Constructor(AssetsLoaderService assetsLoaderService, MessageBroker messageBroker, AnimationViewFactory animationViewFactory)
    {
        _assetsLoaderService = assetsLoaderService;
        _messageBroker = messageBroker;
        _animationViewFactory = animationViewFactory;
    }

    public async void Setup(int maxHiddenObject, int foundObjectCount, string id)
    {
        _foundObjectCount = foundObjectCount;
        _label.text = $"{_foundObjectCount}/{maxHiddenObject}";

        SubscribeToHiddenObjectMessages(id);
        SubscribeToAnimationMessages(maxHiddenObject.ToString(), id);
        _icon.sprite = await _assetsLoaderService.LoadAsset<Sprite>(id);
    }

    private void SubscribeToHiddenObjectMessages(string id)
    {
        _messageBroker.Receive<HiddenObjectMessage>()
           .Where(msg => msg.Id == id)
           .Subscribe(async msg =>
           {
              CreateAnimationView(msg);
           }).AddTo(_disposables);
    }

    private void CreateAnimationView(HiddenObjectMessage msg)
    {
        var animationView = _animationViewFactory.Create();
        animationView.Setup(msg.MessageContainer, _rectTransform);
    }

    private void SubscribeToAnimationMessages(string maxHiddenObject, string id)
    {
        _messageBroker.Receive<AnimationMessage>()
           .Where(msg => msg.Id == id)
           .Subscribe(msg =>
           {
               _foundObjectCount++;
               _label.text = $"{_foundObjectCount}/{maxHiddenObject}";
           }).AddTo(_disposables);
    }


    private void OnDestroy()
    {
        _disposables.Dispose();
    }
}
