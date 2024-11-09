using Assets.Scripts.Features.AssetLoader;
using UnityEngine;
using Zenject;

public abstract class BaseObjectView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private AssetsLoaderService _assetsLoaderService;
    private HiddenObjectData _hiddenObjectData;
    protected ICommand ObjectClickCommand;
    protected BoxCollider2D Collider;

    public HiddenObjectData HiddenObjectData => _hiddenObjectData;

    [Inject]
    private void Construtor(AssetsLoaderService assetsLoaderService)
    {
        _assetsLoaderService = assetsLoaderService;
    }

    public async virtual void Setup(HiddenObjectData hiddenObjectData)
    {
        _hiddenObjectData = hiddenObjectData;
        _spriteRenderer.sprite = await _assetsLoaderService.LoadAsset<Sprite>(hiddenObjectData.Id);
        transform.position = Vector3.zero.VectorToVector3(hiddenObjectData.Position);
        transform.localRotation = Quaternion.Euler(Vector3.zero.VectorToVector3(hiddenObjectData.Rotation));
        transform.localScale = Vector3.zero.VectorToVector3(hiddenObjectData.Scale);
        Collider = gameObject.AddComponent<BoxCollider2D>();
    }

    public void OnClickedObject()
    {
        ObjectClickCommand.Execute();
    }
}
