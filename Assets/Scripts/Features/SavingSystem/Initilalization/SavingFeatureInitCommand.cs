using Assets.Scripts.Infrastructure;
using Zenject;

public class SavingFeatureInitCommand : BaseFeatureInitCommand
{
    public override void BindDependencies(DiContainer DiContainer)
    {
        DiContainer.BindInterfacesAndSelfTo<SavingService>().AsSingle();
        DiContainer.BindInterfacesAndSelfTo<HiddenObjectSaveDataAdapter>().AsSingle();
        DiContainer.BindInterfacesAndSelfTo<ProducerSaveDataAdapter>().AsSingle();
    }
}
