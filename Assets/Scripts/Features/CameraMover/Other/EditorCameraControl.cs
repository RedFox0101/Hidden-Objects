using UnityEngine;

public class EditorCameraControl : ICameraControl
{
    private readonly Camera _camera;
    private CameraControlConfig _cameraControlConfig;

    private Vector3 _swipeStart;
    private bool _isSwiping;
    private bool _isInertiaActive;
    private Vector3 _swipeVelocity;

    public EditorCameraControl(Camera camera, CameraControlConfig cameraControlConfig)
    {
        _camera = camera;
        _cameraControlConfig = cameraControlConfig;
    }

    public void MoveCamera()
    {
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

        float scrollInput = Input.GetAxis(CameraConstant.MouseScrollWheel);

        if (scrollInput != 0f)
        {
            _camera.orthographicSize -= scrollInput * _cameraControlConfig.ZoomSpeed;
        }
    }
}

