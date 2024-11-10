using System.Security.Cryptography;
using System.Text;

[System.Serializable]
public class HiddenObjectData
{
    public string Id;
    public Vector Position;
    public Vector Scale;
    public int Layer;
    public Vector Rotation;
    public string Key;
    public Producer Produces;

    public override string ToString()
    {
        return Key;
    }

}

