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
        private Dictionary<string, Sprite> _loadedAssets = new Dictionary<string, Sprite>();

        public async Task<Sprite> LoadSprite(string key)
        {
            if (_loadedAssets.ContainsKey(key))
            {
                return _loadedAssets[key];
            }

            var handle = Addressables.LoadAssetAsync<Sprite>(key);
            var cachObject =(Sprite) await handle.Task;


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