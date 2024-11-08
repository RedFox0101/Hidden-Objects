using Assets.Scripts.Features.SceneLoader;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Assets.Scripts.Features.AssetLoader
{
    public class LoadingScreenProvider
    {
        private GameObject _cashObject;

        public async Task<UILoadingScreen> LoadUILoadScreenAsync(string key)
        {

            AsyncOperationHandle handle = Addressables.InstantiateAsync(key);
            _cashObject = (GameObject)await handle.Task;


            if (_cashObject.TryGetComponent(out UILoadingScreen loadingScreen))
            {
                return loadingScreen;
            }
            else
            {
                Debug.LogError($"Failed to load asset with key: {key}");
                return null;
            }
        }

        public void UnloadLoadingScreen()
        {
            if (_cashObject == null)
                return;

            _cashObject.SetActive(false);
            Addressables.ReleaseInstance(_cashObject);
            _cashObject = null;
        }
    }
}