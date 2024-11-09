using Assets.Scripts.Infrastructure;
using Zenject;

public class LeveFeatureInitCommand : BaseFeatureInitCommand
{
    public override void BindDependencies(DiContainer DiContainer)
    {
        DiContainer.BindInterfacesAndSelfTo<ObjectInitializeService>().AsSingle();
    }
}
