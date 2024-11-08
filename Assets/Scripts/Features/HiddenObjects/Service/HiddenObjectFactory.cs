using Zenject;

public class HiddenObjectFactory : IFactory<BaseObjectView, BaseObjectView>
{
    private DiContainer _container;
  
    public HiddenObjectFactory(DiContainer container)
    {
        _container = container;
    }

    public BaseObjectView Create(BaseObjectView prefab)
    {
        var newObject = _container.InstantiatePrefabForComponent<BaseObjectView>(prefab);
        return newObject;
    }
}
