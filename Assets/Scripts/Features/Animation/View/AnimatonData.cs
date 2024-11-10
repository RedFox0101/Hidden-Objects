using UnityEngine;

public class AnimatonData
{
    public readonly RectTransform TargetTransformForPosition;
    public readonly RectTransform TargetTransformForScale;

    public AnimatonData(RectTransform targetTransformForPosition, RectTransform targetTransformForScale)
    {
        TargetTransformForPosition = targetTransformForPosition;
        TargetTransformForScale = targetTransformForScale;
    }
}

