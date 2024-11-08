using Assets.Scripts.Infrastructure;
using Zenject;

public class FeaturesMonoInstaller : MonoInstaller<FeaturesMonoInstaller>
{
    private FeaturesInitCommand _featuresInitCommand;
    public override void InstallBindings()
    {
        _featuresInitCommand = new FeaturesInitCommand(Container);
    }
}
