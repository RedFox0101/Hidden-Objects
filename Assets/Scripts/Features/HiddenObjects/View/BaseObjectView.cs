using Assets.Scripts.Features.AssetLoader;
using UnityEngine;
using Zenject;

public abstract class BaseObjectView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private LayerMask _layerMask;

    private AssetsLoaderService _assetsLoaderService;

    [Inject]
    private void Construtor(AssetsLoaderService assetsLoaderService)
    {
        _assetsLoaderService = assetsLoaderService;
    }

    public async void Setup(HiddenObjectData hiddenObjectData)
    {
        _spriteRenderer.sprite = await _assetsLoaderService.LoadSprite(hiddenObjectData.Id);
        transform.position = Vector3.zero.VectorToVector3(hiddenObjectData.Position);
        transform.localRotation = Quaternion.Euler(Vector3.zero.VectorToVector3(hiddenObjectData.Rotation));
        transform.localScale = Vector3.zero.VectorToVector3(hiddenObjectData.Scale);
        _layerMask.value = hiddenObjectData.Layer;
        gameObject.AddComponent<BoxCollider2D>();
    }
}
