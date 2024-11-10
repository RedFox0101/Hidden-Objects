using Assets.Scripts.Features.AssetLoader;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelSetupService : MonoBehaviour
{
    [RequireInterfaceAttribute(typeof(IServiceStarter))][SerializeField] private List<MonoBehaviour> _serviceStarters = new List<MonoBehaviour>();

    private LoadingScreenProvider _loadingScreenProvider;

    private List<IServiceStarter> _currentServiceStarters = new List<IServiceStarter>();

    [Inject]
    private void Constructor(LoadingScreenProvider loadingScreenProvider)
    {
        _loadingScreenProvider = loadingScreenProvider;
    }

    private async void Awake()
    {
        var loadingScreen = await _loadingScreenProvider.LoadUILoadScreenAsync(SceneLoaderConstant.UILoadingScreen);
        foreach (var service in _serviceStarters)
        {
            if (service.TryGetComponent<IServiceStarter>(out IServiceStarter serviceStarter))
            {
                _currentServiceStarters.Add(serviceStarter);
                await serviceStarter.StartService();
            }
        }
        _loadingScreenProvider.UnloadLoadingScreen();
    }

    private void OnDestroy()
    {
        foreach (var service in _currentServiceStarters)
        {
            service.StopService();
        }
    }
}
