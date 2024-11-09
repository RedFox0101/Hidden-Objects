using Assets.Scripts.Infrastructure;
using Zenject;

public class CameraFeatureInitCommand : BaseFeatureInitCommand
{
    public override void BindDependencies(DiContainer DiContainer)
    {
        DiContainer.BindInterfacesAndSelfTo<CameraControlService>().AsSingle();
    }
}
