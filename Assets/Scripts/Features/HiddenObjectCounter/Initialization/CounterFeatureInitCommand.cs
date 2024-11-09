using Assets.Scripts.Infrastructure;
using Zenject;

public class CounterFeatureInitCommand : BaseFeatureInitCommand
{
    public override void BindDependencies(DiContainer DiContainer)
    {
        DiContainer.BindInterfacesAndSelfTo<HiddenObjectUIFactory>().AsSingle();
        DiContainer.BindInterfacesAndSelfTo<ObjectCounterService>().AsSingle();
    }
}
