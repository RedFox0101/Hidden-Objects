using Assets.Scripts.Features.AssetLoader;
using Assets.Scripts.Infrastructure;
using Zenject;

public class AssetFeatureInitCommand : BaseFeatureInitCommand
{
    public override void BindDependencies(DiContainer DiContainer)
    {
        DiContainer.BindInterfacesAndSelfTo<AssetsLoaderService>().AsSingle();
        DiContainer.BindInterfacesAndSelfTo<LoadingScreenProvider>().AsSingle();
    }
}
