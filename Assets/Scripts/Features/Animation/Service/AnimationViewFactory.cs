using Assets.Scripts.Features.AssetLoader;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class AnimationViewFactory : IFactory<HiddenObjectAnimationView>
{
    private HiddenObjectAnimationView _hiddenObjectAnimationView;
    private AssetsLoaderService _assetLoaderService;
    private Transform _parent;
    DiContainer _diContainer;

    public AnimationViewFactory(AssetsLoaderService assetLoaderService, DiContainer diContainer)
    {
        _assetLoaderService = assetLoaderService;
        _diContainer = diContainer;
    }


    public HiddenObjectAnimationView Create()
    {
        return _diContainer.InstantiatePrefabForComponent<HiddenObjectAnimationView>(_hiddenObjectAnimationView, _parent);
    }

    public async Task LoadPrefab(Transform parent)
    {
        _parent = parent;
        if (_hiddenObjectAnimationView == null)
        {
            var prefab = await _assetLoaderService.LoadAsset<GameObject>(AnimationConstant.AnimationViewAssetKey);
            _hiddenObjectAnimationView = prefab.GetComponent<HiddenObjectAnimationView>();
        }
    }
}
