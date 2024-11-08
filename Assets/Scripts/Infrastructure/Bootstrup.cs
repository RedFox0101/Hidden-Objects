using Assets.Scripts.Features.SceneLoader;
using Assets.Scripts.Features.SceneLoader.Service;
using UnityEngine;
using Zenject;

public class Bootstrup : MonoBehaviour
{
    [SerializeField] private SceneSelector _levelScene;
    private SceneLoaderService _sceneLoaderService;

    [Inject]
    private void Constrcut(SceneLoaderService sceneLoaderService)
    {
        _sceneLoaderService=sceneLoaderService;
    }

    private void Start()
    {
        _sceneLoaderService.LoadScene(_levelScene.SceneName);
    }
}
