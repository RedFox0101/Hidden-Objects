using Assets.Scripts.Features.SceneLoader.Service;
using UnityEngine;
using Zenject;

public class Bootstrup : MonoBehaviour
{
    [SerializeField] private string _levelScene;
    private SceneLoaderService _sceneLoaderService;

    [Inject]
    private void Constrcut(SceneLoaderService sceneLoaderService)
    {
        _sceneLoaderService=sceneLoaderService;
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
        _sceneLoaderService.LoadScene(_levelScene);
    }
}
