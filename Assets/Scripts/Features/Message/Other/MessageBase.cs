public class MessageBase
{
    public string Id { get; private set; }

    public MessageBase(string id)
    {
        this.Id = id;
     
    }
}
