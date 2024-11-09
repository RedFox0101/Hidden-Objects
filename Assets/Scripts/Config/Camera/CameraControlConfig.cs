using UnityEngine;

[CreateAssetMenu(menuName = "Config/Camera Control Config", fileName = "Camera Control Config", order = 0)]
public class CameraControlConfig : ScriptableObject
{
    [field: SerializeField] public float DragSpeed { get; private set; }
    [field: SerializeField] public float ZoomSpeed { get; private set; }
    [field: SerializeField] public float SwipeThreshold { get; private set; }
    [field: SerializeField] public float MaxSwipeSpeed { get; private set; }
    [field: SerializeField] public float InertiaDamping { get; private set; }

}