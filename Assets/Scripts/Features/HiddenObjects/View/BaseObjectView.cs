using Assets.Scripts.Features.AssetLoader;
using UnityEngine;
using Zenject;

public abstract class BaseObjectView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private AssetsLoaderService _assetsLoaderService;
    private SavingService _savingService;

    private HiddenObjectData _hiddenObjectData;
    protected IClickCommand ObjectClickCommand;
    protected ILoadSaveCommand LoadSaveCommand;

    public HiddenObjectData HiddenObjectData => _hiddenObjectData;

    [Inject]
    private void Construtor(AssetsLoaderService assetsLoaderService, SavingService savingService)
    {
        _assetsLoaderService = assetsLoaderService;
        _savingService = savingService;
    }

    public async virtual void Setup(HiddenObjectData hiddenObjectData)
    {
        _hiddenObjectData = hiddenObjectData;
        InitializeHiddenObject(hiddenObjectData);
        LoadSaveCommand.LoadSave(hiddenObjectData.ToString(), _savingService);
        _spriteRenderer.sprite = await _assetsLoaderService.LoadAsset<Sprite>(hiddenObjectData.Id);
    }

    public void OnClickedObject()
    {
        ObjectClickCommand.Execute();
    }

    private void InitializeHiddenObject(HiddenObjectData hiddenObjectData)
    {
        transform.position = new Vector3(hiddenObjectData.Position.x, hiddenObjectData.Position.y);
        transform.localRotation = Quaternion.Euler(Vector3.zero.VectorToVector3(hiddenObjectData.Rotation));
        transform.localScale = Vector3.zero.VectorToVector3(hiddenObjectData.Scale);
        gameObject.AddComponent<BoxCollider2D>();    
    }
}
