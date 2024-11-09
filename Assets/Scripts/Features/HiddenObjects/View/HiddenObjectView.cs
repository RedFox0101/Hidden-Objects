using UnityEngine;
using Zenject;

public class HiddenObjectView : BaseObjectView
{
   
    private MessageBroker _messageBroker;

    [Inject]
    private void Constructor(MessageBroker messageBroker)
    {
       _messageBroker = messageBroker;
    }

    public override void Setup(HiddenObjectData hiddenObjectData)
    {
        ObjectClickCommand=new HiddenObjectCommand(this, _messageBroker);
        base.Setup(hiddenObjectData);
    }

    [ContextMenu("Test")]
    public void Test()
    {
        OnClickedObject();
    }
}
