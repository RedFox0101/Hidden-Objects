using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class CameraServiceStarter : MonoBehaviour, IServiceStarter
{
    private CameraControlService _cameraControlService;

    [Inject]
    public void Constructor(CameraControlService cameraControlService)
    {
        _cameraControlService = cameraControlService;
    }

    public async Task StartService()
    {
        await _cameraControlService.StartMoveCamera();
    }

    public void StopService()
    {
        _cameraControlService.StopMoveCamera();
    }
}
