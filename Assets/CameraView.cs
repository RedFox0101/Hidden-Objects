using UnityEngine;
using Zenject;

public class CameraView : MonoBehaviour
{
   private CameraControlService _cameraControlService;

    [Inject]
    public void Constructor(CameraControlService cameraControlService)
    {
        _cameraControlService = cameraControlService;
    }

    private void Start()
    {
        _cameraControlService.StartMoveCamera();
    }

    private void OnDisable()
    {
        _cameraControlService.StopMoveCamera();
    }
}
