using Assets.Scripts.Features.SceneLoader;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Assets.Scripts.Features.AssetLoader
{
    public class AssetsLoaderService
    {
        private Dictionary<string, object> _loadedAssets = new Dictionary<string, object>();

        public async Task< UILoadingScreen> LoadUILoadScreenAsync(string key)
        {
            if (_loadedAssets.ContainsKey(key))
            {
                return _loadedAssets[key] as UILoadingScreen;
            }

            AsyncOperationHandle handle = Addressables.InstantiateAsync(key);
            var cashObject =(GameObject) await handle.Task;


            if(cashObject.TryGetComponent(out UILoadingScreen loadingScreen))
            {
                return loadingScreen;
            }
            else
            {
                Debug.LogError($"Failed to load asset with key: {key}");
                return null;
            }
        }

        public void ReleaseAsset(string key)
        {
            if (_loadedAssets.ContainsKey(key))
            {
                Addressables.Release(_loadedAssets[key]);
                _loadedAssets.Remove(key);
            }
        }

        public void ReleaseAllAssets()
        {
            foreach (var asset in _loadedAssets.Values)
            {
                Addressables.Release(asset);
            }
            _loadedAssets.Clear();
        }
    }
}