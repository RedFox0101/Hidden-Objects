using Assets.Scripts.Infrastructure;
using Zenject;

public class HiddenObjectFeatureInitCommand : BaseFeatureInitCommand
{
    public override void BindDependencies(DiContainer DiContainer)
    {
        DiContainer.BindInterfacesAndSelfTo<HiddenObjectFactory>().AsSingle();
    }
}
