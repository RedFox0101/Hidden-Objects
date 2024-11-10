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

            var asyncOperation = SceneManager.LoadSceneAsync(sceneName);
            asyncOperation.allowSceneActivation = false;

            while (!asyncOperation.isDone)
            {

                float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
                _loadingScreen.SetProgress(progress);


                if (asyncOperation.progress >= 0.9f)
                {
                    asyncOperation.allowSceneActivation = true;
                }

                await Task.Yield();
            }

            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        }

        private async Task LoadUILoadingScreen()
        {
            _loadingScreen = await _loadingScreenProvider.LoadUILoadScreenAsync(SceneLoaderConstant.UILoadingScreen);
        }
    }
}