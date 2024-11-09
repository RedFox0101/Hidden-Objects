using UnityEngine;
using Zenject;

public class HiddenObjectFactory : IFactory<(BaseObjectView, Transform), BaseObjectView>
{
    private DiContainer _container;
  
    public HiddenObjectFactory(DiContainer container)
    {
        _container = container;
    }

    public BaseObjectView Create((BaseObjectView, Transform) param)
    {
        var newObject = _container.InstantiatePrefabForComponent<BaseObjectView>(param.Item1, param.Item2);
        return newObject;
    }
}
