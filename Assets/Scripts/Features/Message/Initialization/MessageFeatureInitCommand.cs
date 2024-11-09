using Assets.Scripts.Infrastructure;
using Zenject;

public class MessageFeatureInitCommand : BaseFeatureInitCommand
{
    public override void BindDependencies(DiContainer DiContainer)
    {
        DiContainer.BindInterfacesAndSelfTo<MessageBroker>().AsSingle();
    }
}
