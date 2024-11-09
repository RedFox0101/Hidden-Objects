using Assets.Scripts.Features.SceneLoader;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Assets.Scripts.Features.AssetLoader
{
    public class AssetsLoaderService
    {
        private Dictionary<string, object> _loadedAssets = new Dictionary<string, object>();

        public async Task<T> LoadAsset<T>(string key) where T : class
        {
            if (_loadedAssets.ContainsKey(key))
            {
                return _loadedAssets[key] as T;
            }

            var handle = Addressables.LoadAssetAsync<T>(key);
            var cachObject =(T) await handle.Task;


            if(handle.Status==AsyncOperationStatus.Succeeded)
            {
                _loadedAssets[key] = cachObject;
                return cachObject;
            }
            else
            {
                Debug.LogError($"Failed to load asset with key: {key}");
                return null;
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