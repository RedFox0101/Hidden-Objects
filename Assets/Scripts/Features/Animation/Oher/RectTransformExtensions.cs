using UnityEngine;

public static class RectTransformExtensions
{

    public static RectTransform TransformToRectTransform(this RectTransform rectTransform, Transform targetTransform)
    {
        rectTransform.position = targetTransform.position;


        rectTransform.rotation = targetTransform.rotation;


        Vector3 targetScale = targetTransform.lossyScale;
        rectTransform.sizeDelta = new Vector2(targetTransform.localScale.x, targetTransform.localScale.y);


        rectTransform.localScale = new Vector3(targetScale.x, targetScale.y, targetScale.z);

        return rectTransform;
    }
}
