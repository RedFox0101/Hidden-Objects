using Assets.Scripts.Features.AssetLoader;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;
namespace Assets.Scripts.Features.SceneLoader.Service
{
    public class SceneLoaderService : ISceneLoaderService
    {
        private CompositeDisposable _disposables = new CompositeDisposable();
        private LoadingScreenProvider _loadingScreenProvider;
        private UILoadingScreen _loadingScreen;

        public SceneLoaderService(LoadingScreenProvider assetsLoaderService)
        {
            _loadingScreenProvider = assetsLoaderService;
        }

        public async void LoadScene(string sceneName) => await LoadSceneAsync(sceneName);

        private async Task LoadSceneAsync(string sceneName)
        {
            await LoadUILoadingScreen();

            SceneManager.LoadSceneAsync(sceneName).AsAsyncOperationObservable().Do(x =>
            {
                float progress = Mathf.Clamp01(x.progress / 0.9f);
                _loadingScreen.SetProgress(progress);
            }).Subscribe(_ =>
            {
                _loadingScreenProvider.UnloadLoadingScreen();
                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            }).AddTo(_disposables);
        }

        private async Task LoadUILoadingScreen()
        {
            _loadingScreen = await _loadingScreenProvider.LoadUILoadScreenAsync(SceneLoaderConstant.UILoadingScreen);
        }
    }
}