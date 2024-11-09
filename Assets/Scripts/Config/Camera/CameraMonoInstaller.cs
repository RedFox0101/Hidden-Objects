using UnityEngine;
using Zenject;

public class CameraMonoInstaller : MonoInstaller<CameraMonoInstaller>
{
    [SerializeField] private CameraControlConfig _cameraControlConfig;
    public override void InstallBindings()
    {
        Container.Bind<CameraControlConfig>().FromInstance(_cameraControlConfig);
    }
}
