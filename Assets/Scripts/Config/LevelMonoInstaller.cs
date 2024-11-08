using UnityEngine;
using Zenject;

public class LevelMonoInstaller : MonoInstaller
{
    [SerializeField] private LevelRepository _levelRepository;

    public override void InstallBindings()
    {
        Container.Bind<LevelRepository>().FromInstance(_levelRepository).AsSingle();
    }
}
