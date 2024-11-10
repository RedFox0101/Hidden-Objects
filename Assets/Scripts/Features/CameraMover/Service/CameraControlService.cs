using System.Threading.Tasks;
using UniRx;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class CameraControlService 
{
    private CompositeDisposable _compositeDisposable;
    private ICameraControlStrategy _cameraControl;
    private readonly CameraControlConfig _config;

    public CameraControlService(CameraControlConfig config)
    {
        _config = config;
    }


    public async Task StartMoveCamera()
    {
        SetCameraControlStrategy(_config);
        Observable.EveryUpdate().Subscribe(_ =>
        {
            _cameraControl.MoveCamera();
            _cameraControl.ZoomCamera();
        }).AddTo(_compositeDisposable);
    }

    private void SetCameraControlStrategy(CameraControlConfig config)
    {
        _compositeDisposable = new CompositeDisposable();
#if UNITY_EDITOR 
        _cameraControl = new PlayModeCameraControl(Camera.main, config);
#else
#endif
    }

    public void StopMoveCamera()
    {
        _compositeDisposable.Clear();
    }
}
