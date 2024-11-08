using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Features.SceneLoader
{
    public class SceneSelector : MonoBehaviour
    {
        [SerializeField, HideInInspector] public string SceneName;

        public SceneAsset SceneAsset;

        private void OnValidate()
        {
            if (SceneAsset != null)
                SceneName = SceneAsset.name;
        }
    }
}