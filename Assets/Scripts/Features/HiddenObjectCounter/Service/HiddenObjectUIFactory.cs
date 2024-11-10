using Assets.Scripts.Features.AssetLoader;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;
public class HiddenObjectUIFactory : IFactory<Transform, HiddenObjectUI>
{
    private AssetsLoaderService _assetLoaderService;
    private GameObject _hiddenObjectUIPrefab;

    private DiContainer _container;

    public HiddenObjectUIFactory(DiContainer diContainer,AssetsLoaderService assetLoaderService)
    {
        _assetLoaderService = assetLoaderService;
        _container = diContainer;
    }

    public async Task LoadPrefab()
    {
        _hiddenObjectUIPrefab = await _assetLoaderService.LoadAsset<GameObject>(ObjectCounterConstant.HiddenObjectUIAssetKey);
    }

    public  HiddenObjectUI Create(Transform parent)
    {
        return _container.InstantiatePrefabForComponent<HiddenObjectUI>(_hiddenObjectUIPrefab, parent);
    }
}
