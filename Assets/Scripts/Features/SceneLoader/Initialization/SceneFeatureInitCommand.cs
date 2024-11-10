using Assets.Scripts.Features.SceneLoader.Service;
using Assets.Scripts.Infrastructure;
using Zenject;

public class SceneFeatureInitCommand : BaseFeatureInitCommand
{
    public override void BindDependencies(DiContainer diContainer)
    {
       
        diContainer.BindInterfacesAndSelfTo<SceneLoaderService>().AsSingle();
    }
}
