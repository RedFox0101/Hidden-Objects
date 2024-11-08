using Assets.Scripts.Features.SceneLoader.Service;
using Assets.Scripts.Infrastructure;
using UnityEngine;
using Zenject;

public class SceneFeatureInitCommand : BaseFeatureInitCommand
{
    public override void BindDependencies(DiContainer diContainer)
    {
        Debug.Log("BindDependencies");
        diContainer.BindInterfacesAndSelfTo<SceneLoaderService>().AsSingle();
    }
}
