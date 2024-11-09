using Assets.Scripts.Features.AssetLoader;
using System.Threading.Tasks;
using UnityEngine;

public class ObjectInitializeService
{
    private HiddenObjectFactory _hiddenObjectFactoryService;
    private LevelRepository _levelRepository;
    private AssetsLoaderService _assetsLoaderService;

    private BaseObjectView _producerViewPrefab;
    private BaseObjectView _hiddenObjectViewPrefab;

    private Transform _parent;

    public ObjectInitializeService(HiddenObjectFactory hiddenObjectFactoryService, LevelRepository levelRepository, AssetsLoaderService assetsLoaderService)
    {
        _hiddenObjectFactoryService = hiddenObjectFactoryService;
        _levelRepository = levelRepository;
        _assetsLoaderService = assetsLoaderService;
    }

    public async void InitializeObjects(Transform parent)
    {
        _parent = parent;

        if (_producerViewPrefab == null)
        {
            _producerViewPrefab = await LoadPrefab(LevelConstant.ProducerAssetKey);
            _hiddenObjectViewPrefab = await LoadPrefab(LevelConstant.HiddenObjectAssetKey);
        }

        foreach (var hiddenObject in _levelRepository.LevelConfig[0].LevelData.Objects)
        {
            var prefab = hiddenObject.Produces != null ? _producerViewPrefab : _hiddenObjectViewPrefab;

            var newObjects = _hiddenObjectFactoryService.Create((prefab, parent));
            newObjects.Setup(hiddenObject);
        }
    }

    public void CreateHiddenObject(HiddenObjectData hiddenObjectData)
    {
        var newObjects = _hiddenObjectFactoryService.Create((_hiddenObjectViewPrefab, _parent));
        newObjects.Setup(hiddenObjectData);
    }

    private async Task<BaseObjectView> LoadPrefab(string assetKey)
    {
        var prefab = await _assetsLoaderService.LoadAsset<GameObject>(assetKey);
        return prefab.GetComponent<BaseObjectView>();
    }
}
