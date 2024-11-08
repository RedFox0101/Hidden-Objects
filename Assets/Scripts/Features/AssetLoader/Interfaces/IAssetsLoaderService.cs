using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Features.AssetLoader
{
    public interface IAssetsLoaderService
    {
        Task<T> LoadAssetAsync<T>(string key) where T : Object;
        void ReleaseAllAssets();
        void ReleaseAsset(string key);
    }
}