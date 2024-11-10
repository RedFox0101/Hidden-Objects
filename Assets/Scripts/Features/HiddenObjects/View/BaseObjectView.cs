using Assets.Scripts.Config;
using Assets.Scripts.Features.AssetLoader;
using UnityEngine;
using Zenject;

public abstract class BaseObjectView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private AssetsLoaderService _assetsLoaderService;
    private SavingService _savingService;
    private LevelRepository _levelRepository;


    private HiddenObjectData _hiddenObjectData;
    protected IClickCommand ObjectClickCommand;
    protected ILoadSaveCommand LoadSaveCommand;

    public HiddenObjectData HiddenObjectData => _hiddenObjectData;

    [Inject]
    private void Construtor(AssetsLoaderService assetsLoaderService, SavingService savingService, LevelRepository  levelRepository)
    {
        _assetsLoaderService = assetsLoaderService;
        _savingService = savingService;
        _levelRepository = levelRepository;
    }

    public async virtual void Setup(HiddenObjectData hiddenObjectData)
    {
        _hiddenObjectData = hiddenObjectData;
        _spriteRenderer.sprite = await _assetsLoaderService.LoadAsset<Sprite>(hiddenObjectData.Id);
        InitializeHiddenObject(hiddenObjectData);
        LoadSaveCommand.LoadSave(hiddenObjectData.Key+_levelRepository.CurrentLevelConfig.name, _savingService);
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
