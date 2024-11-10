public class AnimationMessage : MessageBase
{
    public AnimationMessageContainer Data;
    public AnimationMessage(string id, AnimationMessageContainer data) : base(id)
    {
        Data = data;
    }
}
