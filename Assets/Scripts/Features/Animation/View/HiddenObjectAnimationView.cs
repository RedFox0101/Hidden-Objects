using Assets.Scripts.Features.AssetLoader;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Sequence = DG.Tweening.Sequence;

public class HiddenObjectAnimationView : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private float _duration = 0.5f;
    [SerializeField] private Image _image;

    private MessageBroker _messageBroker;
    private AssetsLoaderService _assetsLoaderService;
    private HiddenObjectData _hiddenObjectData;

    [Inject]
    private void Constructor(MessageBroker messageBroker, AssetsLoaderService assetsLoaderService)
    {
        _messageBroker = messageBroker;
        _assetsLoaderService = assetsLoaderService;
    }

    public async void Setup(HiddenObjectMessageContainer hiddenObjectMessageContainer, RectTransform targetTransform)
    {
        _hiddenObjectData = hiddenObjectMessageContainer.HiddenObjectData;

        _image.sprite = await _assetsLoaderService.LoadAsset<Sprite>(_hiddenObjectData.Id);

        Vector3 screenPosition = Camera.main.WorldToScreenPoint(hiddenObjectMessageContainer.Transform.position);

        _rectTransform.position = screenPosition;
        _rectTransform.sizeDelta = new(targetTransform.rect.width, targetTransform.rect.height);
        _rectTransform.DOMove(targetTransform.position, _duration)
        .OnComplete(OnComplete);
    }

    private void OnComplete()
    {
        var message = new AnimationMessage(_hiddenObjectData.Id, new AnimationMessageContainer(_hiddenObjectData.Id));
        _messageBroker.Publish(message);
    }
}

