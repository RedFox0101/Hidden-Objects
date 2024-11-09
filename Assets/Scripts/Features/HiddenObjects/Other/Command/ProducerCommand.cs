using UnityEngine;

public class ProducerCommand : ICommand
{
    private BoxCollider2D _collider2D;
    private ObjectInitializeService _hiddenObjectFactory;
    private HiddenObjectData _hiddenObjectData;

    public ProducerCommand(BoxCollider2D collider2D, ObjectInitializeService hiddenObjectFactory, HiddenObjectData hiddenObjectData)
    {
        _collider2D = collider2D;
        if (_collider2D != null)
            Debug.Log("Collider " + (_collider2D == null));
        _hiddenObjectFactory = hiddenObjectFactory;
        _hiddenObjectData = hiddenObjectData;
    }

    public void Execute()
    {
        if (_collider2D != null)
            _collider2D.enabled = false;
        var hiddenObjectData = new HiddenObjectData()
        {
            Id = _hiddenObjectData.Produces.Id,
            Layer = _hiddenObjectData.Produces.Layer,
            Position = _hiddenObjectData.Produces.Position,
            Rotation = _hiddenObjectData.Produces.Rotation,
            Scale = _hiddenObjectData.Produces.Scale,
        };
        _hiddenObjectFactory.CreateHiddenObject(hiddenObjectData);
    }
}
