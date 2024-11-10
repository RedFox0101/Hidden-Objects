using UnityEngine;

public class MobileCameraControl : ICameraControl
{
    private readonly Camera _camera;
    private CameraControlConfig _cameraControlConfig;

    private Vector3 _swipeStart;
    private bool _isSwiping;
    private bool _isInertiaActive;
    private Vector3 _swipeVelocity;

    public MobileCameraControl(Camera camera, CameraControlConfig cameraControlConfig)
    {
        _camera = camera;
        _cameraControlConfig = cameraControlConfig;
    }
    public void MoveCamera()
    {
        if (Input.touchCount == 2)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            _swipeStart = Input.mousePosition;
            _isSwiping = true;
            _isInertiaActive = false;
        }
        else if (Input.GetMouseButtonUp(0) && _isSwiping)
        {
            Vector3 swipeEnd = Input.mousePosition;
            Vector3 swipeDelta = swipeEnd - _swipeStart;

            if (swipeDelta.magnitude >= _cameraControlConfig.SwipeThreshold)
            {
                Vector3 moveDirection = Vector3.zero;


                if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
                {
                    moveDirection = swipeDelta.x > 0 ? Vector3.right : Vector3.left;
                }
                else
                {
                    moveDirection = swipeDelta.y > 0 ? Vector3.up : Vector3.down;
                }


                _swipeVelocity = moveDirection * _cameraControlConfig.MaxSwipeSpeed;
                _isInertiaActive = true;
            }

            _isSwiping = false;
        }

        if (_isInertiaActive)
        {
            _camera.transform.position += _swipeVelocity * Time.deltaTime;


            _swipeVelocity = Vector3.Lerp(_swipeVelocity, Vector3.zero, _cameraControlConfig.InertiaDamping * Time.deltaTime);


            if (_swipeVelocity.magnitude < 0.01f)
            {
                _isInertiaActive = false;
            }
        }
    }

    public void ZoomCamera()
    {
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);


            float prevTouchDeltaMag = (touchZero.position - touchZero.deltaPosition - (touchOne.position - touchOne.deltaPosition)).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;


            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;


            _camera.orthographicSize += deltaMagnitudeDiff * _cameraControlConfig.ZoomSpeed;
        }
    }
}
