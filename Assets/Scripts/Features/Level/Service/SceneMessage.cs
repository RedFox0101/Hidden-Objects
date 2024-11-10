public class SceneMessage : MessageBase
{
    public readonly string SceneName;

    public SceneMessage(string id, string sceneName) : base(id)
    {
        SceneName = sceneName;
    }
}
