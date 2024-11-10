
using UnityEngine;

public class HiddenObjectMessageContainer : IMessageContainer
{
    public readonly HiddenObjectData HiddenObjectData;
    public readonly Transform Transform;

    public HiddenObjectMessageContainer(HiddenObjectData hiddenObjectData, Transform transform)
    {
        Transform = transform;
        HiddenObjectData = hiddenObjectData;
    }

    public object SpriteRenderer { get; internal set; }
}
