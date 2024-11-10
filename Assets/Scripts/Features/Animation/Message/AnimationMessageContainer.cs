public class AnimationMessageContainer:IMessageContainer
{
    public readonly string HiddenObjectId;

    public AnimationMessageContainer(string hiddenObjectId)
    {
        HiddenObjectId = hiddenObjectId;
    }
}
