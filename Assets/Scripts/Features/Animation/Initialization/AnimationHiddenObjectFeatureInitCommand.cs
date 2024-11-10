using Assets.Scripts.Infrastructure;
using Zenject;

public class AnimationHiddenObjectFeatureInitCommand : BaseFeatureInitCommand
{
    public override void BindDependencies(DiContainer DiContainer)
    {
        DiContainer.BindInterfacesAndSelfTo<AnimationViewFactory>().AsSingle();
    }
}
