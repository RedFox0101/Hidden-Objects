using Assets.Scripts.Features.SceneLoader;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Assets.Scripts.Features.AssetLoader
{
    public class LoadingScreenProvider
    {
        private UILoadingScreen _cashObject;

        public async Task<UILoadingScreen> LoadUILoadScreenAsync(string key)
        {
            if(_cashObject != null)
            {
                _cashObject.gameObject.SetActive(true);
                return _cashObject;
            }

            AsyncOperationHandle handle = Addressables.InstantiateAsync(key);
            var gameObject = (GameObject)await handle.Task;


            if (gameObject.TryGetComponent(out UILoadingScreen loadingScreen))
            {
                _cashObject=loadingScreen;
                return loadingScreen;
            }
            else
            {
                Debug.LogError($"Failed to load asset with _saveDataKey : {key}");
                return null;
            }
        }

        public void UnloadLoadingScreen()
        {
            if (_cashObject == null)
                return;

            _cashObject.gameObject.SetActive(false);
        }
    }
}