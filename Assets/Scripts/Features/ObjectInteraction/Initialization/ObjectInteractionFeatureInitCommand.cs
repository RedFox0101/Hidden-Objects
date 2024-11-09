using Assets.Scripts.Infrastructure;
using Zenject;

public class ObjectInteractionFeatureInitCommand : BaseFeatureInitCommand
{
    public override void BindDependencies(DiContainer DiContainer)
    {
        DiContainer.BindInterfacesAndSelfTo<ObjectInteractionService>().AsSingle();
    }
}
