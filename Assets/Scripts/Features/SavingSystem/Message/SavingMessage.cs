public class SavingMessage : MessageBase
{
    public readonly string JsonData;
    public readonly string Key;
    public SavingMessage(string id, string jsonData, string key) : base(id)
    {
        JsonData = jsonData;
        Key = key;
    }
}