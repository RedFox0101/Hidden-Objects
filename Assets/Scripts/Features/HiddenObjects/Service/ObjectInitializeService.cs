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

    public async Task InitializeObjects(Transform parent)
    {
        _parent = parent;

        if (_producerViewPrefab == null)
        {
            _producerViewPrefab = await LoadPrefab(ObjectAssetConstant.ProducerAssetKey);
            _hiddenObjectViewPrefab = await LoadPrefab(ObjectAssetConstant.HiddenObjectAssetKey);
        }

        foreach (var hiddenObject in _levelRepository.CurrentLevelConfig.LevelData.Objects)
        {
            var isProducer = (hiddenObject.Produces != null);
            var prefab = isProducer ? _producerViewPrefab : _hiddenObjectViewPrefab;
            Debug.Log("InitializeObjects " + hiddenObject.Id+ " "+prefab.name);

            var newObjects = _hiddenObjectFactoryService.Create((prefab, parent));
            SetupObject(hiddenObject, newObjects);
        }
    }

    public void CreateHiddenObject(HiddenObjectData hiddenObjectData)
    {
        var newObjects = _hiddenObjectFactoryService.Create((_hiddenObjectViewPrefab, _parent));
        SetupObject(hiddenObjectData, newObjects);
    }

    private void SetupObject(HiddenObjectData hiddenObject, BaseObjectView newObjects)
    {
        newObjects.Setup(hiddenObject);
    }

    private async Task<BaseObjectView> LoadPrefab(string assetKey)
    {
        var prefab = await _assetsLoaderService.LoadAsset<GameObject>(assetKey);
        return prefab.GetComponent<BaseObjectView>();
    }
}
