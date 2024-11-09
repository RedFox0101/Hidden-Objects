using Assets.Scripts.Features.AssetLoader;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;
public class HiddenObjectUIFactory : IFactory<Transform, Task<HiddenObjectUI>>
{
    private AssetsLoaderService _assetLoaderService;
    private GameObject _hiddenObjectUIPrefab;

    private DiContainer _container;

    public HiddenObjectUIFactory(DiContainer diContainer,AssetsLoaderService assetLoaderService)
    {
        _assetLoaderService = assetLoaderService;
        _container = diContainer;
        LoadPrefab();
    }

    private async void LoadPrefab()
    {
        _hiddenObjectUIPrefab = await _assetLoaderService.LoadAsset<GameObject>("HiddenObjectUI");
    }

    public async Task<HiddenObjectUI> Create(Transform parent)
    {
        if(_hiddenObjectUIPrefab == null)
            _hiddenObjectUIPrefab =await _assetLoaderService.LoadAsset<GameObject>("HiddenObjectUI");

        return _container.InstantiatePrefabForComponent<HiddenObjectUI>(_hiddenObjectUIPrefab, parent);
    }
}
